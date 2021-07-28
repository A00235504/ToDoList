using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDoList.Data;
using ToDoList.Data.Context;


namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        StoreContext _context;
        

        [FromQuery]
        [FromForm]
        public ToDo todo { get; set; }

        [FromForm]
        public ToDo updateTodo { get; set; }

        

        public IList<ToDo> todoList { get; set; } = new List<ToDo>();

        

        public IndexModel(StoreContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {

  
            if (todo.Time != null)
            {
                
                _context.ToDos.Add(todo);
                _context.SaveChanges();
            }

            todoList = _context.ToDos.ToList();
           

        }

        public void OnPost()
        {
            if (updateTodo.Time != null)
            {

                try
                {
                    
                    _context.ToDos.Update(updateTodo);
                    _context.SaveChanges();
                }
                catch
                {
                    _context.ToDos.Add(updateTodo);
                    _context.SaveChanges();
                }
            }


            todoList = _context.ToDos.ToList();
        }
       


    }
}
