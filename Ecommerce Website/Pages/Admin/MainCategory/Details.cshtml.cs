using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ecommerce_Website.Data;

namespace Ecommerce_Website.Pages.Admin.MainCategory
{
    public class DetailsModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        public DetailsModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Data.MainCategory MainCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainCategory = await _context.MainCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (MainCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
