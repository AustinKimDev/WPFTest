using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CameraApplication.Command
{
    // 마소에서 권장하는 커맨드코드
    public class RelayCommand : ICommand
    {
        Func<object, bool> canExecute;
        Action<object> execute;
        event EventHandler canExecuteChanged;
        public event EventHandler CanExecuteChanged;

        public event EventHandler CanExcuteChanged
        {
            add { if (canExecute != null) CanExcuteChanged += value; }
            remove { if (canExecute != null) CanExcuteChanged -= value; }
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentException("execute");
            this.canExecute = canExecute;
        }

        public bool CanExecute(object param)
        {
            if (this.canExecute is null)
                return true;
            else
                return canExecute(param);
        }

        public void Execute(object param) => this.execute(param);

    }
}
