namespace Blorc.PatternFly.Components.AlertGroup
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Dynamic;
    using System.Linq;
    using System.Threading;
    using Alert;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AlertGroupContainerComponent : BlorcComponentBase
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        public AlertGroupContainerComponent()
        {
            Items = new List<Notification>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            NotificationService.Notifications.CollectionChanged += NotificationsOnCollectionChanged;
        }

        private void NotificationsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                Items.AddRange(e.NewItems.OfType<Notification>());
                StateHasChanged();
            }
        }

        public List<Notification> Items 
        {
            get => GetPropertyValue<List<Notification>>(nameof(Items));
            set => SetPropertyValue(nameof(Items), value);
        }

        public string PositionClass => NotificationService.Configuration.PositionClass;


    }

  

    public class Notification : BlorcComponentBase
    {
        public AlertType AlertType {
            get => GetPropertyValue<AlertType>(nameof(AlertType));
            set => SetPropertyValue(nameof(AlertType), value);
        }

        public string Description
        {
            get => GetPropertyValue<string>(nameof(Description));
            set => SetPropertyValue(nameof(Description), value);
        }

        public bool ShowCloseIcon
        {
            get => GetPropertyValue<bool>(nameof(ShowCloseIcon));
            set => SetPropertyValue(nameof(ShowCloseIcon), value);
        }

        public int MaximumOpacity
        {
            get => GetPropertyValue<int>(nameof(MaximumOpacity));
            set => SetPropertyValue(nameof(MaximumOpacity), value);
        }

        public int VisibleStateDuration
        {
            get => GetPropertyValue<int>(nameof(VisibleStateDuration));
            set => SetPropertyValue(nameof(VisibleStateDuration), value);
        }

    }
}
