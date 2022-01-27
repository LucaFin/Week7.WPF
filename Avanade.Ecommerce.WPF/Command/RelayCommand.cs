using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Avanade.Ecommerce.WPF.Command
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object?> executeMethod;
        private Predicate<object?> canExecuteMethod;

        public bool CanExecute(object? parameter)
        {
            return (canExecuteMethod == null) ? true : canExecuteMethod.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            executeMethod?.Invoke(parameter);
        }

        public RelayCommand(Action<object?> Execute, Predicate<object?> CanExecute)
        {
            executeMethod = Execute;
            canExecuteMethod = CanExecute;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
