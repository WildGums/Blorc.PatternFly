namespace Blorc.PatternFly.Components.InputGroup
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class InputGroupTextComponent : BlorcComponentBase
    {
        protected RenderFragment CustomRender { get; private set; }

        public InputGroupTextComponent()
        {
            Component = "span";
        }

        [Parameter] public string Component { get; set; }

        [Parameter] public string Label { get; set; }

        [Parameter] public string HtmlFor { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        private RenderFragment CreateComponent()
        {
            return builder =>
            {
                builder.OpenElement(0, Component);
                builder.AddAttribute(1, "class", "pf-c-input-group__text");
                builder.AddAttribute(2, "aria-label", Label);

                if (!string.IsNullOrWhiteSpace(HtmlFor))
                {
                    builder.AddAttribute(2, "htmlFor", HtmlFor);
                }

                builder.AddContent(2, ChildContent);
                builder.CloseElement();
            };
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            CustomRender = CreateComponent();
        }
    }
}
