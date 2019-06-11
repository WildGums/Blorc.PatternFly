namespace Blorc.PatternFly.Components.TextArea
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextAreaComponent : BlorcComponentBase
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
