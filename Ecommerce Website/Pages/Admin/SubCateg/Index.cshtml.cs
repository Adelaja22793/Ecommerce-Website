using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ecommerce_Website.Data;

namespace Ecommerce_Website.Pages.Admin.SubCateg
{
    public class IndexModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        public IndexModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SubCategory> SubCategory { get;set; }

        public async Task OnGetAsync()
        {
            SubCategory = await _context.SubCategories
                .Include(s => s.MainCategory).ToListAsync();
        }
    }
}
