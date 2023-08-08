using System.Collections.Generic;

namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonerOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public List<OfficerOutputModel> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
