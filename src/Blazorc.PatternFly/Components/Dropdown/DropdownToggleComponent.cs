namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Blazorc.PatternFly.Bindings;
    using Microsoft.AspNetCore.Components;

    public class DropdownToggleComponent : BlazorcComponentBase, IToggle
    {
        public DropdownToggleComponent()
        {
            Icon = "CaretDown";
        }

        public string Class { get; set; }

        [CascadingParameter]
        public ToggleContainer ContainerToggleContainer { get; set; }

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

        protected override void CreateBindings()
        {
            BindingContext.CreateBinding()
                .From(() => ContainerToggleContainer.IsPlain)
                .To(() => IsPlain)
                .AsMode(BindingMode.OneWay)
                .Apply();

            //// -- OR --

            //BindingContext.AddBinding(new Binding(
            //    new BindingParty(ContainerToggleContainer, nameof(ToggleContainer.IsPlain)),
            //    new BindingParty(this, nameof(IsPlain)),
            //    BindingMode.OneWay));
        }

        //protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == nameof(IsPlain))
        //    {
        //        ForceUpdate();
        //    }
        //}
    }
}
