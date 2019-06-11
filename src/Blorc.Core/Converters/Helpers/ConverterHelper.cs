namespace Blorc.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ConverterHelper
    {
        private static readonly object _unsetValue = new object();

        public static object UnsetValue { get { return _unsetValue; } }
    }
}
