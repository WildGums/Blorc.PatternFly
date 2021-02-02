namespace Blorc.PatternFly.Components.EmptyState
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class EmptyStateSecondaryActions : BlorcComponentBase
    {
        public EmptyStateSecondaryActions()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
