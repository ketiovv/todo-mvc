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
        public async Task DeleteTodoList(int todoListid)
        {
            var list = _context.TodoLists.Where(p => p.Id == todoListid).SingleOrDefault();
            _context.TodoLists.Remove(list);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TodoList> GetAll()
        {
            return _context.TodoLists;
        }

        public TodoList GetListById(int id)
        {
            return _context.TodoLists.FirstOrDefault(p => p.Id == id);
        }

        public async Task<int> InsertTodoList(TodoList todoList)
        {
            await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();
            return todoList.Id;
        }

        public async Task UpdateTodoList(TodoList todoList)
        {
            _context.Update(todoList);
            await _context.SaveChangesAsync();
        }
    }
}
