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
                .Watch(() => IsFilled)
                .If(() => IsFilled, "pf-m-fill")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool IsFilled
        {
            get => GetPropertyValue<bool>(nameof(IsFilled));
            set => SetPropertyValue(nameof(IsFilled), value);
        }
    }
}
