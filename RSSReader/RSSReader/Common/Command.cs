using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSReader.Common
{
    public class Command : ICommand
    {
        private Action<object> execute { get; set; }
        private Func<object, bool> canExecute { get; set; }

        public Command(Action<object> execute) : this(execute, p => true)
        {
            execute = execute;
        }

        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            execute = execute;
            canExecute = canExecute;
        }



        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void OnCanExcuteChange()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
