using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoMVC.Domain.Model;

namespace TodoMVC.Infrastructure
{
    public static class DatabaseSeed
    {
        public static async Task Seed(Context context)
        {
            if (!context.TodoLists.Any())
            {
                var todoItem1 = new TodoItem()
                {
                    Task = "Task1",
                    Description = "Description of this task..",
                    DueDate = DateTime.UtcNow.AddDays(3)
                };
                var todoItem2 = new TodoItem()
                {
                    Task = "Task2",
                    Description = "Description of this task..",
                    DueDate = DateTime.UtcNow.AddDays(7)
                };

                var todoList = new TodoList()
                {
                    Name = "My List",
                    TodoItems = new List<TodoItem>() { todoItem1, todoItem2 }
                };

                context.TodoLists.Add(todoList);
            }

            await context.SaveChangesAsync();
        }
    }
}
