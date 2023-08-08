using System.Collections.Generic;

namespace Theatre.DataProcessor.ExportDto
{
    public class TheatreExportModel
    {
        public string Name { get; set; }

        public sbyte Halls { get; set; }

        public decimal TotalIncome { get; set; }

        public List<TicketExportModel> Tickets { get; set; }
    }
}
