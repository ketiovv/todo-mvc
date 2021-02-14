using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.TodoLists)
                .WithOne(l => l.ApplicationUser)
                .HasForeignKey(l => l.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<TodoList>()
                .HasMany(l => l.TodoItems)
                .WithOne(i => i.TodoList)
                .HasForeignKey(i => i.TodoListId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity
                    && e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    Entry((BaseEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                }
                ((BaseEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
