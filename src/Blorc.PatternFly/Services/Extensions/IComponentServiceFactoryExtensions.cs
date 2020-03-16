// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IComponentServiceFactoryExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Services.Extensions
{
    using Blorc.PatternFly.Components.Container;
    using Blorc.PatternFly.Components.Modal;
    using Blorc.PatternFly.Services.Interfaces;
    using Blorc.Services;

    public static class IComponentServiceFactoryExtensions
    {
        public static void MapBlorcPatternFly(this IComponentServiceFactory @this)
        {
            @this.Map<UIModal, ModalUIVisualizationService>();
            @this.Map<PleaseWaitModal, PleaseWaitModalExecutionService>();

            @this.Map<TargetContainer, ITargetContainerService>();
            @this.Map<SourceContainer, ISourceContainerService>();
        }
    }
}
