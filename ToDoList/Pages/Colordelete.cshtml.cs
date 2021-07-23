using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Data.Context;

namespace ToDoList.Pages
{
    public class ColordeleteModel : PageModel
    {

        StoreContext _context;

        [FromQuery]
        public ToDo todo { get; set; }
        [FromForm]
        public ToDo updateTodo { get; set; }

        public ColordeleteModel(StoreContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost()
        {
            if (updateTodo.Title != null)
            {
                _context.ToDos.Remove(updateTodo);
                _context.SaveChanges();
            }

            return new RedirectToPageResult("Index");
        }
    }
}