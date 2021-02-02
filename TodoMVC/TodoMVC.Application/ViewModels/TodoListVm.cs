using AutoMapper;
using TodoMVC.Application.Mapping;
using TodoMVC.Domain.Model;

namespace TodoMVC.Application.ViewModels
{
    public class TodoListVm : IMapFrom<TodoList>
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public TodoItemListVm Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListVm>()
                .ForMember(d => d.Items,
                    opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
