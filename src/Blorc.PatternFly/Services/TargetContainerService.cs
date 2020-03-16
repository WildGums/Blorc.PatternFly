// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Services
{
    using Blorc.PatternFly.Components.Container;
    using Blorc.PatternFly.Components.List;
    using Blorc.PatternFly.Services.Interfaces;

    using Microsoft.AspNetCore.Components;

    public class TargetContainerService : ITargetContainerService
    {
        public ComponentBase Component { get; set; }

        public void Add(RenderFragment renderFragment)
        {
            ((TargetContainerComponent)Component).RenderFragments.Add(renderFragment);
        }

        public void Remove(RenderFragment renderFragment)
        {
            ((TargetContainerComponent)Component).RenderFragments.Remove(renderFragment);
        }
    }
}
