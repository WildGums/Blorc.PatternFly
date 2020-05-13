namespace Blorc.PatternFly.Example
{
    using System.Threading.Tasks;

    using Blorc.PatternFly.Services.Extensions;
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

            await builder
                .Build()
                .MapComponentServices(options => options.MapBlorcPatternFly())
                .RunAsync();
        }
    }
}
