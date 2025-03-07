using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ADD_DABOMPA.ViewModels
{
    public class ViewModelsCommand : ICommand
    {
        private readonly Action<object?> _executeAction;
        private readonly Predicate<object?> _canExecuteAction;
        public event EventHandler? CanExecuteChanged;

        public ViewModelsCommand(Action<object?> executeAction, Predicate<object?> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public ViewModelsCommand(Action<object?> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
