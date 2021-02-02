using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TodoMVC.Domain.Interfaces;
using TodoMVC.Domain.Model;

namespace TodoMVC.Infrastructure.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly Context _context;

        public TodoListRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<TodoList> GetAll()
        {
            return _context.TodoLists;
        }

        public TodoList GetById(int id)
        {
            return _context.TodoLists.FirstOrDefault(l => l.Id == id);
        }

        public async Task<int> InsertTodoItem(TodoList todoList)
        {
            await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();
            return todoList.Id;
        }

        public async Task DeleteTodoItem(int todoListId)
        {
            var todoList = await _context.TodoLists.SingleOrDefaultAsync(l => l.Id == todoListId);
            _context.TodoLists.Remove(todoList);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoItem(TodoList todoList)
        {
            _context.Update(todoList);
            await _context.SaveChangesAsync();
        }
    }
}
