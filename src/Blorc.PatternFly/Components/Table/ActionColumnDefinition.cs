// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionColumnDefinition.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections.Generic;

    public class ActionColumnDefinition : ColumnDefinition
    {
        public Func<object, IEnumerable<ActionDefinition>> ActionSource { get; set; }
    }

    
}
