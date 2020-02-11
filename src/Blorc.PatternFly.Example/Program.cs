namespace Blorc.PatternFly.Example
{
    using System.Threading.Tasks;

    using Blorc.PatternFly.Services.Extensions;
    using Blorc.Services;

    using Microsoft.AspNetCore.Blazor.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBlorcCore();
            builder.Services.AddBlorcPatternFly();

            var build = builder.Build();

            var componentServiceFactory = build.Services.GetService<IComponentServiceFactory>();
            componentServiceFactory.MapBlorcPatternFly();

            await build.RunAsync();
        }
    }
}
