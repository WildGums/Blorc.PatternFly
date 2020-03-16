namespace Blorc.PatternFly.Services.Interfaces
{
    using Blorc.Services;

    using Microsoft.AspNetCore.Components;

    public interface ITargetContainerService : IComponentService
    {
        void Add(RenderFragment renderFragment);

        void Remove(RenderFragment renderFragment);
    }
}
