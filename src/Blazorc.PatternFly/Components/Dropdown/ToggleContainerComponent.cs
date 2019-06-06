namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Blazorc.PatternFly.Bindings;
    using Microsoft.AspNetCore.Components;

    public class ToggleContainerComponent : BlazorcComponentBase
    {
        public ToggleContainerComponent()
        {
            CreateConverter()
                .Fixed("pf-c-dropdown__toggle")
                .If(() => IsDisabled, "pf-m-disabled")
                .If(() => IsSplitButton, "pf-m-split-button")
                .Watch(() => IsDisabled)
                .Watch(() => IsSplitButton)
                .Update(() => Class);

            CreateConverter()
                .Fixed("pf-c-dropdown__toggle")
                .If(() => IsPlain, "pf-m-plain")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsPlain)
                .Watch(() => IsDisabled)
                .Update(() => ButtonClass);
        }

        public string Class { get; set; }

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

        public bool IsSplitButton
        {
            get { return SplitButtonItems != null; }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment SplitButtonItems { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }
    }
}
