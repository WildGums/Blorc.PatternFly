// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceContainerService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Services
{
    using System.Threading.Tasks;

    using Blorc.PatternFly.Components.Container;
    using Blorc.PatternFly.Services.Interfaces;

    using Microsoft.AspNetCore.Components;

    public class SourceContainerService : ISourceContainerService
    {
        private readonly ITargetContainerService _containerService;

        public SourceContainerService(ITargetContainerService containerService)
        {
            _containerService = containerService;
        }

        public ComponentBase Component { get; set; }

        public async Task HideContentAsync()
        {
            _containerService.Remove(((SourceContainer)Component).ChildContent);
        }

        public async Task ShowContentAsync()
        {
            var renderFragment = ((SourceContainer)Component).ChildContent;
            _containerService.Add(renderFragment);
        }
    }
}
