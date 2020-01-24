using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Website.Data
{
    public class SubCategory
    {

        public int Id { get; set; }

        public String Name { get; set; }


        public int MainCategoryId { get; set; }

        public MainCategory MainCategory { get; set; }

        public string BannerImage { get; set; }

        public List<Product> products { get; set; }
    }
}
