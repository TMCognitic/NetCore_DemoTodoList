using NetCore_DemoTodoList.Models;
using NetCore_DemoTodoList.Models.Services;
using NetCore_DemoTodoList.ViewModels.Messages;
using System;
using Tools.Mvvm.Commands;
using Tools.Mvvm.Observable;
using Tools.Patterns.Mediator;

namespace NetCore_DemoTodoList.ViewModels
{
    public class TodoViewModel : EntityViewModel<Todo>
    {
        private readonly FakeService _service;
        private ICommand? _deleteCommand;

        public TodoViewModel(Todo entity) : base(entity)
        {            
            _service = new FakeService();
        }

        public string Title
        {
            get { return Entity.Title; }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new DelegateCommand(Delete);
            }
        }

        private void Delete()
        {
            _service.Delete(Entity.Id);
            Messager<TodoMessage>.Instance.Send(new TodoMessage(Actions.Delete, this));
        }
    }
}
