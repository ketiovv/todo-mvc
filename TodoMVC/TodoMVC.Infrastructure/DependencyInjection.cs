using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoMVC.Domain.Interfaces;
using TodoMVC.Infrastructure.Repositories;

namespace TodoMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<Context>(options =>
                    options.UseInMemoryDatabase(databaseName: "TodoDb"));
            }
            else
            {
                services.AddDbContext<Context>(options =>
                    options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            }
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            services.AddTransient<ITodoListRepository, TodoListRepository>();

            return services;
        }
    }
}
