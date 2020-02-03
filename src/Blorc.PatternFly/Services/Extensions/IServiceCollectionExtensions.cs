namespace Blorc.PatternFly.Services.Extensions
{
    using Components.AlertGroup;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static void AddBlorcPatternFly(this IServiceCollection @this)
        {
            @this.AddSingleton<INotificationService, NotificationService>();
            @this.AddTransient<PleaseWaitModalExecutionService>();
            @this.AddTransient<ModalUIVisualizationService>();
        }

    }
}
