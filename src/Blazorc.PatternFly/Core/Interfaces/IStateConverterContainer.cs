namespace Blazorc.PatternFly
{
    using System;

    public interface IStateConverterContainer : IDisposable
    {
        void MarkDirty();
    }
}
