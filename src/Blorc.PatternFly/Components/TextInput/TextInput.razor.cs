namespace Blorc.PatternFly.Components.TextInput
{
    using System;
    using System.ComponentModel;
    using Blorc.Components;
    using Core;
    using Microsoft.AspNetCore.Components;

    public class TextInputComponent : BlorcComponentBase
    {
        public TextInputComponent()
        {
            IsValid = true;
            Type = "text";
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsRequired { get; set; }

        [Parameter]
        public bool IsValid { get; set; }

        public bool IsInvalid => !IsValid;

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsReadOnly { get; set; }

        [Parameter]
        public string Type { get; set; }

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

        public void Clear()
        {
            Value = string.Empty;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(Value))
            {
                ValueChanged.InvokeAsync(Value);
            }
        }
    }
}
