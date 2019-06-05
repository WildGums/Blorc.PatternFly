namespace Blazorc.PatternFly
{
    using System;

    public interface IStateConverter : IDisposable
    {
        string GetValue();
    }
}
