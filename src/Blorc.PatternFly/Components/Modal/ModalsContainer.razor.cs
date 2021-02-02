namespace Blorc.PatternFly.Components.Modal
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public partial class ModalsContainer : BlorcComponentBase
    {
        [Inject]
        public IModalComponentService ModalComponentService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ModalComponentService.ModalRequest += ModalComponentService_OnOnModalRequest;
        }

        private void ModalComponentService_OnOnModalRequest(object sender, EventArgs e)
        {
            StateHasChanged();
        }

        public RenderFragment Dialog
        {
            get
            {
                return builder =>
                {
                    builder.OpenComponent(0, ModalComponentService.ModalType);
                    builder.CloseComponent();
                };
            }
        }
    }

    public interface IModalComponentService
    {
        event EventHandler ModalRequest;

        Type ModalType { get; }

        void ShowAsync<TModal>();
    }

    public class ModalComponentService : IModalComponentService
    {

        public event EventHandler ModalRequest;

        public Type ModalType { get; private set; }

        public void ShowAsync<TModal>()
        {
            ModalType = typeof(TModal);
            OnModalRequest();
        }

        protected virtual void OnModalRequest()
        {
            ModalRequest?.Invoke(this, EventArgs.Empty);
        }
    }
}
