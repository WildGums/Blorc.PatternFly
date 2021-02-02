namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    public partial class ModalDemo : BlorcComponentBase
    {
        public ModalDemo()
            : base(true)
        {
        }

        protected IUIVisualizationService LargeUIModal { get; set; }

        protected IExecutionService PleaseWaitModal { get; set; }

        protected IExecutionService PleaseWaitModalWithProgress { get; set; }

        protected IExecutionService PleaseWaitModalWithProgressAndBody { get; set; }

        protected IUIVisualizationService SimpleUIModal { get; set; }

        protected IUIVisualizationService SmallUIModal { get; set; }

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
    }
}
