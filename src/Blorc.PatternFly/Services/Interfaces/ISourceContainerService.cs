namespace Blorc.PatternFly
{
    using System.Threading.Tasks;

    using Blorc.Services;

    public interface ISourceContainerService : IComponentService
    {
        Task HideContentAsync();

        Task ShowContentAsync();

        Task UpdateContentAsync();
    }
}
