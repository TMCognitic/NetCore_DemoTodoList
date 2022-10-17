using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore_DemoTodoList.Models.Services
{
    internal class FakeService
    {
        private List<Todo> _items;

        public FakeService()
        {
            _items = new List<Todo>()
            {
                new Todo() { Id = 1, Title = "Test 1" },
                new Todo() { Id = 2, Title = "Test 2" },
                new Todo() { Id = 3, Title = "Test 3" },
            };
        }

        public IEnumerable<Todo> Get()
        {
            return _items;
        }

        public void Insert(Todo entity)
        {
            int id = _items.Count == 0 ? 1 : _items.Max(td => td.Id) + 1;
            entity.Id = id;
            _items.Add(entity);
        }

        public void Delete(int id)
        {
            Todo? todo = _items.SingleOrDefault(td => td.Id == id);

            if (todo is not null)
            {
                _items.Remove(todo);
            }
        }
    }
}
