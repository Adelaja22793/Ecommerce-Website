using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Http;
using Ecommerce_Website.UtilityMethods;

namespace Ecommerce_Website.Pages.Admin.ProductSetup
{
    public class CreateModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        [BindProperty]
        public List<IFormFile> ProductImage { get; set; }

        public CreateModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SubCategoryList"] = new SelectList(_context.SubCategories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            { 
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            var prdId = Product.Id;
            var images = new List<Image>();

            foreach(var img in ProductImage)
            {
                if (img != null && img.Length > 0)
                {
                     
                    var filePath = await FileUpload.UploadFile(img, "productimages");
                    images.Add(new Image { Link = filePath, ProductId = prdId });
                }
            }

            _context.Images.AddRange(images);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}