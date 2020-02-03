namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using PatternFly.Components.Alert;
    using PatternFly.Components.AlertGroup;

    public class AlertGroupDemoComponent : BlorcComponentBase
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        public AlertGroupDemoComponent()
        {
            if (NotificationService!= null)
            {
                NotificationService.Configuration = new ContainerConfiguration
                {
                    PositionType = AlertGroupContainerPositionType.TopRight
                };
            }
           
        }

        protected async void ShowInfoAlert(object sender, EventArgs eventArgs)
        {
            NotificationService.Configuration.PositionType = AlertGroupContainerPositionType.TopRight;
            var notification = new Notification
            {
                AlertType = AlertType.Info,
                Description = "Info Alert",
                ShowCloseIcon = true
            };
            NotificationService.Notifications.Add(notification);
        }

        protected async void ShowSuccessAlert(object sender, EventArgs eventArgs)
        {
            NotificationService.Configuration.PositionType = AlertGroupContainerPositionType.BottomLeft;
            var notification = new Notification
            {
                AlertType = AlertType.Success,
                Description = "Success Alert",
                ShowCloseIcon = true
            };
            NotificationService.Notifications.Add(notification);
        }

        protected async void ShowDangerAlert(object sender, EventArgs eventArgs)
        {
            var notification = new Notification
            {
                AlertType = AlertType.Danger,
                Description = "Danger Alert",
                ShowCloseIcon = true
            };
            NotificationService.Notifications.Add(notification);
        }

    }
}
