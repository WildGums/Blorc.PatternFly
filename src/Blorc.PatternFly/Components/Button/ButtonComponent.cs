namespace Blorc.PatternFly.Components.Button
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
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
        public EventCallback<UIMouseEventArgs> OnClick { get; set; }

        protected RenderFragment CustomRender;

        private RenderFragment CreateComponent() => builder =>
        {
            builder.OpenElement(0, Component);

            if (Component == "button")
            {
                builder.AddAttribute(1, "type", Type.ToString().ToLower());
            }

            builder.AddAttribute(2, "class", $"pf-c-button {Class}");
            builder.AddAttribute(3, "disabled", IsDisabled);
            builder.AddAttribute(4, "onclick", OnClick);

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(5, "href", Href);
                builder.AddAttribute(6, "target", "_blank");
            }

            builder.AddContent(7, ChildContent);
            builder.CloseElement();
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();

            CustomRender = CreateComponent();
        }
    }
}
