namespace Blazorc.PatternFly
{
    using System;

    public interface IStateUpdater : IDisposable
    {
        void Update(string value);
    }
}
