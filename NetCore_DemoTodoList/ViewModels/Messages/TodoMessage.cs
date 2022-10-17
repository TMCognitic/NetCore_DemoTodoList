using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Mediator;

namespace NetCore_DemoTodoList.ViewModels.Messages
{
    public class TodoMessage
    {
        public TodoMessage(Actions action, TodoViewModel sender)
        {
            Action = action;
            Sender = sender;
        }

        public Actions Action { get; init; }
        public TodoViewModel Sender { get; init; }
    }
}
