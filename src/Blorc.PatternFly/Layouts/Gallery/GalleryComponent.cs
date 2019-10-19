﻿namespace Blorc.PatternFly.Layouts.Gallery
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class LevelComponent : BlorcComponentBase
    {
        public LevelComponent()
        {
            CreateConverter()
                .Fixed("pf-l-gallery")
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
