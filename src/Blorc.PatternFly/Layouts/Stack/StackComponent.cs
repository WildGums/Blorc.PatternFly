namespace Blorc.PatternFly.Layouts.Stack
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class StackComponent : BlorcComponentBase
    {
        public StackComponent()
        {
            CreateConverter()
                .Fixed("pf-l-stack")
                .Watch(() => IsGutter)
                .If(() => IsGutter, "pf-m-gutter")
                .Update(() => Class);
        }

        protected string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool IsGutter
        {
            get => GetPropertyValue<bool>(nameof(IsGutter));
            set => SetPropertyValue(nameof(IsGutter), value);
        }
    }
}
