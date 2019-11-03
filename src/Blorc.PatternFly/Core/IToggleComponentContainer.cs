// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IToggleComponentContainer.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Core
{
    using System.Collections.Generic;
    using Components.Dropdown;

    public interface IToggleComponentContainer
    {
        List<IToggleComponent> Components { get; }

        void SetActiveToggleComponent(IToggleComponent toggleComponent);
    }
}
