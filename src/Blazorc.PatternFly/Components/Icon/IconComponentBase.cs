namespace Blazorc.PatternFly.Components.Icon
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.RenderTree;

    public abstract class IconComponentBase : ComponentBase
    {
        public IconComponentBase()
        {
            Fill = "currentColor";
            Width = "1em";
            Height = "1em";
            Transform = string.Empty;
        }

        public abstract string Path { get; }

        public abstract string ViewBox { get; }

        public string Transform { get; set; }

        public string Fill { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(1, "svg");

            builder.AddAttribute(2, "fill", Fill);
            builder.AddAttribute(3, "height", Height);
            builder.AddAttribute(4, "width", Width);
            builder.AddAttribute(5, "viewBox", ViewBox);
            builder.AddAttribute(6, "aria-hidden", "true");
            builder.AddAttribute(7, "role", "img");
            builder.AddAttribute(8, "style", "vertical-align: -0.125em;");

            builder.OpenElement(9, "path");
            builder.AddAttribute(10, "d", Path);
            builder.AddAttribute(11, "transform", Transform);
            builder.CloseElement();
            builder.CloseElement();
        }
    }
}
