using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Utils
{
    public static class ApiRoutes
    {
        public static string User { get; } = "user/";
        public static string Login { get; } = User + "login";

        public static string Recover { get; } = User + "recover-password";

        public static string VerifyCode { get; } = User + "verify-code";

        public static string Reset { get; } = User + "reset-password";
       
        public static string Sensor { get; } = "Sensor/";
        public static string SensorPost { get; } = "Sensor";

        public static string HomeRequest { get; } = Sensor + User;

        public static string Notification { get; } = "Notification";
    }
}
