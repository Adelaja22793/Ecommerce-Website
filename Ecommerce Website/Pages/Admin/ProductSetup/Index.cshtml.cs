using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ecommerce_Website.Data;

namespace Ecommerce_Website.Pages.Admin.ProductSetup
{
    public class IndexModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        public IndexModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.SubCategory).Include(x => x.Images).ToListAsync();
        }
    }
}
