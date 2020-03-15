// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginationEventArgs.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Components.Pagination
{
    using System;

    public class PaginationStateChangedEventArgs : EventArgs
    {
        public PaginationStateChangedEventArgs(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }

        public int Limit { get; }

        public int Offset { get; }
    }
}
