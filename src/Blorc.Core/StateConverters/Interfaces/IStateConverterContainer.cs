namespace Blorc.StateConverters
{
    using System;

    public interface IStateConverterContainer : IDisposable
    {
        void MarkDirty();
    }
}
