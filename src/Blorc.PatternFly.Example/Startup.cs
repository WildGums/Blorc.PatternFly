namespace Blorc.PatternFly.Example
{
    using Blorc.PatternFly.Components.Modal;
    using Blorc.PatternFly.Services;
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
                    options.Map<Modal, ModalUIVisualizationService>();
                    options.Map<PleaseWaitModal, PleaseWaitModalExecutionService>();
                });

            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlorcCore();

            services.AddTransient<PleaseWaitModalExecutionService>();
            services.AddTransient<ModalUIVisualizationService>();
        }
    }
}
