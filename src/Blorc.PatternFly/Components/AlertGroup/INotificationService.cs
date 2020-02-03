namespace Blorc.PatternFly.Components.AlertGroup
{
    using System.Collections.ObjectModel;

    public interface INotificationService
    {
        ObservableCollection<Notification> Notifications { get; }

        ContainerConfiguration Configuration { get; set; }
    }
}
