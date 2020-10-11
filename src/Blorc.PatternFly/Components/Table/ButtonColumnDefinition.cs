// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkColumnDefinition.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Components.Table
{
    using System;

    using Blorc.PatternFly.Components.Button;

    public class ButtonColumnDefinition : ColumnDefinition
    {
        public ButtonVariant Variant { get; set; }

        public Action<object> Action { get; set; }
    }
}
