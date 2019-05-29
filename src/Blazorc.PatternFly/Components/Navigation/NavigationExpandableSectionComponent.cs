namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Components;

    public class NavigationExpandableSectionComponent : ComponentBase, INavigationComponent
    {
        private bool _clicked;

        public const string NavigationExpandableItemExpandedClass = "pf-c-nav__item pf-m-expandable pf-m-expanded";

        public const string NavigationExpandableItemCollapsedClass = "pf-c-nav__item pf-m-expandable";

        public const string NavigationExpandableItemExpandedCurrentClass = "pf-c-nav__item pf-m-expandable pf-m-expanded pf-m-current";

        public const string NavigationExpandableItemCollapsedCurrentClass = "pf-c-nav__item pf-m-expandable pf-m-current";

        [Parameter]
        public INavigationComponent Parent { get; set; }

        [Parameter]
        public RenderFragment Items { get; set; }

        [Parameter]
        public string Title { get; set; }

        protected bool IsExpanded { get; set; }

        public event EventHandler CurrentItemInvalidated;

        protected override async Task OnInitAsync()
        {
            Parent.CurrentItemInvalidated += OnCurrentItemInvalidated;
        }

        private void OnCurrentItemInvalidated(object sender, EventArgs e)
        {
            OnInvalidatedCurrent();

            if (!_clicked)
            {
                IsCurrent = false;
            }

            _clicked = false;
        }


        protected void Toggle()
        {
            IsExpanded = !IsExpanded;
        }

        public bool IsCurrent
        {
            get;
            private set;
        }

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

        protected virtual void OnInvalidatedCurrent()
        {
            CurrentItemInvalidated?.Invoke(this, EventArgs.Empty);
        }
    }
}
