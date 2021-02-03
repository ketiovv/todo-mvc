using System.Linq;
using System.Threading.Tasks;
using TodoMVC.Domain.Model;

namespace TodoMVC.Domain.Interfaces
{
    public interface ITodoItemRepository
    {
        IQueryable<TodoItem> GetAll();
        TodoItem GetItemById(int id);
        IQueryable<TodoItem> GetTodoItemsForList(int todoListId);
        Task<int> InsertTodoItem(TodoItem todoItem);
        Task DeleteTodoItem(int todoItemid);
        Task UpdateTodoItem(TodoItem todoItem);
    }
}
