using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Models.RequestModels
{
    public class ApiRequestWeather
    {
        public ApiRequestWeather() 
        {
            
        }

        public Current Current { get; set; }

        public Condition Condition { get; set; }

        public Location Location { get; set; }

    }
}
