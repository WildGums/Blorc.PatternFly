namespace Blazorc.PatternFly.Components.List
{
    using System;
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
