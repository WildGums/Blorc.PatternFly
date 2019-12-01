// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IToggleComponentContainer.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.ToggleComponentContainer
{
    using System;

    using Blorc.PatternFly.Components.Dropdown;
    using Blorc.PatternFly.Core;

    public interface IToggleComponentContainer
    {
        // List<IToggleComponent> Components { get; }

        event EventHandler<ToggleComponentChangedEventArg> ToogleComponentChanged;

        // void SetActiveToggleComponent(IToggleComponent toggleComponent);

        void Register(IToggleComponent toggleComponent);
    }
    
    public class ToggleComponentChangedEventArg : EventArgs
    {
        public IToggleComponent ToggleComponent { get; }

        public ToggleComponentChangedEventArg(IToggleComponent toggleComponent)
        {
            ToggleComponent = toggleComponent;
        }
    }
}
