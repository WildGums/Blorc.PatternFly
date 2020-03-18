// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataHelper.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Helpers
{
    using System.Collections;

    using Blorc.Reflection;

    public static class DataHelper
    {
        public static object GetValue(object record, string key)
        {
            if (record is IDictionary recordAsDictionary)
            {
                return recordAsDictionary[key];
            }

            return PropertyHelper.GetPropertyValue(record, key);
        }
    }
}
