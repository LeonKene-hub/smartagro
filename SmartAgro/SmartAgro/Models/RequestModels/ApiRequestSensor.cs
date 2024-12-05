using SmartAgroAPI.Models;

namespace SmartAgroAPI.DataTransferObjects
{
    public class ApiRequestSensor
    {

        public ApiRequestSensor()
        {

        }
        public ApiRequestSensor(Sensor sensor)
        {
            SensorId = sensor.Id;
            CategoryId = sensor.CategoriaId;
            UsuarioId = sensor.UsuarioId;
            SensorName = sensor.Nome!;
            TemperaturaArIdeal = sensor.TemperaturaArIdeal;
            UmidadeArIdeal = sensor.UmidadeArIdeal;
            TemperaturaSoloIdeal = sensor.TemperaturaSoloIdeal;
            UmidadeSoloIdeal = sensor.UmidadeSoloIdeal;
            PhSoloIdeal = sensor.PhSoloIdeal;
            LuminosidadeIdeal = sensor.LuminosidadeIdeal;
            DataColheita = sensor.DataColheita;
            Latitude = sensor.Latitude;
            Longitude = sensor.Longitude;
            SensorCategory = sensor.Categoria;

        }
        public int SensorId { get; set; }
        public int CategoryId { get; set; }

        public Guid UsuarioId { get; set; }
        public string? SensorName { get; set; }

        public DateOnly? DataColheita { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? UmidadeSoloIdeal { get; set; }

        public decimal? TemperaturaArIdeal { get; set; }

        public decimal? UmidadeArIdeal { get; set; }

        public decimal? LuminosidadeIdeal { get; set; }

        public decimal? TemperaturaSoloIdeal { get; set; }

        public decimal? PhSoloIdeal { get; set; }

        public virtual List<ApiRequestLogsSensor>? SensorLogs { get; set; } = null;


        public ApiRequestLogsSensor LatestLog
        {
            get
            {
                if (SensorLogs == null) return null!;
                return SensorLogs?.OrderByDescending(x => x.DataAtualizacao).First()!;
            }
        }

        public virtual Categoria? SensorCategory { get; set; }

    }
}
