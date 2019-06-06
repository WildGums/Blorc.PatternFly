namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class ToggleContainerComponent : BlazorcComponentBase
    {
        public ToggleContainerComponent()
        {
            CreateConverter()
                .Fixed("pf-c-dropdown__toggle")
                .If(() => IsPlain, "pf-m-plain")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsPlain)
                .Watch(() => IsDisabled)
                .Update(() => ButtonClass);
        }

        public string ButtonClass { get; set; }

        [CascadingParameter]
        public Dropdown ContainerDropdown { get; set; }

        [Parameter]
        public string Id
        {
            get { return GetPropertyValue<string>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        [Parameter]
        public bool IsOpen
        {
            get { return GetPropertyValue<bool>(nameof(IsOpen)); }
            set { SetPropertyValue(nameof(IsOpen), value); }
        }

        [Parameter]
        public bool IsFocused
        {
            get { return GetPropertyValue<bool>(nameof(IsFocused)); }
            set { SetPropertyValue(nameof(IsFocused), value); }
        }

        [Parameter]
        public bool IsHovered
        {
            get { return GetPropertyValue<bool>(nameof(IsHovered)); }
            set { SetPropertyValue(nameof(IsHovered), value); }
        }

        [Parameter]
        public bool IsActive
        {
            get { return GetPropertyValue<bool>(nameof(IsActive)); }
            set { SetPropertyValue(nameof(IsActive), value); }
        }

        [Parameter]
        public bool IsDisabled
        {
            get { return GetPropertyValue<bool>(nameof(IsDisabled)); }
            set { SetPropertyValue(nameof(IsDisabled), value); }
        }

        [Parameter]
        public bool IsPlain
        {
            get { return GetPropertyValue<bool>(nameof(IsPlain)); }
            set { SetPropertyValue(nameof(IsPlain), value); }
        }

        [Parameter]
        public bool IsSplitButton
        {
            get { return GetPropertyValue<bool>(nameof(IsSplitButton)); }
            set { SetPropertyValue(nameof(IsSplitButton), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }
    }
}
