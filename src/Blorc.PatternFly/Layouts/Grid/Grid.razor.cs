namespace Blorc.PatternFly.Layouts.Grid
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class GridComponent : BlorcComponentBase
    {
        public GridComponent()
        {
            CreateConverter()
                .Fixed("pf-l-grid")
                .Watch(() => IsGutter)
                .If(() => IsGutter, "pf-m-gutter")
                .Update(() => Class);
        }

        public string Class { get; set; }

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
