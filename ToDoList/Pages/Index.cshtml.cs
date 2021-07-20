using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDoList.Data;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        [FromForm]
        public Customer Customer { get; set; }

        [FromForm(Name = "loginName")]
        public string LoginName { get; set; }

        [FromForm(Name = "loginPass")]
        public string LoginPass { get; set; }

        [FromQuery(Name = "leftNumber")]
        public int leftNumber { get; set; }

        [FromQuery(Name = "rightNumber")]
        public int rightNumber { get; set; }

        public int Result { get; set; }

        public bool ResultSet { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           

            return RedirectToPage("./Index");
        }
    }
}
