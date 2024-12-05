using SmartAgro.Models;
using SmartAgroAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.ViewModels
{
    public partial class SensorViewModel
    {
        public SensorViewModel()
        {
            
        }

        public SensorViewModel(ApiRequestSensor requestSensor, DateTime date) 
        {
            SensorInfo UmidadeArIdeal = new SensorInfo()
            {
                Nome = "Umidade do ar",
                NivelAtual = (decimal)requestSensor.SensorLogs!.FirstOrDefault(x => x.DataAtualizacao!.Value.Date == date.Date)!.UmidadeAr!,
                NivelIdeal = (decimal)requestSensor.UmidadeArIdeal!,
                Icon = "\xf043;",
                Color = "#8BC9EE",
                Logs = requestSensor!.SensorLogs!.Where(x=> x.DataAtualizacao!.Value.Date == date.Date).Select(x => new ChartModel((decimal)x.UmidadeAr!, x.DataAtualizacao!.Value)).ToList()
            };
            Sensors.Add(UmidadeArIdeal);

            SensorInfo UmidadeSoloIdeal = new SensorInfo()
            {
                Nome = "Umidade do solo",
                NivelAtual = (decimal)requestSensor.SensorLogs.FirstOrDefault(x => x.DataAtualizacao.Value.Date == date.Date)!.UmidadeSolo!,
                NivelIdeal = (decimal)requestSensor.UmidadeSoloIdeal!,
                Icon = "\xf043",
                Color = "#8BC9EE",
                Logs = requestSensor!.SensorLogs!.Where(x => x.DataAtualizacao!.Value.Date == date.Date).Select(x => new ChartModel((decimal)x.UmidadeSolo!, x.DataAtualizacao!.Value)).ToList()
            };
            Sensors.Add(UmidadeSoloIdeal);

            SensorInfo TemperaturaArIdeal = new SensorInfo()
            {
                Nome = "Temperatura do ar",
                NivelAtual = (decimal)requestSensor.SensorLogs.FirstOrDefault(x => x.DataAtualizacao.Value.Date == date.Date)!.TemperaturaAr!,
                NivelIdeal = (decimal)requestSensor.TemperaturaArIdeal!,
                Icon = "\xf72e;",
                Color = "#EC7474",
                Logs = requestSensor!.SensorLogs!.Where(x => x.DataAtualizacao!.Value.Date == date.Date).Select(x => new ChartModel((decimal)x.TemperaturaAr!, x.DataAtualizacao!.Value)).ToList()
            };
            Sensors.Add(TemperaturaArIdeal);

            SensorInfo TemperaturaSoloIdeal = new SensorInfo()
            {
                Nome = "Temperatura do solo",
                NivelAtual = (decimal)requestSensor.SensorLogs.FirstOrDefault(x => x.DataAtualizacao.Value.Date == date.Date)!.TemperaturaSolo!,
                NivelIdeal = (decimal)requestSensor.TemperaturaSoloIdeal!,
                Icon = "\xf2c9;",
                Color = "#EC7474",
                Logs = requestSensor!.SensorLogs!.Where(x => x.DataAtualizacao!.Value.Date == date.Date).Select(x => new ChartModel((decimal)x.TemperaturaSolo!, x.DataAtualizacao!.Value)).ToList()
            };
            Sensors.Add(TemperaturaSoloIdeal);

            SensorInfo PhSoloIdeal = new SensorInfo()
            {
                Nome = "Ph do solo",
                NivelAtual = (decimal)requestSensor.SensorLogs.FirstOrDefault(x => x.DataAtualizacao.Value.Date == date.Date)!.PhSolo!,
                NivelIdeal = (decimal)requestSensor.PhSoloIdeal!,
                Icon = "pH",
                Color = "#C4A02B",
                Logs = requestSensor!.SensorLogs!.Where(x => x.DataAtualizacao!.Value.Date == date.Date).Select(x => new ChartModel((decimal)x.PhSolo!, x.DataAtualizacao!.Value)).ToList()
            };
            Sensors.Add(PhSoloIdeal);

            SensorInfo QualidadeAr = new SensorInfo()
            {
                Nome = "Qualidade do ar",
                NivelAtual = (decimal)requestSensor.SensorLogs.FirstOrDefault(x => x.DataAtualizacao.Value.Date == date.Date)!.QualidadeAr!,
                NivelIdeal = 200,
                Icon = "\x2600;",
                Color = "#8BC9EE",
                Logs = requestSensor!.SensorLogs!.Where(x => x.DataAtualizacao!.Value.Date == date.Date).Select(x => new ChartModel((decimal)x.QualidadeAr!, x.DataAtualizacao!.Value)).ToList()
            };
            Sensors.Add(QualidadeAr);

            SensorInfo LuminosidadeIdeal = new SensorInfo()
            {
                Nome = "Luminosidade",
                NivelAtual = (decimal)requestSensor.SensorLogs.FirstOrDefault(x => x.DataAtualizacao.Value.Date == date.Date)!.Luminosidade!,
                NivelIdeal = (decimal)requestSensor.LuminosidadeIdeal!,
                Icon = "\x2600;",
                Color = "#ECA674",
                Logs = requestSensor!.SensorLogs!.Where(x => x.DataAtualizacao!.Value.Date == date.Date).Select(x => new ChartModel((decimal)x.Luminosidade!, x.DataAtualizacao!.Value)).ToList()
            };
            Sensors.Add(LuminosidadeIdeal);
        }

        public ObservableCollection<SensorInfo> Sensors { get; set; } = new ObservableCollection<SensorInfo>();
    }
}
