namespace Blorc.StateConverters
{
    using System;

    public interface IStateConverter : IDisposable
    {
        string GetValue();
    }
}
