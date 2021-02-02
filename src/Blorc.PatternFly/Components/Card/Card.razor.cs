namespace Blorc.PatternFly.Components.Card
{
    using System;

    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class Card : BlorcComponentBase
    {
        public Card()
        {
            Component = "article";

            CreateConverter()
                .Fixed("pf-c-card")
                .If(() => IsHoverable, "pf-m-hoverable")
                .Watch(() => IsHoverable)
                .Update(() => Class);
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public bool IsHoverable { get; set; }

        [Parameter]
        public EventHandler OnMouseOver { get; set; }

        protected RenderFragment CreateComponent() =>
            builder =>
            {
                var idx = 0;
                builder.OpenElement(idx++, Component);
                builder.AddAttribute(idx++, "class", Class);
                builder.AddAttribute(idx++, "onmouseover", EventCallback.Factory.Create(this, MouseOver));
                if (AdditionalAttributes != null && AdditionalAttributes.TryGetValue("style", out var style))
                {
                    builder.AddAttribute(idx++, "style", style);
                }

                builder.AddContent(idx, ChildContent);
                builder.CloseElement();
            };

        protected virtual void MouseOver()
        {
            OnMouseOver?.Invoke(this, EventArgs.Empty);
        }
    }
}
