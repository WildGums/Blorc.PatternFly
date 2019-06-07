namespace Blazorc.PatternFly.Example
{
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazorc();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
