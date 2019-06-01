// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentService.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blazorc.PatternFly.Services
{
    using System.Threading.Tasks;
    using Interop;

    public interface IDocumentService
    {
        Task<Rect> GetBoundingClientRectById(string id);

        Task<Rect> GetOffsetBoundingClientRect(long x, long y);

        Task<Rect> GetBoundingClientRect(long x, long y);
    }
}
