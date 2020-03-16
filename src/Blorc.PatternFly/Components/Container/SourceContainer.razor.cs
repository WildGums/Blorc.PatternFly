// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceContainer.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Components.Container
{
    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public class SourceContainerComponent : BlorcComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
