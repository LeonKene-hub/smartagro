using CommunityToolkit.Mvvm.ComponentModel;
using SmartAgro.Models.ViewModels;
using SmartAgro.Utils;

namespace SmartAgro.ViewModels
{
    public partial class NotificationViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? mensagem;

        [ObservableProperty]
        private string? propriedade;

        [ObservableProperty]
        private Guid logsSensorId;

        [ObservableProperty]
        private Guid usuarioId = Data.loggedUser.Id;

        [ObservableProperty]
        private int? tipoNotificacaoId;

        [ObservableProperty]
        public DateTime? dataCriacao;

    }
}
