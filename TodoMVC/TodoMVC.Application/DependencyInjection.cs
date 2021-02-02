using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoMVC.Application.Interfaces;
using TodoMVC.Application.Services;

namespace TodoMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ITodoService, TodoService>();

            return services;
        }
    }
}
