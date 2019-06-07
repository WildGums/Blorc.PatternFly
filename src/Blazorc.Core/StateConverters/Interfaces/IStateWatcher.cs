namespace Blazorc.StateConverters
{
    using System;

    public interface IStateWatcher : IDisposable
    {
        event EventHandler<EventArgs> StateChanged;
    }
}
