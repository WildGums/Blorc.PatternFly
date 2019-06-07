namespace Blazorc.PatternFly.Components.Button
{
    using System;
    using System.Collections.Generic;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class ButtonComponent : UniqueComponentBase
    {
        public ButtonComponent()
        {
            Component = "button";
            Variant = ButtonVariant.Primary;
            Type = ButtonType.Button;
        }

        public override string ComponentName => "button";

        public string Class
        {
            get
            {
                var items = new List<string>();

                items.Add($"pf-m-{Variant.ToString().ToLower()}");

                if (IsInline)
                {
                    items.Add("pf-m-inline");
                }

                if (IsBlock)
                {
                    items.Add("pf-m-block");
                }

                return string.Join(" ", items);
            }
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsActive { get; set; }

        public bool IsInactive
        {
            get { return !IsActive; }
        }

        [Parameter]
        public bool IsBlock { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsFocus { get; set; }

        [Parameter]
        public bool IsInline { get; set; }

        [Parameter]
        public bool IsHover { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public ButtonVariant Variant { get; set; }

        [Parameter]
        public ButtonType Type { get; set; }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> OnClick { get; set; }
    }
}
