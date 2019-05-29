// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationComponent.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blazorc.PatternFly.Components.Navigation.Interfaces
{
    using System;

    public interface INavigationComponent
    {
        event EventHandler CurrentItemInvalidated;

        void InvalidateCurrentItem(bool clicked);

        void MarkBranchAsCurrent();
    }
}
