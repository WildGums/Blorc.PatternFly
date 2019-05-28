namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class NavigationComponent : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public event EventHandler InvalidatedCurrent;

        protected virtual void OnInvalidatedCurrent()
        {
            InvalidatedCurrent?.Invoke(this, EventArgs.Empty);
        }

        public void InvalidateCurrent()
        {
            OnInvalidatedCurrent();
        }

        public void Refresh()
        {
            StateHasChanged();
        }
    }
}
