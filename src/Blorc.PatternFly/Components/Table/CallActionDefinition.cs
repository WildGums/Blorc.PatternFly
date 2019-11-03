// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionDefinition.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Table
{
    using System;

    public class CallActionDefinition : ActionDefinition
    {
        public string Label { get; set; }

        public Action<object> Action { get; set; }

        public string Key { get; set; }

        public bool IsDisabled { get; set; }
    }
}
