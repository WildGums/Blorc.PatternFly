namespace Blorc.PatternFly.Components.Text
{
    using System;
    using System.ComponentModel;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextComponent : BlorcComponentBase
    {
        public TextComponent()
        {
            Component = "p";
        }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }
    }
}
