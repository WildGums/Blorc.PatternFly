namespace Blorc.PatternFly.Example
{
    using Blorc.PatternFly.Components.Modal;
    using Blorc.PatternFly.Services;
    using Blorc.PatternFly.Services.Extensions;
    using Blorc.Services;

    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseComponentServices(
                options =>
                {
                    options.MapBlorcPatternFly();
                });

            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlorcCore();
            services.AddBlorcPatternFly();
        }
    }
}
