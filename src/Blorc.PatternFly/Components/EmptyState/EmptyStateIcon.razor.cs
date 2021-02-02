namespace Blorc.PatternFly.Components.EmptyState
{
    using System;
    using Blorc.Components;
    using Blorc.PatternFly.Components.Icon;
    using Microsoft.AspNetCore.Components;

    public partial class EmptyStateIcon : BlorcComponentBase
    {
        public EmptyStateIcon()
        {

        }

        [Parameter]
        public string Icon { get; set; }
    }
}
