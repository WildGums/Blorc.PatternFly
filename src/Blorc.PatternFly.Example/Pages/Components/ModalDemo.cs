namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    public class ModalDemoComponent : BlorcComponentBase
    {
        public IUIVisualizationService SimpleModal { get; set; }

        public IUIVisualizationService SmallModal { get; set; }

        public IUIVisualizationService LargeModal { get; set; }

        public IExecutionService PleaseWaitModal { get; set; }

        public IExecutionService PleaseWaitModalWithProgress { get; set; }

        public IExecutionService PleaseWaitModalWithProgressAndBody { get; set; }

        public async Task DoSomething(ExecutionContext ctx)
        {
            int total = 100;
            for (int i = 0; i < total; i++)
            {
                int value = Convert.ToInt32(100.0d * i / total);

                if (ctx.State != null && ((bool)ctx.State))
                {
                    await Task.Delay(10);
                }
                else
                {
                    await ctx.Progress.ReportAsync(value);
                }
            }
        }
    }
}
