 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce_Website
{
    [Authorize(Roles = "Customer,Admin")]
    public class IndexModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        public IndexModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }

        public async Task OnGetAsync()
        {
            Address = await _context.Addresses.ToListAsync();
        }
    }
}
