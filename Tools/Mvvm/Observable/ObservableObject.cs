using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Tools.Mvvm.Commands;

namespace Tools.Mvvm.Observable
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableObject()
        {
            Type type = GetType();

            foreach(PropertyInfo propertyInfo in type.GetProperties())
            {
                if (IsCommand(propertyInfo))
                {
                    ICommand? command = (ICommand?)propertyInfo.GetMethod?.Invoke(this, null);
                    if (command is not null)
                    {
                        PropertyChanged += (s, e) => command.RaiseCanExecuteChanged();
                    }
                }
            }
        }

        private bool IsCommand(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType == typeof(ICommand) ||
                propertyInfo.PropertyType.GetInterfaces().Any(i => i == typeof(ICommand));
        }

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}