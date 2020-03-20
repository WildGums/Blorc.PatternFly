// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataHelper.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Helpers
{
    using System;
    using System.Collections;

    using Blorc.Reflection;

    public static class DataHelper
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="record">
        /// The record.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static object GetValue(object record, string key)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (record is IDictionary recordAsDictionary)
            {
                return recordAsDictionary[key];
            }

            return PropertyHelper.GetPropertyValue(record, key);
        }
    }
}
