// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISourceContainerService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Services.Interfaces
{
    using System.Threading.Tasks;

    using Blorc.Services;

    public interface ISourceContainerService : IComponentService
    {
        Task HideContentAsync();

        Task ShowContentAsync();
    }
}
