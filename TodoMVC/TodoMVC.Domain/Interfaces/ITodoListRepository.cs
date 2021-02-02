using System.Linq;
using System.Threading.Tasks;
using TodoMVC.Domain.Model;

namespace TodoMVC.Domain.Interfaces
{
    public interface ITodoListRepository
    {
        IQueryable<TodoList> GetAll();
        TodoList GetById(int id);
        Task<int> InsertTodoItem(TodoList todoList);
        Task DeleteTodoItem(int todoListId);
        Task UpdateTodoItem(TodoList todoList);
    }
}
