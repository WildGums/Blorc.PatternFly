namespace Blazorc.PatternFly.Components.List
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class ListItemComponent : BlazorcComponentBase
    {
        public ListItemComponent()
        {

        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
