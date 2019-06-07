namespace Blazorc.Services
{
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static void AddBlazorcPatternFly(this IServiceCollection service)
        {
            service.AddSingleton<IDocumentService, DocumentService>();
        }
    }
}
