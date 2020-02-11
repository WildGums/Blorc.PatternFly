namespace Blorc.PatternFly.Layouts.Split
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class SplitItemComponent : BlorcComponentBase
    {
        public SplitItemComponent()
        {
            CreateConverter()
                .Fixed("pf-l-split__item")
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
