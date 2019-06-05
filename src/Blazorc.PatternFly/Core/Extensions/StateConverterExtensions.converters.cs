namespace Blazorc.PatternFly
{
    using System;

    public static partial class StateConverterContainerExtensions
    {
        public static StateConverterContainer Fixed(this StateConverterContainer container, string value)
        {
            return container.Add(new FixedValueConverter(value));
        }

        public static StateConverterContainer If(this StateConverterContainer container, string value, Func<bool> predicate)
        {
            return container.Add(new PredicateValueConverter(value, predicate));
        }

        public static StateConverterContainer If(this StateConverterContainer container, Func<string> valueFunc, Func<bool> predicate)
        {
            return container.Add(new PredicateValueConverter(valueFunc, predicate));
        }
    }
}
