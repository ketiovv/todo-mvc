using Microsoft.Extensions.DependencyInjection;
using TodoMVC.Domain.Interfaces;
using TodoMVC.Infrastructure.Repositories;

namespace TodoMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            services.AddTransient<ITodoListRepository, TodoListRepository>();

            return services;
        }
    }
}
