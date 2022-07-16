using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blazor2.Data
{
    public class TodoTask
    {
        [Required]
        public string TaskName { get; set; }
        public List<Person> peopleList { get; set; } = new List<Person>();
        public TodoTask() { }
        public TodoTask(TodoTask task)
        {
            this.TaskName = task.TaskName;
            this.peopleList = task.peopleList;
        }

    }

    public class Person
    {
        public string PersonName { get; set; }
        public bool ShowMore { get; set; } = false;
        public List<TodoItem> todoList { get; set; } = new List<TodoItem>();
        public Person() { }
        public Person(Person p)
        {
            this.PersonName = p.PersonName;
            this.todoList = p.todoList;
        }
    }
    public class TodoItem
    {
        [Required]
        public string Title { get; set; }
        public bool Done { get; set; }
        public string Note { get; set; }

    }
}
