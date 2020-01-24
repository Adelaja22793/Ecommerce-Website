using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Ecommerce_Website.Pages.Admin.SubCateg
{
    public class CreateModel : PageModel
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;

        [BindProperty]
        public IFormFile BannerImage { get; set; }

        public CreateModel(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MainCategoryId"] = new SelectList(_context.MainCategories, "Id", "Id");
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
            }

            

            return RedirectToPage("./Index");
        }
    }
}