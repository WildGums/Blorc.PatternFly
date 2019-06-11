namespace Blorc.Services.Interop
{
    using System.Threading.Tasks;
    using Microsoft.JSInterop;

    internal static class DocumentFunctionsInterop
    {
        public static Task<Rect> GetBoundingClientRect(IJSRuntime jsRuntime, long x, long y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "DocumentFunctions.getBoundingClientRect",
                x, y);
        }

        public static Task<Rect> GetOffsetBoundingClientRect(IJSRuntime jsRuntime, long x, long y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "DocumentFunctions.getOffsetBoundingClientRect",
                x, y);
        }

        public static Task<Rect> GetBoundingClientRectById(IJSRuntime jsRuntime, string id)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "DocumentFunctions.getBoundingClientRectById",
                id);
        }
    }

    public class Rect
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Bottom { get; set; }

        public int Top { get; set; }
    }
}
