namespace Blorc.PatternFly
{
    using System.Threading.Tasks;

    using Blorc.Services;

    public static class DocumentServiceExtensions
    {
        public static async Task InjectBlorcPatternFlyAsync(this IDocumentService documentService)
        {
            await documentService.InjectAssemblyCssFileAsync(typeof(DocumentServiceExtensions).Assembly, "patternfly/patternfly.css");
            await documentService.InjectAssemblyCssFileAsync(typeof(DocumentServiceExtensions).Assembly, "patternfly/patternfly-extras.css");
        }
    }
}
