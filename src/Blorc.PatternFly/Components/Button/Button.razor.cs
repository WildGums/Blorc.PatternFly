namespace Blorc.PatternFly.Components.Button
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;

    public partial class Button : UniqueComponentBase
    {
        public Button()
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

        protected RenderFragment CustomRender;

        protected void OnButtonClicked(MouseEventArgs e)
        {
            var handler = OnClick;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private RenderFragment CreateComponent() => builder =>
        {
            int idx = 0;
            builder.OpenElement(idx++, Component);

            if (Component == "button")
            {
                builder.AddAttribute(idx++, "type", Type.ToString().ToLower());
            }

            builder.AddAttribute(idx++, "class", $"pf-c-button {Class}");
            builder.AddAttribute(idx++, "disabled", IsDisabled);
            if (OnClick != null)
            {
                builder.AddAttribute(idx++, "onclick", new EventCallback<MouseEventArgs>(this, new Action<MouseEventArgs>(OnButtonClicked)));
            }

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(idx++, "href", Href);
                builder.AddAttribute(idx++, "target", "_blank");
            }

            builder.AddContent(idx, ChildContent);
            builder.CloseElement();
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();

            CustomRender = CreateComponent();
        }
    }
}
