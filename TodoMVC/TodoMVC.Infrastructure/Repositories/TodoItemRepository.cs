using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TodoMVC.Domain.Interfaces;
using TodoMVC.Domain.Model;

namespace TodoMVC.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly Context _context;

        public TodoItemRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<TodoItem> GetAll() =>
            _context.TodoItems;

        public TodoItem GetById(int id) =>
            _context.TodoItems.FirstOrDefault(i => i.Id == id);

        public IQueryable<TodoItem> GetTodoItemsForList(int todoListId) =>
            _context.TodoItems.Where(i => i.Id == todoListId);

        public async Task<int> InsertTodoItem(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todoItem.Id;
        }

        public async Task DeleteTodoItem(int todoItemId)
        {
            var todoItem = await _context.TodoItems.SingleOrDefaultAsync(i => i.Id == todoItemId);
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            _context.Update(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}
