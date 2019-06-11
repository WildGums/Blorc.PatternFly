namespace Blorc.PatternFly.Components.EmptyState
{
    using System;
    using Blorc.Components;
    using Blorc.PatternFly.Components.Icon;
    using Microsoft.AspNetCore.Components;

    public class EmptyStateIconComponent : BlorcComponentBase
    {
        public EmptyStateIconComponent()
        {

        }

        [Parameter]
        public string Icon { get; set; }
    }
}
