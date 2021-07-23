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
        public Color color { get; set; }

        [FromForm]
        public Color updateColor { get; set; }

        

        public IList<Color> colorList { get; set; } = new List<Color>();

        

        public IndexModel(StoreContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {

  
            if (color.ShortCode != null)
            {
                
                _context.Colors.Add(color);
                _context.SaveChanges();
            }

            colorList = _context.Colors.ToList();
           

        }

        public void OnPost()
        {
            if (updateColor.ShortCode != null)
            {

                try
                {
                    _context.Colors.Update(updateColor);
                    _context.SaveChanges();
                }
                catch
                {
                    _context.Colors.Add(updateColor);
                    _context.SaveChanges();
                }
            }
            

            colorList = _context.Colors.ToList();
        }
       


    }
}
