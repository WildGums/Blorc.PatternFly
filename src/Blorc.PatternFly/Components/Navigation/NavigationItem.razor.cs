namespace Blorc.PatternFly.Components.Navigation
{
    using System;
    using System.Threading.Tasks;
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Routing;

    public partial class NavigationItem : BlorcComponentBase
    {
        public NavigationItem()
        {
            CreateConverter()
                .Fixed("pf-c-nav__link")
                .If(() => IsCurrent, "pf-m-current")
                .Watch(() => IsCurrent)
                .Update(() => Class);
        }

        public string Class
        {
            get { return GetPropertyValue<string>(nameof(Class)); }
            set { SetPropertyValue(nameof(Class), value); }
        }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Link { get; set; }

        [CascadingParameter]
        public IContainerNavigationComponent ContainerNavigationComponent { get; set; }


        public bool IsCurrent
        {
            get { return GetPropertyValue<bool>(nameof(IsCurrent)); }
            set { SetPropertyValue(nameof(IsCurrent), value); }
        }

        protected override async Task OnInitializedAsync()
        {
            ContainerNavigationComponent.CurrentItemInvalidated += OnCurrentItemInvalidated;
            if (ContainerNavigationComponent.IsSynchronized)
            {
                NavigationManager.LocationChanged += NavigationManagerOnLocationChanged;
                if (NavigationManager.Uri.EndsWith(Link))
                {
                    SetAsCurrent();
                }
            }
        }

        private void NavigationManagerOnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            if (e.Location.EndsWith(Link))
            {
                SetAsCurrent();
            }
        }

        private void OnCurrentItemInvalidated(object sender, EventArgs e)
        {
            if (IsCurrent)
            {
                IsCurrent = false;
            }
        }

        protected void OnItemClick()
        {
            if (!ContainerNavigationComponent.IsSynchronized)
            {
                SetAsCurrent();
            }

            NavigationManager.NavigateTo(Link);
        }

        private void SetAsCurrent()
        {
            ContainerNavigationComponent.InvalidateCurrentItem();
            if (!IsCurrent)
            {
                IsCurrent = true;
                ContainerNavigationComponent.MarkBranchAsCurrent();
            }
        }
    }
}
