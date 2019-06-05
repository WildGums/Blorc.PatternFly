namespace Blazorc.PatternFly.Components.EmptyState
{
    using Microsoft.AspNetCore.Components;

    public class EmptyStateSecondaryActionsComponent : BlazorcComponentBase
    {
        public EmptyStateSecondaryActionsComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
