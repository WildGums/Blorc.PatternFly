// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IComponentServiceFactoryExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Services.Extensions
{
    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    public static class IComponentServiceFactoryExtensions
    {
        public static void MapBlorcPatternFly(this IComponentServiceFactory @this)
        {
            @this.Map<Modal, ModalUIVisualizationService>();
            @this.Map<PleaseWaitModal, PleaseWaitModalExecutionService>();
        }
    }
}
