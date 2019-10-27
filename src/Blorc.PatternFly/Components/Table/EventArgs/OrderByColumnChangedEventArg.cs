// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortColumnChangedEventArg.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Table.EventArgs
{
    using System;

    public class OrderByColumnChangedEventArg : EventArgs
    {

        public ColumnComponent ColumnComponent { get; }

        public OrderByColumnChangedEventArg(ColumnComponent columnComponent)
        {
            ColumnComponent = columnComponent;
        }
    }
}
