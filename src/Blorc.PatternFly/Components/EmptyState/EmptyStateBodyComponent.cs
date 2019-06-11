namespace Blorc.PatternFly.Components.EmptyState
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class EmptyStateBodyComponent : BlorcComponentBase
    {
        public EmptyStateBodyComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
