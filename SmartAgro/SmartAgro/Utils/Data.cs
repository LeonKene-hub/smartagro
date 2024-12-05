using SmartAgro.Models.ViewModels;
using SmartAgroAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Utils
{
    public static class Data
    {
        public static ApiRequestUser loggedUser {  get; set; }  

        public static ObservableCollection<ApiRequestSensor> sensorList { get; set; } = new ObservableCollection<ApiRequestSensor>();

        public static DateTime SelectedDate { get; set; } = DateTime.Now;

        public static string primary { get; set; } = "#AFE899";

        public static string secondary { get; } = "#F5F5F5";

        public static ObservableCollection<ApiRequestNotification> notificationList { get; set; } = new ObservableCollection<ApiRequestNotification>();
    }
}
