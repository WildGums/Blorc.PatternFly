namespace Blorc.PatternFly.Components.EmptyState
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class EmptyStateSecondaryActionsComponent : BlorcComponentBase
    {
        public EmptyStateSecondaryActionsComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
