namespace Blazorc.PatternFly.Components.TextArea
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TextAreaComponent : ComponentBase
    {
        public TextAreaComponent()
        {
            IsValid = true;
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsRequired { get; set; }

        [Parameter]
        public bool IsValid { get; set; }

        [Parameter]
        public string Value { get; set; }
    }
}
