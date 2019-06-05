namespace Blazorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class CheckboxSelectOptionComponent : BlazorcComponentBase
    {
        public CheckboxSelectOptionComponent()
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
        public string Key { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Clicked { get; set; }
    }
}
