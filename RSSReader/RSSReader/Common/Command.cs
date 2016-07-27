using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSReader.Common
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute { get; set; }
        private Func<object, bool> _canExecute { get; set; }

        public DelegateCommand(Action<object> execute) : this(execute, p => true)
        {
            _execute = execute;
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }



        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void OnCanExcuteChange()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
