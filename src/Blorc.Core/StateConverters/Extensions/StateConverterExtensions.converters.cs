namespace Blorc.StateConverters
{
    using System;

    public static partial class StateConverterContainerExtensions
    {
        public static StateConverterContainer Fixed(this StateConverterContainer container, string value)
        {
            return container.Add(new FixedValueConverter(value));
        }

        public static StateConverterContainer If(this StateConverterContainer container, Func<bool> predicate, string value)
        {
            return container.Add(new PredicateValueConverter(value, predicate));
        }

        public static StateConverterContainer If(this StateConverterContainer container, Func<bool> predicate, Func<string> valueFunc)
        {
            return container.Add(new PredicateValueConverter(valueFunc, predicate));
        }
    }
}
