using System;
using System.Collections.Generic;

namespace TodoMVC.Domain.Model
{
    public class TodoList : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<TodoItem> TodoItems { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
