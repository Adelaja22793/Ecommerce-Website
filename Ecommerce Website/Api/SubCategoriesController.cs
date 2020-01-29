using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce_Website.Api
{
    [Route("api/[controller]")]
    public class SubCategoriesController : Controller
    {
        private readonly Ecommerce_Website.Data.ApplicationDbContext _context;



        public SubCategoriesController(Ecommerce_Website.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        [HttpGet("AllSubCategories")]
        public async Task<List<SubCategory>> GetAllSubCategoriesAsync()
        {
            var subCategories = await _context.SubCategories.ToListAsync();
            return subCategories;
        }


        [HttpGet("SubCategoryById")]
        public async Task<SubCategory> GetSubCategoryByIdAsync([FromQuery] int id)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(p => p.Id == id);
            return subCategory;
        }



        [HttpGet("AllSubCategoriesSameId")]
        public async Task<List<SubCategory>> GetAllSubCategoriesSameIdAsync([FromQuery] int id)
        {
            var subList = await _context.SubCategories.Include(x => x.MainCategory).Where(i => i.MainCategory.Id == id).ToListAsync(); 

            foreach(var sub in subList)
            {
                sub.MainCategory = null;
            }
            return subList;
        }


    }
}

