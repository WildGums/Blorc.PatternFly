namespace Blazorc.StateConverters
{
    using System;

    public interface IStateConverter : IDisposable
    {
        string GetValue();
    }
}
