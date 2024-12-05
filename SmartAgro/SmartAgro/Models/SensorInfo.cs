using SmartAgroAPI.DataTransferObjects;
using SmartAgroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Models
{
    public partial class SensorInfo
    {
        public string Nome { get; set; }

        public decimal NivelAtual { get; set; }

        public decimal NivelIdeal { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public List<ChartModel>? Logs { get; set; } = null;
    }
}
