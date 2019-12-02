namespace Blorc.PatternFly.Components.Modal
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Blorc.Components;
    using Core;
    using Microsoft.AspNetCore.Components;
    using Progress;

    public class PleaseWaitModalComponent : BlorcComponentBase, IProgressAsync<int>
    {
        public const string DefaultPleaseWaitHeader = "Please Wait...";

        protected Modal Modal { get; set; }

        protected Progress Progress { get; set; }

        [Parameter] 
        public ModalSize Size { get; set; } = ModalSize.Small;

        [Parameter] 
        public Func<ExecutionContext, Task> Action { get; set; }

        [Parameter]
        public Func<ExecutionContext, Task<string>> HeaderTextAction { get; set; }

        [Parameter] 
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }


        [Parameter]
        public bool ShowProgress { get; set; }

        public async Task ReportAsync(int value)
        {
            if (ShowProgress)
            {
                Progress.Value = value;
                await Task.Delay(1);
            }
        }

        public async Task ExecuteAsync(object state = null)
        {
            var executionContext = new ExecutionContext(this, state);
            if (HeaderTextAction != null)
            {
                HeaderText = await HeaderTextAction(executionContext);
            }

            Modal.Show();
            await Task.Run(async () =>
            {
                await Action(executionContext);
                Modal.Close();
            });
        }

        public string HeaderText
        {
            get => GetPropertyValue<string>(nameof(HeaderText));
            set => SetPropertyValue(nameof(HeaderText), value);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HeaderText))
            {
                StateHasChanged();
            }
        }
    }
}
