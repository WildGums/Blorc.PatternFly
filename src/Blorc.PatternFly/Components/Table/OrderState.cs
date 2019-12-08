// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderState.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Table
{
    using System.Collections;
    using System.Collections.Generic;

    public class OrderState
    {
        public OrderState(string key, Order order, IComparer comparer)
        {
            Key = key;
            Order = order;
            Comparer = Comparer<object>.Create((o1, o2) => comparer.Compare(o1, o2)) ?? Comparer<object>.Default;
        }

        public bool IsSorted => !string.IsNullOrWhiteSpace(Key) && Order != Order.None;

        public string Key { get; }

        public Order Order { get; }

        public IComparer<object> Comparer { get; }

        public bool IsSortedBy(string propertyName)
        {
            return Order != Order.None && Key == propertyName;
        }
    }
}
