namespace Blorc.PatternFly.Services
{
    using System;
    using System.Threading.Tasks;

    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    public class PleaseWaitModalExecutionService : IExecutionService
    {
        private readonly PleaseWaitModalComponent _pleaseWaitModal;

        public PleaseWaitModalExecutionService(PleaseWaitModalComponent pleaseWaitModal)
        {
            _pleaseWaitModal = pleaseWaitModal ?? throw new ArgumentNullException(nameof(pleaseWaitModal));
        }

        public async Task ExecuteAsync(object state = null)
        {
            await _pleaseWaitModal.ExecuteAsync(state);
        }
    }
}
