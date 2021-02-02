namespace Blorc.PatternFly
{
    using Blorc.PatternFly.Components.Container;
    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    public static class IComponentServiceFactoryExtensions
    {
        public static void MapBlorcPatternFly(this IComponentServiceFactory @this)
        {
            @this.Map<UIModal, ModalUIVisualizationService>();
            @this.Map<PleaseWaitModal, PleaseWaitModalExecutionService>();

            @this.Map<TargetContainer, ITargetContainerService>();
            @this.Map<SourceContainer, ISourceContainerService>();
        }
    }
}
