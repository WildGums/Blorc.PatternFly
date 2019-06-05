namespace Blazorc.PatternFly.Components.List
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class ListItemComponent : ComponentBase
    {
        public ListItemComponent()
        {

        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
