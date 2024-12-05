namespace SmartAgroAPI.Models;

public partial class Sensor
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public DateOnly? DataColheita { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public int CategoriaId { get; set; }

    public decimal? UmidadeSoloIdeal { get; set; }

    public decimal? TemperaturaArIdeal { get; set; }

    public decimal? UmidadeArIdeal { get; set; }

    public decimal? LuminosidadeIdeal { get; set; }

    public decimal? TemperaturaSoloIdeal { get; set; }

    public decimal? PhSoloIdeal { get; set; }

    public Guid UsuarioId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<LogsSensor> LogsSensors { get; set; } = new List<LogsSensor>();

    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();

    public virtual Usuario Usuario { get; set; } = null!;
}
