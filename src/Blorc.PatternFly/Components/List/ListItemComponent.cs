namespace Blorc.PatternFly.Components.List
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class ListItemComponent : BlorcComponentBase
    {
        public ListItemComponent()
        {

        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
