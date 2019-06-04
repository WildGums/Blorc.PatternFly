namespace Blazorc.PatternFly.Components.EmptyState
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class EmptyStateBodyComponent : ComponentBase
    {
        public EmptyStateBodyComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
