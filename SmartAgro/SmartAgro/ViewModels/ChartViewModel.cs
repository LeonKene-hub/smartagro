using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Models
{
    public class ChartViewModel
    {
        public List<ChartModel> DataChart { get; set; } = new List<ChartModel>();

        public ChartViewModel()
        {
            
        }

        public ChartViewModel( List<ChartModel> charts )
        {
            foreach( var item in charts ) 
            { 
                DataChart.Add(item);
            }
        }
    }
}
