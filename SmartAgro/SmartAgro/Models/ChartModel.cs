using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Models
{
    public partial class ChartModel
    {
        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public ChartModel(decimal value, DateTime date)
        {
            Value = value;
            Date = date;
        }
    }
}
