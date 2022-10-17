using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Mvvm.Commands
{
    public interface ICommand : System.Windows.Input.ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
