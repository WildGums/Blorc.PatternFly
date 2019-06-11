namespace Blorc.Services
{
    using System.Threading.Tasks;
    using Blorc.Dom.Injectors;
    using Interop;
    using Microsoft.JSInterop;

    public class DocumentService : IDocumentService
    {
        private readonly IJSRuntime _jsRuntime;

        public DocumentService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<Rect> GetBoundingClientRectById(string id)
        {
            return DocumentFunctionsInterop.GetBoundingClientRectById(_jsRuntime, id);
        }

        public Task<Rect> GetOffsetBoundingClientRect(long x, long y)
        {
            return DocumentFunctionsInterop.GetOffsetBoundingClientRect(_jsRuntime, x, y);
        }

        public Task<Rect> GetBoundingClientRect(long x, long y)
        {
            return DocumentFunctionsInterop.GetBoundingClientRect(_jsRuntime, x, y);
        }

        public void InjectHead(IInjectorValueProvider injectorValueProvider)
        {
            var value = injectorValueProvider.GetValue();
            StyleInjectorFunctionsInterop.InjectHead(_jsRuntime, value);
        }
    }
}
