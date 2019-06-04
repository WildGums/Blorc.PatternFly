namespace Blazorc.PatternFly.Components.EmptyState
{
    using Microsoft.AspNetCore.Components;

    public class EmptyStateSecondaryActionsComponent : ComponentBase
    {
        public EmptyStateSecondaryActionsComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
