using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoMVC.Domain.Model;

namespace TodoMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
