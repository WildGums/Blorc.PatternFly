namespace Blorc.PatternFly.Components.Card
{
    using System;

    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public class CardComponent : BlorcComponentBase
    {
        public CardComponent()
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
                builder.OpenElement(0, Component);
                builder.AddAttribute(1, "class", Class);
                builder.AddAttribute(2, "onmouseover", EventCallback.Factory.Create(this, MouseOver));

                builder.AddContent(3, ChildContent);
                builder.CloseElement();
            };

        protected virtual void MouseOver()
        {
            OnMouseOver?.Invoke(this, EventArgs.Empty);
        }
    }
}
