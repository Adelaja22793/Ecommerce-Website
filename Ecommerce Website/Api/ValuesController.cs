using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_Website.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce_Website.Api
{
   public class ValuesViewModel
    {
        public String ActualAdress { get; set; }
    }



    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        [HttpGet("ByName")]
        public string Get([FromQuery]int id, [FromQuery] string name)
        {
            return $"Name : {name} and ID {id}";
        }

      
      
        [HttpGet("AddressById")]
        public Address GetAddressById([FromQuery]int id)
        {
            var listOfAddress = new List<Address>
            {

               new Address{Id = 1, CustomerId="1",ActualAddress="lagos",Title="home" },
               new  Address{Id = 2, CustomerId="1",ActualAddress="lagos",Title="home" },
               new Address{Id = 3, CustomerId="1",ActualAddress="lagos",Title="home" } 
            };

            var requestedAddress = listOfAddress.FirstOrDefault(x => x.Id == id);
            return requestedAddress;
        }
        


        [HttpGet("AddressList")]
        public List<ValuesViewModel> GetAllAddress()
        {
            var listOfAddress = new List<Address>
            {

               new Address{Id = 1, CustomerId="1",ActualAddress="lagos",Title="home" },
               new  Address{Id = 2, CustomerId="1",ActualAddress="lagos",Title="home" },
               new Address{Id = 3, CustomerId="1",ActualAddress="lagos",Title="home" }
            };

            var data = listOfAddress.Select(x => new ValuesViewModel { ActualAdress = x.ActualAddress }).ToList();



            return data;
        }


        // POST api/<controller>
        [HttpPost] 
        public IActionResult Post([FromBody]Address address)
        {
            if (ModelState.IsValid)
            {

                return Ok($"Address with Name : { address.Title} was saved successfully");
            }
            else { return BadRequest("Invalid Model");  }



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
    }
}
