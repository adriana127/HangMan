using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewChanger.ViewModels;

namespace ViewChanger.Command
{
    public class UpdateViewCommand : ICommand
    {
        private readonly Action action;

        public UpdateViewCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public event EventHandler CanExecuteChanged;
    } }

