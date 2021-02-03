using System;

namespace TodoMVC.Domain.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
