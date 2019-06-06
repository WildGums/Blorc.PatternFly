namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class DropdownToggleCheckboxComponent : BlazorcComponentBase
    {
        public DropdownToggleCheckboxComponent()
        {
            Id = GenerateUniqueId("dropdown-checkbox");

            CreateConverter()
                .Fixed("pf-c-dropdown__toggle-check")
                .Update(() => LabelClass);

            CreateConverter()
                .Fixed("pf-c-dropdown__toggle-check")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsDisabled)
                .Update(() => CheckboxClass);
        }

        public string LabelClass { get; set; }

        public string CheckboxClass { get; set; }

        [Parameter]
        public string Id
        {
            get { return GetPropertyValue<string>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        [Parameter]
        public bool IsValid
        {
            get { return GetPropertyValue<bool>(nameof(IsValid)); }
            set { SetPropertyValue(nameof(IsValid), value); }
        }

        public bool IsInvalid
        {
            get { return !IsValid; }
        }

        [Parameter]
        public bool IsDisabled
        {
            get { return GetPropertyValue<bool>(nameof(IsDisabled)); }
            set { SetPropertyValue(nameof(IsDisabled), value); }
        }

        [Parameter]
        public bool IsChecked
        {
            get { return GetPropertyValue<bool>(nameof(IsChecked)); }
            set { SetPropertyValue(nameof(IsChecked), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> SelectionChanged { get; set; }
    }
}
