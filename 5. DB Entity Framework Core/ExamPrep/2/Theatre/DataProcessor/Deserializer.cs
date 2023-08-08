namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(PlayImportModel[]), new XmlRootAttribute("Plays"));
            var playsDto = (PlayImportModel[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var listOfPlays = new List<Play>();

            foreach (var playDto in playsDto)
            {
                if (IsValid(playDto))
                {
                    var play = new Play
                    {
                        Title = playDto.Title,
                        Duration = TimeSpan.Parse(playDto.Duration),
                        Rating = playDto.Rating,
                        Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                        Description = playDto.Description,
                        Screenwriter = playDto.Screenwriter
                    };

                    listOfPlays.Add(play);
                    sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
            context.Plays.AddRange(listOfPlays);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CastImportModel[]), new XmlRootAttribute("Casts"));
            var castsDto = (CastImportModel[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var listOfCasts = new List<Cast>();

            foreach (var castDto in castsDto)
            {
                if (IsValid(castDto))
                {
                    var cast = new Cast
                    {
                        FullName = castDto.FullName,
                        IsMainCharacter = castDto.IsMainCharacter,
                        PhoneNumber = castDto.PhoneNumber,
                        PlayId = castDto.PlayId
                    };

                    listOfCasts.Add(cast);
                    sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter == true ? "main" : "lesser"));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
            context.Casts.AddRange(listOfCasts);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theatresDto = JsonConvert.DeserializeObject<HashSet<TheatreImportModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var theatreDto in theatresDto)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    var theatre = new Theatre
                    {
                        Name = theatreDto.Name,
                        NumberOfHalls = theatreDto.NumberOfHalls,
                        Director = theatreDto.Director,
                        Tickets = new HashSet<Ticket>()
                    };
                    context.Theatres.Add(theatre);

                    foreach (var item in theatreDto.Tickets)
                    {
                        if (IsValid(item))
                        {
                            var ticket =  new Ticket
                            {
                                Price = item.Price,
                                RowNumber = item.RowNumber,
                                PlayId = item.PlayId
                            };

                            theatre.Tickets.Add(ticket);
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }
                    sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
                }
            }
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
