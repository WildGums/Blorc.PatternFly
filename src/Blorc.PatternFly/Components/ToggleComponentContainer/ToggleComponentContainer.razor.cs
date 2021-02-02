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

    public partial class ToggleComponentContainer : BlorcComponentBase, IToggleComponentContainer
    {
        public event EventHandler<ToggleComponentChangedEventArg> ToogleComponentChanged;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void Register(IToggleComponent toggleComponent)
        {
            toggleComponent.Toggled += Toggled;
        }

        protected virtual void OnToggleComponentChanged(ToggleComponentChangedEventArg e)
        {
            ToogleComponentChanged?.Invoke(this, e);
        }

        private void Toggled(object sender, EventArgs e)
        {
            if (sender is IToggleComponent toggleComponent && toggleComponent.IsOpen)
            {
                OnToggleComponentChanged(new ToggleComponentChangedEventArg(toggleComponent));
            }
        }
    }
}
