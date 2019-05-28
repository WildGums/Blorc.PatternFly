namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using Interfaces;
    using Microsoft.AspNetCore.Components;

    public class NavigationComponent : ComponentBase, INavigationComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public event EventHandler InvalidatedCurrent;

        public void InvalidateCurrent()
        {
            OnInvalidatedCurrent();
        }

        public void SetBranchAsCurrent()
        {
            StateHasChanged();
        }

        protected virtual void OnInvalidatedCurrent()
        {
            InvalidatedCurrent?.Invoke(this, EventArgs.Empty);
        }
    }
}
