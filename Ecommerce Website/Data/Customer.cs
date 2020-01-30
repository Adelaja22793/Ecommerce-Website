using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Website.Data
{
    public class Customer: IdentityUser
    {

        public string CardNumber { get; set; }
        List<Address> Addresses { get; set; }
    }
}
