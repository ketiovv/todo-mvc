using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoMVC.Application.Interfaces;
using TodoMVC.Application.ViewModels;

namespace TodoMVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService todoService)
        {
            _service = todoService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllTodoLists();
            return View(model);
        }


        // GET: ListDetails/id
        public async Task<ActionResult> ListDetails(int id)
        {
            var model = await _service.GetTodoItemsForList(id);
            return View(model);
        }


        // GET: CreateList
        public ActionResult CreateList()
        {
            return View();
        }

        // POST: CreateList
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateList(IFormCollection collection, TodoListVm model)
        {
            try
            {
                await _service.InsertTodoList(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: CreateItem
        public async Task<ActionResult> CreateItem(int listId)
        {
            var list = await _service.GetTodoListById(listId);
            var model = new TodoItemVm() { TodoListId = list.Id, TodoListName = list.ListName };
            return View(model);
        }

        // POST: CreateItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateItem(IFormCollection collection, TodoItemVm model)
        {
            try
            {
                await _service.InsertTodoItem(model);
                return RedirectToAction(nameof(ListDetails), new { id = model.TodoListId });
            }
            catch
            {
                return View();
            }
        }


        // GET: EditItem
        public async Task<ActionResult> EditItem(int id)
        {
            var model = await _service.GetTodoItemById(id);
            return View(model);
        }

        // POST: EditItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditItem(int id, IFormCollection collection, TodoItemVm model)
        {
            try
            {
                await _service.UpdateTodoItem(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: Update IsDone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateIsDone(int id, IFormCollection collection)
        {
            var item = await _service.GetTodoItemById(id);
            var isDone = item.IsCompleted;
            item.IsCompleted = !isDone;
            await _service.UpdateTodoItem(item);

            return RedirectToAction(nameof(Index));
        }

        // GET: EditList
        public async Task<ActionResult> EditList(int id)
        {
            var model = await _service.GetTodoListById(id);
            return View(model);
        }

        // POST: EditList
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditList(IFormCollection collection, TodoListVm model)
        {
            try
            {
                await _service.UpdateTodoList(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Delete item
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _service.DeleteTodoItem(id);
            return RedirectToAction(nameof(Index));
        }


        // GET: Delete list
        public async Task<ActionResult> DeleteList(int id)
        {
            await _service.DeleteTodoList(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
