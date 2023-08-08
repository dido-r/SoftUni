using System.Collections.Generic;

namespace Footballers.DataProcessor.ExportDto
{
    public class TeamExportModel
    {
        public string Name { get; set; }
        public List<FootballerExportModel> Footballers { get; set; }
    }
}
