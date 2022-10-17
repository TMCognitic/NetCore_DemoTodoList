using NetCore_DemoTodoList.Models;
using NetCore_DemoTodoList.Models.Services;
using NetCore_DemoTodoList.ViewModels.Messages;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Tools.Mvvm.Commands;
using Tools.Mvvm.Observable;
using Tools.Patterns.Mediator;

namespace NetCore_DemoTodoList.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private readonly FakeService _service;
        private ObservableCollection<TodoViewModel>? _items;
        private ICommand? _addCommand;

        private string? _title;

        public MainViewModel()
        {
            Messager<TodoMessage>.Instance.MessageHandler += OnDelete;
            _service = new FakeService();
        }

        public ObservableCollection<TodoViewModel> Items
        {
            get
            {
                return _items ??= LoadItems();
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ??= new DelegateCommand(Add, CanAdd);
            }
        }

        public string? Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void Add()
        {
            Todo todo = new Todo() { Title = Title };
            _service.Insert(todo);
            Items.Add(new TodoViewModel(todo));
            Title = null;
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }


        private ObservableCollection<TodoViewModel> LoadItems()
        {
            return new ObservableCollection<TodoViewModel>(_service.Get().Select(t => new TodoViewModel(t)));
        }

        private void OnDelete(TodoMessage message)
        {
            if(message.Action == Actions.Delete)
                Items.Remove(message.Sender);
        }
    }
}
