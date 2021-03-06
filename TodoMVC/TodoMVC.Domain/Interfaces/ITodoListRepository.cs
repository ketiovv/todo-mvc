﻿using System.Linq;
using System.Threading.Tasks;
using TodoMVC.Domain.Model;

namespace TodoMVC.Domain.Interfaces
{
    public interface ITodoListRepository
    {
        IQueryable<TodoList> GetAll();
        IQueryable<TodoList> GetAllForUser(string id);
        TodoList GetListById(int id);
        Task<int> InsertTodoList(TodoList todoList);
        Task DeleteTodoList(int todoListid);
        Task UpdateTodoList(TodoList todoList);
    }
}
