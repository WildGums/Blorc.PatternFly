// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IToggleComponentContainer.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.ToggleComponentContainer
{
    using System;

    using Blorc.Components;
    using Blorc.PatternFly.Core;

    using Microsoft.AspNetCore.Components;

    public class ToggleComponentContainerComponent : BlorcComponentBase, IToggleComponentContainer
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public event EventHandler<ToggleComponentChangedEventArg> ToogleComponentChanged;

        public void Register(IToggleComponent toggleComponent)
        {
            toggleComponent.Toggled += Toggled;
        }

        private void Toggled(object sender, EventArgs e)
        {
            if (sender is IToggleComponent toggleComponent && toggleComponent.IsOpen)
            {
                OnToogleComponentChanged(new ToggleComponentChangedEventArg(toggleComponent));
            }
        }

        protected virtual void OnToogleComponentChanged(ToggleComponentChangedEventArg e)
        {
            ToogleComponentChanged?.Invoke(this, e);
        }
    }
}
