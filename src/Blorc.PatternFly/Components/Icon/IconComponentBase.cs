namespace Blorc.PatternFly.Components.Icon
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.RenderTree;

    public abstract class IconComponentBase : BlorcComponentBase, IIconComponent
    {
        public IconComponentBase()
        {
            Fill = "currentColor";
            Width = "1em";
            Height = "1em";
            Transform = string.Empty;
            Style = "vertical-align: -0.125em;";
        }

        public abstract string Path { get; }

        public abstract string ViewBox { get; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public string Transform { get; set; }

        [Parameter]
        public string Fill { get; set; }

        [Parameter]
        public string Width { get; set; }

        [Parameter]
        public string Height { get; set; }

        [Parameter]
        public string Style { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(1, "svg");

            builder.AddAttribute(2, "class", Class);
            builder.AddAttribute(3, "fill", Fill);
            builder.AddAttribute(4, "height", Height);
            builder.AddAttribute(5, "width", Width);
            builder.AddAttribute(6, "viewBox", ViewBox);
            builder.AddAttribute(7, "aria-hidden", "true");
            builder.AddAttribute(8, "role", "img");
            builder.AddAttribute(9, "style", Style);

            builder.OpenElement(10, "path");
            builder.AddAttribute(11, "d", Path);
            builder.AddAttribute(12, "transform", Transform);
            builder.CloseElement();
            builder.CloseElement();
        }
    }
}
