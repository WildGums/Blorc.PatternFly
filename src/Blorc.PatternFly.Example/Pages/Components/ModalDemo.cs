namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Modal;

    public class ModalDemoComponent : BlorcComponentBase
    {
        public Modal SimpleModal { get; set; }

        public ModalComponent SmallModal { get; set; }

        public ModalComponent LargeModal { get; set; }

        public PleaseWaitModalComponent PleaseWaitModal { get; set; }

        public PleaseWaitModalComponent PleaseWaitModalWithProgress { get; set; }

        public PleaseWaitModalComponent PleaseWaitModalWithProgressAndBody { get; set; }

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
