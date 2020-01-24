using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Website.Data
{
    public class Colour
    {

        public int Id { get; set; }

        public string Name { get; set; }


        public String Code { get; set; }


        public ICollection<ProductColour> ProductColours { get; set; }
    }
}
