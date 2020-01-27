using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Ecommerce_Website.Pages.Admin.SubCateg
{
    public class CreateModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        public string Message { get; set; }
        public string Error { get; set; }
         
        [BindProperty]
        public IFormFile BannerImage { get; set; }

        public CreateModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MainCategoryList"] = new SelectList(_context.MainCategories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SubCategory SubCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
              
                return Page();
            }

            if(BannerImage != null && BannerImage.Length > 0)
            {
                var fileName = DateTime.Now.Ticks.ToString() + BannerImage.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    @"wwwroot\productimages", fileName );
                await BannerImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
                SubCategory.BannerImage = fileName;

                _context.SubCategories.Add(SubCategory);
                await _context.SaveChangesAsync();
              
                return RedirectToPage("./Index");  
            }
            else
            {
                
                Error = "Banner image is required";

                return Page();
            }
        }
    }
}     