// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProgressAsync.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Core
{
    using System.Threading.Tasks;

    public interface IProgressAsync<T>
    {
        Task ReportAsync(T value);
    }
}
