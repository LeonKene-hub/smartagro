using SmartAgroAPI.Models;

namespace SmartAgroAPI.ViewModels
{
    /// <summary>
    /// Class to return the notifications group based in data
    /// </summary>
    public class NotificationGroupViewModel : List<Notificacao>
    {
        /// <summary>
        /// Field that contain the group name
        /// </summary>
        public string GroupTitle { get; private set; }

        /// <summary>
        /// Instantiate the notifications group based in the title
        /// </summary>
        /// <param name="groupTitle">Group name</param>
        /// <param name="notifications">Grouped notifications</param>
        public NotificationGroupViewModel(string groupTitle, List<Notificacao> notifications) : base(notifications)
        {
            GroupTitle = groupTitle;
        }
    }
}
