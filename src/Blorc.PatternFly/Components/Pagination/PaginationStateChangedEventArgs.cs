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
        public PaginationStateChangedEventArgs(int page, int offset, int limit)
        {
            Page = page;
            Offset = offset;
            Limit = limit;
        }

        public int Limit { get; }

        public int Offset { get; }

        public int Page { get; }
    }
}
