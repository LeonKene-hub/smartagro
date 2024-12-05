using SmartAgroAPI.Models;

namespace SmartAgroAPI.DataTransferObjects
{
    public class ApiRequestNotificationCreation
    {

        public ApiRequestNotificationCreation(Notificacao notificacao)
        {
            Mensagem = notificacao.Mensagem;
            Propriedade = notificacao.Propriedade;
            LogsSensorId = notificacao.LogsSensorId;
            UsuarioId = notificacao.UsuarioId;
            TipoNotificacaoId = notificacao.TipoNotificacaoId;
        }
        public string? Mensagem { get; set; }

        public string? Propriedade { get; set; }

        public Guid? LogsSensorId { get; set; }

        public Guid UsuarioId { get; set; }

        public int TipoNotificacaoId { get; set; }



    }
}
