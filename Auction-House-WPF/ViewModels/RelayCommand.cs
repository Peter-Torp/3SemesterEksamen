using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Auction_House_WPF.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<string> _TargetExecuteMethod;
        private Func<bool> _TargetCanExecuteMethod;

        public RelayCommand(Action<string> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<string> executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);

        }
        

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)   //parameter from textbox is parsed
        {
            this._TargetExecuteMethod(parameter.ToString());
        }
    }
}
