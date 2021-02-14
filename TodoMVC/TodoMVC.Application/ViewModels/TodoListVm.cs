using AutoMapper;
using System.ComponentModel;
using TodoMVC.Application.Mapping;
using TodoMVC.Domain.Model;

namespace TodoMVC.Application.ViewModels
{
    public class TodoListVm : IMapFrom<TodoList>
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string ListName { get; set; }
        public string ApplicationUserId { get; set; }
        public TodoItemListVm Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListVm>()
                .ForMember(d => d.ListName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Items, opt => opt.Ignore()).ReverseMap();
        }
    }
}
