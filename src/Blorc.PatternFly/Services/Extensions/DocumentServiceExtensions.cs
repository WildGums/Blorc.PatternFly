namespace Blorc.PatternFly.Services.Extensions
{
    using System.Threading.Tasks;

    using Blorc.Services;

    public static class DocumentServiceExtensions
    {
        public static async Task InjectBlorcPatternFly(this IDocumentService documentService)
        {
            await documentService.InjectAssemblyCSSFile(typeof(DocumentServiceExtensions).Assembly, "patternfly/patternfly.css");
        }
    }
}
