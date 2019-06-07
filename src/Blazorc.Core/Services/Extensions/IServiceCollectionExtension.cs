namespace Blazorc.Services
{
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static void AddBlazorc(this IServiceCollection service)
        {
            service.AddSingleton<IDocumentService, DocumentService>();
        }
    }
}
