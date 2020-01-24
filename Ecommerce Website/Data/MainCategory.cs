using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Website.Data
{
    public class MainCategory
    {

        public int Id { get; set; }

        public String Name { get; set; }


        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
