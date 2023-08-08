namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data.Models.Enums;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<HashSet<DepartmentImportModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var departmentDto in departmentsDto)
            {
                bool isValid = true;

                if (!IsValid(departmentDto) || departmentDto.Cells.Length == 0)
                {
                    isValid = false;
                }

                foreach (var item in departmentDto.Cells)
                {
                    if (!IsValid(item))
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    var department = new Department
                    {
                        Name = departmentDto.Name,
                        Cells = departmentDto.Cells.Select(x => new Cell
                        {
                            CellNumber = x.CellNumber,
                            HasWindow = x.HasWindow
                        }).ToList()
                    };
                    context.Departments.Add(department);
                    context.SaveChanges();
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }

            }
            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<HashSet<PrisonerImportModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                bool isValid = true;

                if (!IsValid(prisonerDto))
                {
                    isValid = false;
                }

                foreach (var item in prisonerDto.Mails)
                {
                    if (!IsValid(item))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    var prisoner = new Prisoner
                    {
                        FullName = prisonerDto.FullName,
                        Nickname = prisonerDto.Nickname,
                        Age = prisonerDto.Age,
                        IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate = prisonerDto.ReleaseDate != null ? DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : default,
                        Bail = prisonerDto.Bail ?? 0,
                        CellId = prisonerDto.CellId ?? 0,
                    };

                    context.Prisoners.Add(prisoner);

                    prisoner.Mails = prisonerDto.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address,
                        PrisonerId = prisoner.Id
                    }).ToList();

                    context.SaveChanges();
                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }
            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerImportModel[]), new XmlRootAttribute("Officers"));
            var officersDto = (OfficerImportModel[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            foreach (var officerDto in officersDto)
            {
                bool isValid = true;

                if (!IsValid(officerDto) || !Enum.IsDefined(typeof(Position), officerDto.Position) || !Enum.IsDefined(typeof(Weapon), officerDto.Weapon))
                {
                    isValid = false;
                }

                if (isValid)
                {
                    var officer = new Officer
                    {
                        FullName = officerDto.FullName,
                        Salary = officerDto.Salary,
                        Position = (Position)Enum.Parse(typeof(Position), officerDto.Position),
                        Weapon = (Weapon)Enum.Parse(typeof(Weapon), officerDto.Weapon),
                        DepartmentId = officerDto.DepartmentId,
                    };
                    context.Officers.Add(officer);

                    foreach (var item in officerDto.Prisoners)
                    {
                        officer.OfficerPrisoners.Add(new OfficerPrisoner { PrisonerId = item.Id });
                    }

                    sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}