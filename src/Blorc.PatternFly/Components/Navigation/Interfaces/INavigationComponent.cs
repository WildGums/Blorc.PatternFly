namespace Blorc.PatternFly.Components.Navigation
{
    using System;

    public interface INavigationComponent
    {
        event EventHandler CurrentItemInvalidated;

        void InvalidateCurrentItem(bool clicked);

        void MarkBranchAsCurrent();
    }
}
