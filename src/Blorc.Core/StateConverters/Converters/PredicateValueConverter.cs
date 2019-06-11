namespace Blorc.StateConverters
{
    using System;

    public class PredicateValueConverter : StateConverterBase
    {
        public PredicateValueConverter(Func<string> valueFunc, Func<bool> predicate)
            : base(valueFunc, predicate)
        {
        }

        public PredicateValueConverter(string value, Func<bool> predicate)
            : base(() => value, predicate)
        {
        }
    }
}
