namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    public class NavigationExpandableSectionComponent : ComponentBase, INavigationComponent
    {
        private bool _clicked;

        [Parameter]
        public INavigationComponent Parent { get; set; }

        [Parameter]
        public RenderFragment Items { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        protected bool IsExpanded { get; set; }

        public bool IsCurrent
        {
            get;
            private set;
        }

        public event EventHandler CurrentItemInvalidated;

        public void InvalidateCurrentItem(bool clicked)
        {
            _clicked = clicked;

            Parent.InvalidateCurrentItem(clicked);
        }

        public void MarkBranchAsCurrent()
        {
            if (!IsCurrent)
            {
                IsCurrent = true;
                Parent.MarkBranchAsCurrent();
            }
        }

        protected string GetExpandableNavItemClass()
        {
            return (GetIsExpandedClass() + " " + GetIsCurrentClass()).Trim();
        }

        private string GetIsExpandedClass()
        {
            return IsExpanded ? "pf-m-expanded" : string.Empty;
        }

        private string GetIsCurrentClass()
        {
            return IsCurrent ? "pf-m-current" : string.Empty;
        }

        protected override async Task OnInitAsync()
        {
            Parent.CurrentItemInvalidated += OnCurrentItemInvalidated;
        }

        private void OnCurrentItemInvalidated(object sender, EventArgs e)
        {
            OnInvalidatedCurrent();

            if (!_clicked && IsCurrent)
            {
                IsCurrent = false;
                StateHasChanged();
            }

            _clicked = false;
        }

        protected void Toggle()
        {
            IsExpanded = !IsExpanded;
        }

        protected virtual void OnInvalidatedCurrent()
        {
            CurrentItemInvalidated?.Invoke(this, EventArgs.Empty);
        }
    }
}
