namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class DropdownToggleComponent : ComponentBase, IToggle
    {
        public DropdownToggleComponent()
        {
            Icon = "CaretDown";
        }

        public string Class
        {
            get
            {
                var items = new List<string>();

                //if (IsRead)
                //{
                //    items.Add("pf-m-read");
                //}
                //else
                //{
                //    items.Add("pf-m-unread");
                //}

                return string.Join(" ", items);
            }
        }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsFocused { get; set; }

        [Parameter]
        public bool IsHovered { get; set; }

        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public bool IsPlain { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment SplitButtonItems { get; set; }
    }
}
