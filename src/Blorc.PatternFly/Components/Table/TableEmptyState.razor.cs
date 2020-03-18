namespace Blorc.PatternFly
{
    using System;

    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public class TableEmptyStateComponent : BlorcComponentBase
    {
        [Parameter]
        public string Body
        {
            get
            {
                return GetPropertyValue<string>(nameof(Body));
            }

            set
            {
                SetPropertyValue(nameof(Body), value);
            }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public RenderFragment Icon
        {
            get
            {
                return builder =>
                {
                    builder.OpenComponent(0, IconType);
                    builder.AddAttribute(1, "Class", "pf-c-empty-state__icon");
                    builder.CloseComponent();
                };
            }
        }

        [Parameter]
        public Type IconType { get; set; }

        [Parameter]
        public string Title
        {
            get
            {
                return GetPropertyValue<string>(nameof(Title));
            }

            set
            {
                SetPropertyValue(nameof(Title), value);
            }
        }
    }
}
