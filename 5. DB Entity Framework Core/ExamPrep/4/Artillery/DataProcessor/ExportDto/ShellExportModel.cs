using System.Collections.Generic;

namespace Artillery.DataProcessor.ExportDto
{
    public class ShellExportModel
    {
        public double ShellWeight { get; set; }

        public string Caliber { get; set; }

        public List<GunExportModel> Guns { get; set; }
    }
}
