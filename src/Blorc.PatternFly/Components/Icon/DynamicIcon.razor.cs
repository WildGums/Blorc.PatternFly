namespace Blorc.PatternFly.Components.Icon
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class DynamicIcon : BlorcComponentBase
    {
        public DynamicIcon()
        {

        }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Class { get; set; }

        protected RenderFragment CustomRender;

        private RenderFragment CreateComponent() => builder =>
        {
            var type = Type.GetType($"Blorc.PatternFly.Components.Icon.{Icon}Icon");
            if (type is null)
            {
                builder.AddMarkupContent(0, $"<b>Cannot find icon '{Icon}'</b>");
                return;
            }

            builder.OpenComponent(1, type);

            builder.AddAttribute(2, "Class", Class);

            builder.CloseComponent();
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();

            CustomRender = CreateComponent();
        }
    }
}
