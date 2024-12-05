using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Models.RequestModels
{
    public class ApiRequestVerifyCode
    {
        public required string Email { get; set; }
        public required string Code { get; set; }
    }
}
