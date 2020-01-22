namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    public class ModalDemoComponent : BlorcComponentBase
    {
        protected IUIVisualizationService LargeModal { get; set; }

        protected IExecutionService PleaseWaitModal { get; set; }

        protected IExecutionService PleaseWaitModalWithProgress { get; set; }

        protected IExecutionService PleaseWaitModalWithProgressAndBody { get; set; }

        protected IUIVisualizationService SimpleModal { get; set; }

        protected IUIVisualizationService SmallModal { get; set; }

        public async Task DoSomething(ExecutionContext ctx)
        {
            var total = 100;
            for (var i = 0; i < total; i++)
            {
                var value = Convert.ToInt32(100.0d * i / total);

                if (ctx.State != null && (bool)ctx.State)
                {
                    await Task.Delay(10);
                }
                else
                {
                    await ctx.Progress.ReportAsync(value);
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            InjectComponentServices = true;
        }
    }
}
