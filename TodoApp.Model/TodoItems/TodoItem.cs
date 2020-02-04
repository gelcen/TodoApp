using System;

namespace TodoApp.Model.TodoItems
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Done { get; set; } = false;
    }
}
