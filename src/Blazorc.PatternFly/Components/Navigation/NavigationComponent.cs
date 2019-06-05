namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class NavigationComponent : BlazorcComponentBase, INavigationComponent
    {
        [Parameter]
        public RenderFragment Items { get; set; }

        public event EventHandler CurrentItemInvalidated;

        public void InvalidateCurrentItem(bool clicked)
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
