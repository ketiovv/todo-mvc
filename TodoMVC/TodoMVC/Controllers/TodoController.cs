using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoMVC.Application.Interfaces;
using TodoMVC.Application.ViewModels;
using TodoMVC.Domain.Model;

namespace TodoMVC.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public TodoController(ITodoService todoService, UserManager<ApplicationUser> userManager)
        {
            _service = todoService;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var model = await _service.GetAllTodoListsForUser(userId);
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
        public async Task<ActionResult> UpdateIsDone(int id, string pageName, IFormCollection collection)
        {
            var item = await _service.GetTodoItemById(id);
            var isDone = item.IsCompleted;
            item.IsCompleted = !isDone;
            await _service.UpdateTodoItem(item);

            return pageName == nameof(Index)
                ? RedirectToAction(pageName)
                : RedirectToAction(nameof(ListDetails), new { id = item.TodoListId });
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
