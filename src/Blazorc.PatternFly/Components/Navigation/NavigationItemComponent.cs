namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Components;

    public class NavigationItemComponent : ComponentBase
    {
        private bool _clicked;

        protected const string NavigationItemCurrentClass = "pf-c-nav__link pf-m-current";

        protected const string NavigationItemNormalClass = "pf-c-nav__link";

        [Inject]
        public IUriHelper UriHelper { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public string Link { get; set; }

        [Parameter]
        public INavigationComponent Parent { get; set; }

        public bool IsCurrent { get; private set; }

        protected override async Task OnInitAsync()
        {
            Parent.CurrentItemInvalidated += OnCurrentItemInvalidated;
        }

        private void OnCurrentItemInvalidated(object sender, EventArgs e)
        {
            if (!_clicked)
            {
                IsCurrent = false;
            }

            _clicked = false;
        }

        protected void OnItemClick()
        {
            _clicked = true;

            Parent.InvalidateCurrentItem(_clicked);
            if (!IsCurrent)
            {
                IsCurrent = true;
                Parent.MarkBranchAsCurrent();
            }

            UriHelper.NavigateTo(Link);
        }
    }
}
