﻿namespace Blorc.PatternFly.Components.TextInput
{
    using System;
    using Blorc.Components;
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

        public bool IsInvalid
        {
            get { return !IsValid; }
        }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsReadOnly { get; set; }

        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public string Value { get; set; }
    }
}