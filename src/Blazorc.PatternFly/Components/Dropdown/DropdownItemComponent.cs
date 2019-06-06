namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class DropdownItemComponent : BlazorcComponentBase
    {
        public DropdownItemComponent()
        {
            Component = "a";
            Index = -1;

            CreateConverter()
                .Fixed("pf-c-dropdown__menu-item")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsDisabled)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Component
        {
            get { return GetPropertyValue<string>(nameof(Component)); }
            set { SetPropertyValue(nameof(Component), value); }
        }

        [Parameter]
        public string Key
        {
            get { return GetPropertyValue<string>(nameof(Key)); }
            set { SetPropertyValue(nameof(Key), value); }
        }

        [Parameter]
        public bool IsDisabled
        {
            get { return GetPropertyValue<bool>(nameof(IsDisabled)); }
            set { SetPropertyValue(nameof(IsDisabled), value); }
        }

        [Parameter]
        public bool IsHovered
        {
            get { return GetPropertyValue<bool>(nameof(IsHovered)); }
            set { SetPropertyValue(nameof(IsHovered), value); }
        }

        [Parameter]
        public string Href
        {
            get { return GetPropertyValue<string>(nameof(Href)); }
            set { SetPropertyValue(nameof(Href), value); }
        }

        [Parameter]
        public int Index
        {
            get { return GetPropertyValue<int>(nameof(Index)); }
            set { SetPropertyValue(nameof(Index), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> SelectionChanged { get; set; }
    }
}
