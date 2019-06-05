namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    public class NavigationItemComponent : BlazorcComponentBase
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
