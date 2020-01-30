using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Website.Pages.Customer.Products
{
    // ensure that only a logged in user can access this page Authorize(Roles =the role)
    [Authorize(Roles = "Customer,Admin")]
    public class GroupModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public SubCategory SubCategory { get; set; }

        

        public GroupModel(Ecommerce_Website.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
         {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? subgroupId)
        {
            if (subgroupId != null)
            {
                //get the sub category that has the id
                SubCategory = await _context
                    .SubCategories
                    .Include(m => m.products)
                    .ThenInclude(l => l.Images)
                    .FirstOrDefaultAsync(n => n.Id == subgroupId.Value);
                return Page();
               
            }
            else
            {

                return NotFound();
            }
           
        }




        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product != null)
            {
                var cart = new Cart();
                cart.ProductId = product.Id;
                cart.Quantity = 1;
                cart.CartState = Enumerations.CartState.InCart;



                //_context.Carts.Add(cart);
            }

            return Page();
        }



        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
    


  
}