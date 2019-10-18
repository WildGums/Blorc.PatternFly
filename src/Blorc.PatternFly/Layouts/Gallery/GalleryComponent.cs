namespace Blorc.PatternFly.Layouts.Gallery
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class GalleryComponent : BlorcComponentBase
    {
        public GalleryComponent()
        {
            CreateConverter()
                .Fixed("pf-l-flex")
                .Watch(() => IsGutter)
                .If(() => IsGutter, "pf-m-gutter")
                .Update(() => Class);
        }

        protected string Class { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public bool IsGutter
        {
            get => GetPropertyValue<bool>(nameof(IsGutter));
            set => SetPropertyValue(nameof(IsGutter), value);
        }
    }
}
