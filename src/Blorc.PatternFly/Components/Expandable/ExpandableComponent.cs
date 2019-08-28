namespace Blorc.PatternFly.Components.Expandable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Blorc.Bindings;
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class ExpandableComponent : BlorcComponentBase
    {
        public ExpandableComponent()
        {
            ToggleText = string.Empty;

            CreateConverter()
                .Fixed("pf-c-expandable")
                .If(() => IsExpanded, "pf-m-expanded")
                .Watch(() => IsExpanded)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string ToggleText
        {
            get { return GetPropertyValue<string>(nameof(ToggleText)); }
            set { SetPropertyValue(nameof(ToggleText), value); }
        }

        [Parameter]
        public bool IsExpanded
        {
            get { return GetPropertyValue<bool>(nameof(IsExpanded)); }
            set { SetPropertyValue(nameof(IsExpanded), value); }
        }

        public bool IsCollapsed
        {
            get { return !IsExpanded; }
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
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }

        protected void OnClick()
        {
            IsExpanded = !IsExpanded;
            var handler = Toggled;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void SetToggleText(string text)
        {
            ToggleText = text;
        }
    }
}
