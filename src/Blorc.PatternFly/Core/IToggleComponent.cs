// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IToggleComponent.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Core
{
    using System;

    public interface IToggleComponent
    {
        void Close();

        EventHandler<EventArgs> Toggled { get; set; }

        bool IsOpen { get; set; }
    }
}
