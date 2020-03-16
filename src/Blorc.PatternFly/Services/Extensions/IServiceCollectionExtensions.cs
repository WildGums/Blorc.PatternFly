namespace Blorc.PatternFly.Services.Extensions
{
    using Blorc.PatternFly.Services.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static void AddBlorcPatternFly(this IServiceCollection @this)
        {
            @this.AddTransient<PleaseWaitModalExecutionService>();
            @this.AddTransient<ModalUIVisualizationService>();

            @this.AddSingleton<ITargetContainerService, TargetContainerService>();
            @this.AddTransient<ISourceContainerService, SourceContainerService>();
        }
    }
}
