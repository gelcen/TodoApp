using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model.TodoItems;

namespace TodoApp.Services
{
    public class TodosMockRepository : IDataRepository<TodoItem>
    {
        private readonly List<TodoItem> _todos;

        public TodosMockRepository()
        {
            _todos = new List<TodoItem>()
            {
                new TodoItem()
                {
                    Id = 1,
                    Text = "Todo item one",
                    CreateDate = DateTime.Now
                },
                new TodoItem()
                {
                    Id = 2,
                    Text = "Todo item two",
                    CreateDate = DateTime.Now
                },
                new TodoItem()
                {
                    Id = 3,
                    Text = "Todo item three",
                    CreateDate = DateTime.Now
                }
            };
        }
        public async Task<bool> AddItemAsync(TodoItem item)
        {
            _todos.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = _todos.Where((TodoItem arg) => arg.Id == id).FirstOrDefault();
            _todos.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            return await Task.FromResult(_todos.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_todos);
        }

        public async Task<bool> UpdateItemAsync(TodoItem item)
        {
            var oldItem = _todos.Where((TodoItem arg) => arg.Id == item.Id).FirstOrDefault();
            _todos.Remove(oldItem);
            _todos.Add(item);

            return await Task.FromResult(true);
        }
    }
}
