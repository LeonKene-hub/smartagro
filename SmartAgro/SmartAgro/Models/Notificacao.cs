namespace SmartAgroAPI.Models;

public partial class Notificacao
{
    public int Id { get; set; }

    public string? Mensagem { get; set; }

    public string? Propriedade { get; set; }

    public Guid? LogsSensorId { get; set; }

    public Guid UsuarioId { get; set; }

    public int TipoNotificacaoId { get; set; }

    public DateTime? DataCriacao { get; set; }

    public virtual LogsSensor? LogsSensor { get; set; }

    public virtual NotificacaoStatus TipoNotificacao { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
