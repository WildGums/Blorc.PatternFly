namespace Blorc.PatternFly.Components.Modal
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Progress;
    using Blorc.PatternFly.Core;

    using Microsoft.AspNetCore.Components;

    public partial class PleaseWaitModal : BlorcComponentBase, IProgressAsync<int>
    {
        public const string DefaultPleaseWaitHeader = "Please Wait...";

        public PleaseWaitModal()
            : base(true)
        {
        }

        [Parameter]
        public Func<ExecutionContext, Task> Action { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        public string HeaderText
        {
            get => GetPropertyValue<string>(nameof(HeaderText));
            set => SetPropertyValue(nameof(HeaderText), value);
        }

        [Parameter]
        public Func<ExecutionContext, Task<string>> HeaderTextAction { get; set; }

        [Parameter]
        public bool ShowProgress { get; set; }

        [Parameter]
        public ModalSize Size { get; set; } = ModalSize.Small;

        protected ISourceContainerService ModalSourceContainerService { get; set; }

        protected Progress Progress { get; set; }

        public async Task ExecuteAsync(object state = null)
        {
            var executionContext = new ExecutionContext(this, state);
            if (HeaderTextAction != null)
            {
                HeaderText = await HeaderTextAction(executionContext);
            }

            await ModalSourceContainerService.ShowContentAsync();

            await Task.Run(
                async () =>
                {
                    await Action(executionContext);
                    await ModalSourceContainerService.HideContentAsync();
                });
        }

        public async Task ReportAsync(int value)
        {
            if (ShowProgress)
            {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                Progress.Value = value;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                await Task.Delay(1);
            }
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
