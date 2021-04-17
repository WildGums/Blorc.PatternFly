namespace Blorc.PatternFly.Example
{
    using System.Threading.Tasks;

    using Blorc.Services;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlorcCore();
            builder.Services.AddBlorcPatternFly();

            var webAssemblyHost = builder
                .Build();

            await webAssemblyHost.ConfigureDocumentAsync(
                async documentService =>
                {
                    await documentService.InjectBlorcCoreJsAsync();
                    await documentService.InjectBlorcPatternFlyAsync();
                });

            await webAssemblyHost
                .MapComponentServices(options => options.MapBlorcPatternFly())
                .RunAsync();
        }
    }
}
