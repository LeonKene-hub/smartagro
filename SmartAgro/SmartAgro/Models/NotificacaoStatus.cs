using System;
using System.Collections.Generic;

namespace SmartAgroAPI.Models;

public partial class NotificacaoStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();
}
