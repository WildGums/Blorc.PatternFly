namespace Blorc.PatternFly.Layouts.Grid
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class GridItemComponent : BlorcComponentBase
    {
        public GridItemComponent()
        {
            CreateConverter()
                .Fixed("pf-l-grid__item")
                .Watch(() => ColSpan)
                .Watch(() => RowSpan)
                .If(() => ColSpan >= 2, () => $"pf-m-{ColSpan}-col")
                .If(() => RowSpan >= 2, () => $"pf-m-{RowSpan}-row")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public int ColSpan
        {
            get { return GetPropertyValue<int>(nameof(ColSpan)); }
            set { SetPropertyValue(nameof(ColSpan), value); }
        }

        [Parameter]
        public int RowSpan
        {
            get { return GetPropertyValue<int>(nameof(RowSpan)); }
            set { SetPropertyValue(nameof(RowSpan), value); }
        }
    }
}
