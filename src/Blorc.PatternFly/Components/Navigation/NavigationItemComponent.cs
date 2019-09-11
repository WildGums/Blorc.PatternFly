namespace Blorc.PatternFly.Components.Navigation
{
    using System;
    using System.Threading.Tasks;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class NavigationItemComponent : BlorcComponentBase
    {
        private bool _clicked;

        protected string GetIsCurrentClass()
        {
            if (IsCurrent)
            {
                return "pf-m-current";
            }

            return string.Empty;
        }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public string Link { get; set; }

        [CascadingParameter]
        public IContainerNavigationComponent ContainerNavigationComponent { get; set; }


        public bool IsCurrent { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            ContainerNavigationComponent.CurrentItemInvalidated += OnCurrentItemInvalidated;
        }

        private void OnCurrentItemInvalidated(object sender, EventArgs e)
        {
            if (!_clicked && IsCurrent)
            {
                IsCurrent = false;
                StateHasChanged();
            }

            _clicked = false;
        }

        protected void OnItemClick()
        {
            _clicked = true;

            ContainerNavigationComponent.InvalidateCurrentItem(_clicked);

            if (!IsCurrent)
            {
                IsCurrent = true;
                ContainerNavigationComponent.MarkBranchAsCurrent();
            }

            NavigationManager.NavigateTo(Link);
        }
    }
}
