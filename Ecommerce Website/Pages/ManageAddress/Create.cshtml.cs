using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce_Website
{
    [Authorize(Roles = "Customer,Admin")]
    public class CreateModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        public CreateModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Address Address { get; set; }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Addresses.Add(Address);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}