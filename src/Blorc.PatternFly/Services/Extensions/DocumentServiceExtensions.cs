namespace Blorc.PatternFly
{
    using System.Threading.Tasks;

    using Blorc.Services;

    public static class DocumentServiceExtensions
    {
        public static async Task InjectBlorcPatternFlyAsync(this IDocumentService documentService)
        {
            await documentService.InjectAssemblyCSSFileAsync(typeof(DocumentServiceExtensions).Assembly, "patternfly/patternfly.css");
            await documentService.InjectAssemblyCSSFileAsync(typeof(DocumentServiceExtensions).Assembly, "patternfly/patternfly-extras.css");
        }
    }
}
