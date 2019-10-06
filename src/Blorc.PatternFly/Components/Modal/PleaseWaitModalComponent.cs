namespace Blorc.PatternFly.Components.Modal
{
    using System;
    using System.Threading.Tasks;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using Progress;

    public class PleaseWaitModalComponent : BlorcComponentBase, IProgress<int>
    {
        public const string DefaultPleaseWaitHeader = "Please Wait...";

        protected Modal Modal { get; set; }

        protected Progress Progress { get; set; }

        [Parameter] 
        public ModalSize Size { get; set; } = ModalSize.Small;

        [Parameter] 
        public Func<IProgress<int>, Task> Action { get; set; }

        [Parameter] 
        public RenderFragment Header { get; set; }

        [Parameter]
        public bool ShowProgress { get; set; }

        public void Report(int value)
        {
            if (ShowProgress)
            {
                // TODO: This is not working properly. 
                Progress.Value = value;
            }
        }

        public Task Execute()
        {
            Modal.Show();
            return Task.Run(async () =>
            {
                await Action(this);
                Modal.Close();
            });
        }

        public void Close()
        {
            Modal.Close();
        }
    }
}
