namespace Blorc.Dom.Injectors
{
    using Blorc.Logging;
    using Microsoft.JSInterop;
    using System.Threading.Tasks;

    internal static class StyleInjectorFunctionsInterop
    {
        public static Task<string> InjectHead(IJSRuntime jsRuntime, string value)
        {
            Log.Debug($"Injecting head: '{value}'");

            // Implemented in exampleJsInterop.js
            return jsRuntime.InvokeAsync<string>(
                "StyleInjectorFunctions.injectHead",
                value);
        }
    }
}
