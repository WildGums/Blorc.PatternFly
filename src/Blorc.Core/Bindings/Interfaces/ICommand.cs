namespace Blorc.Bindings
{
    using System;
    using System.Threading.Tasks;

    public interface ICommand
    {
        object Tag { get; set; }

        event EventHandler<EventArgs> CanExecuteChanged;

        event EventHandler<EventArgs> Executed;

        Task<bool> CanExecuteAsync(object parameter);

        Task ExecuteAsync(object parameter);
    }
}
