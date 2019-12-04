// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderState.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Table
{
    public class OrderState
    {
        public OrderState(string key, Order order)
        {
            Key = key;
            Order = order;
        }

        public bool IsSorted => !string.IsNullOrWhiteSpace(Key) && Order != Order.None;

        public string Key { get; }

        public Order Order { get; }

        public bool IsSortedBy(string propertyName)
        {
            return Order != Order.None && Key == propertyName;
        }
    }
}
