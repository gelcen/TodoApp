using SQLite;
using System;

namespace TodoApp.Model.TodoItems
{
    [Table("TodoItems")]
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Done { get; set; } = false;
    }
}
