namespace Blazorc.Services
{
    using System.Threading.Tasks;
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
    }
}
