// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToggleComponentChangedEventArg.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.ToggleComponentContainer
{
    using System;

    using Blorc.PatternFly.Core;

    public class ToggleComponentChangedEventArg : EventArgs
    {
        public IToggleComponent ToggleComponent { get; }

        public ToggleComponentChangedEventArg(IToggleComponent toggleComponent)
        {
            ToggleComponent = toggleComponent;
        }
    }
}
