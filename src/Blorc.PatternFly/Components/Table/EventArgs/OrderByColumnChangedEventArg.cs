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
        public Column ColumnComponent { get; }

        public OrderByColumnChangedEventArg(Column columnComponent)
        {
            ColumnComponent = columnComponent;
        }
    }
}
