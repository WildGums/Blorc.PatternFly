namespace Blazorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class SelectOptionComponent : ComponentBase
    {
        public SelectOptionComponent()
        {

        }

        public string Class
        {
            get
            {
                var items = new List<string>();


                return string.Join(" ", items);
            }
        }

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsPlaceholder { get; set; }

        [Parameter]
        public bool IsSelected { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Clicked { get; set; }
    }
}
