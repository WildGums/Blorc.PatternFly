namespace Blorc.Services
{
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static void AddBlorc(this IServiceCollection service)
        {
            service.AddSingleton<IDocumentService, DocumentService>();
        }
    }
}
