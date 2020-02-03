namespace Blorc.PatternFly.Components.AlertGroup
{
    using System;
    using System.Collections.ObjectModel;

    public class NotificationService : INotificationService
    {
        public ContainerConfiguration Configuration { get; set; }

        public NotificationService()
        {
            Configuration = new ContainerConfiguration();
        }

        public ObservableCollection<Notification> Notifications { get; } = new ObservableCollection<Notification>();

    }
}
