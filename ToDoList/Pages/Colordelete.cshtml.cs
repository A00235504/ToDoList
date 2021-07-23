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
        public Color color { get; set; }
        [FromForm]
        public Color updateColor { get; set; }

        public ColordeleteModel(StoreContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost()
        {
            if (updateColor.ShortCode != null)
            {
                _context.Colors.Remove(updateColor);
                _context.SaveChanges();
            }

            return new RedirectToPageResult("Index");
        }
    }
}