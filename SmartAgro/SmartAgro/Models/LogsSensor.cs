namespace SmartAgroAPI.Models;

/// <summary>
/// A log object that contain all the sensor fields. The log is based in the time that was created.
/// </summary>
public partial class LogsSensor
{
    public Guid? Id { get; set; }

    public int? SensorId { get; set; }

    public decimal? UmidadeSolo { get; set; }

    public decimal? TemperaturaAr { get; set; }

    public decimal? UmidadeAr { get; set; }

    public decimal? Luminosidade { get; set; }

    public decimal? TemperaturaSolo { get; set; }

    public decimal? QualidadeAr { get; set; }

    public decimal? PhSolo { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public virtual Sensor? Sensor { get; set; }

    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();
}
