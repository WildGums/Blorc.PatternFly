namespace Blorc.StateConverters
{
    using System;

    public interface IStateUpdater : IDisposable
    {
        void Update(string value);
    }
}
