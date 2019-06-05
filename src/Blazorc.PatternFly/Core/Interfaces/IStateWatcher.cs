namespace Blazorc.PatternFly
{
    using System;

    public interface IStateWatcher : IDisposable
    {
        event EventHandler<EventArgs> StateChanged;
    }
}
