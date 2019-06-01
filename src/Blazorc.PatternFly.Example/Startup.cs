namespace Blazorc.PatternFly.Example
{
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazorcPatternFly();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
