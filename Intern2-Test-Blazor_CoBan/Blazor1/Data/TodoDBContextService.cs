using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor1.Data
{
    public class TodoDBContextService
    {
        protected readonly TodoDBContext _dbcontext;

        public TodoDBContextService(TodoDBContext db)
        {
            _dbcontext = db;
        }

        public List<TodoItem> displayTodos()
        {
            return _dbcontext.todoDbSet.ToList();
        }

        public void AddTodo(TodoItem td)
        {
            _dbcontext.todoDbSet.Add(td);
            _dbcontext.SaveChanges();
        }

        public void DeleteTodo(TodoItem td)
        {
            var TodoDel = _dbcontext.todoDbSet.FirstOrDefault(u => u.Title == td.Title);
            _dbcontext.todoDbSet.Remove(TodoDel);
            _dbcontext.SaveChanges();
        }

    }
}
