namespace Blazorc.PatternFly.Components.TextArea
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TextAreaComponent : BlazorcComponentBase
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

        public bool IsInvalid
        {
            get { return !IsValid; }
        }

        [Parameter]
        public string Value { get; set; }
    }
}
