using System.Linq;
using System.Threading.Tasks;
using TodoMVC.Domain.Model;

namespace TodoMVC.Domain.Interfaces
{
    public interface ITodoListRepository
    {
        IQueryable<TodoList> GetAll();
        TodoList GetById(int id);
        Task<int> InsertTodoList(TodoList todoList);
        Task DeleteTodoList(int todoListId);
        Task UpdateTodoList(TodoList todoList);
    }
}
