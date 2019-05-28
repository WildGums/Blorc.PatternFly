namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Components;

    public class NavigationExpandableSectionComponent : ComponentBase, INavigationComponent
    {
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

        public event EventHandler InvalidatedCurrent;

        protected override async Task OnInitAsync()
        {
            Parent.InvalidatedCurrent += ParentOnInvalidatedCurrent;
        }

        private void ParentOnInvalidatedCurrent(object sender, EventArgs e)
        {
            IsCurrent = false;
            OnInvalidatedCurrent();
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

        public void InvalidateCurrent()
        {
            Parent.InvalidateCurrent();
        }

        public void SetBranchAsCurrent()
        {
            if (!IsCurrent)
            {
                IsCurrent = true;
                Parent.SetBranchAsCurrent();
            }
        }

        protected virtual void OnInvalidatedCurrent()
        {
            InvalidatedCurrent?.Invoke(this, EventArgs.Empty);
        }
    }
}
