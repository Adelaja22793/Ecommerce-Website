﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Website.Data
{
    public class Image
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public String Link { get; set; }
    }
}
