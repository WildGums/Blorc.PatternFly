namespace Blorc.PatternFly.Components.Navigation
{
    using System;

    public interface IContainerNavigationComponent
    {
        event EventHandler CurrentItemInvalidated;

        void InvalidateCurrentItem(bool clicked);

        void MarkBranchAsCurrent();
    }
}
