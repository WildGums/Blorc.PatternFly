namespace Blorc.PatternFly.Components.EmptyState
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class EmptyStateBody : BlorcComponentBase
    {
        public EmptyStateBody()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
