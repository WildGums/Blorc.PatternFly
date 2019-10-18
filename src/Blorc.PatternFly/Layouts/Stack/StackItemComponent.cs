namespace Blorc.PatternFly.Layouts.Stack
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class StackItemComponent : BlorcComponentBase
    {
        public StackItemComponent()
        {
            CreateConverter()
                .Fixed("pf-l-stack__item")
                .Watch(() => IsFill)
                .If(() => IsFill, "pf-m-fill")
                .Update(() => Class);
        }

        protected string Class { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public bool IsFill
        {
            get => GetPropertyValue<bool>(nameof(IsFill));
            set => SetPropertyValue(nameof(IsFill), value);
        }
    }
}
