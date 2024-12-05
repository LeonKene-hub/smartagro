namespace SmartAgroAPI.Models;

public partial class Usuario
{
    public Guid Id { get; set; }

    public bool IsAdmin { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? CodigoVerificacao { get; set; }

    public DateTime? ExpiracaoCodigo { get; set; }

    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
