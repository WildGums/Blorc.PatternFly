namespace Blorc.PatternFly.Components.Navigation
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class NavigationComponent : BlorcComponentBase, IContainerNavigationComponent
    {
        [Parameter]
        public RenderFragment Items { get; set; }

        public event EventHandler CurrentItemInvalidated;

        public void InvalidateCurrentItem()
        {
            OnInvalidatedCurrent();
        }

        public void MarkBranchAsCurrent()
        {
            StateHasChanged();
        }

        protected virtual void OnInvalidatedCurrent()
        {
            CurrentItemInvalidated?.Invoke(this, EventArgs.Empty);
        }
    }
}
