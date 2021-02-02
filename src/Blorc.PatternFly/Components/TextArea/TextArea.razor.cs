namespace Blorc.PatternFly.Components.TextArea
{
    using Blorc.Components;
    using Core;
    using Microsoft.AspNetCore.Components;

    public partial class TextArea : BlorcComponentBase
    {
        public TextArea()
        {
            IsValid = true;
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsRequired { get; set; }

        [Parameter]
        public bool IsValid { get; set; }

        public bool IsInvalid => !IsValid;

        [Parameter]
        public string Value
        {
            get => GetPropertyValue<string>(nameof(Value));
            set => SetPropertyValue(nameof(Value), value);
        }

        [Parameter]
        public UpdateMode UpdateMode { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
    }
}
