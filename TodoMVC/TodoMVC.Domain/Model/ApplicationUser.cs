using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TodoMVC.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TodoList> TodoLists { get; set; }
    }
}
