namespace Blorc.StateConverters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FixedValueConverter : IStateConverter
    {
        private readonly string _fixedValue;

        public FixedValueConverter(string fixedValue)
        {
            _fixedValue = fixedValue;
        }

        public void Dispose()
        {
            // not required
        }

        public string GetValue()
        {
            return _fixedValue;
        }
    }
}
