namespace Blorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Blorc.Bindings;
    using Blorc.Components;
    using Blorc.PatternFly.Core;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class DropdownToggleComponent : BlorcComponentBase, IToggleComponent
    {
        public DropdownToggleComponent()
        {
            Icon = "CaretDown";

            CreateConverter()
                .Fixed("pf-c-dropdown__toggle")
                .If(() => IsDisabled, "pf-m-disabled")
                .If(() => IsSplitButton, "pf-m-split-button")
                .Watch(() => IsDisabled)
                .Watch(() => IsSplitButton)
                .Update(() => DivClass);

            CreateConverter()
                .If(() => !IsSplitButton, "pf-c-dropdown__toggle")
                .If(() => IsSplitButton, "pf-c-dropdown__toggle-button")
                .If(() => IsPlain, "pf-m-plain")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsSplitButton)
                .Watch(() => IsPlain)
                .Watch(() => IsDisabled)
                .Update(() => ButtonClass);
        }

        public string DivClass { get; set; }

        public string ButtonClass { get; set; }

        public bool IsSplitButton
        {
            get { return SplitButtonItems != null; }
        }

        [CascadingParameter]
        public Dropdown ContainerDropdown { get; set; }

        [Parameter]
        public string Id
        {
            get { return GetPropertyValue<string>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        [Parameter]
        public string Icon
        {
            get { return GetPropertyValue<string>(nameof(Icon)); }
            set { SetPropertyValue(nameof(Icon), value); }
        }

        [Parameter]
        public bool IsOpen
        {
            get { return GetPropertyValue<bool>(nameof(IsOpen)); }
            set { SetPropertyValue(nameof(IsOpen), value); }
        }

        [Parameter]
        public bool IsDisabled
        {
            get { return GetPropertyValue<bool>(nameof(IsDisabled)); }
            set { SetPropertyValue(nameof(IsDisabled), value); }
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
        public bool IsPlain
        {
            get { return GetPropertyValue<bool>(nameof(IsPlain)); }
            set { SetPropertyValue(nameof(IsPlain), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment SplitButtonItems { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }

        protected override void CreateBindings()
        {
            BindingContext.CreateBinding()
                .From(() => ContainerDropdown.IsPlain)
                .To(() => IsPlain)
                .AsMode(BindingMode.OneWay)
                .Apply();

            BindingContext.CreateBinding()
                .From(() => ContainerDropdown.ToggleId)
                .To(() => Id)
                .AsMode(BindingMode.OneWay)
                .Apply();

            //BindingContext.CreateBinding()
            //    .From(() => IsOpen)
            //    .To(() => ContainerDropdown.IsOpen)
            //    .AsMode(BindingMode.OneWay)
            //    .Apply();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            ContainerDropdown.DropDownToggle = this;
        }

        protected void OnClick()
        {
            IsOpen = !IsOpen;
            var handler = Toggled;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Close()
        {
            IsOpen = false;
        }
    }
}
