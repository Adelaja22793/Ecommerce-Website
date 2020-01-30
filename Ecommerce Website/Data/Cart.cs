using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Ecommerce_Website.Data.Enumerations;

namespace Ecommerce_Website.Data
{
    public class Cart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey("Colour")]
        public int? SelectedColourId { get; set; }

        public DateTime? DateAdded { get; set; } = DateTime.Now;

        public CartState CartState { get; set; }
        [ForeignKey("Address")]
        public int? SelectedAddressId { get; set; }
        public Customer Customer { get; set; }

        public Product Product { get; set; }

        public Colour Colour { get; set; }

        public Address Address { get; set; }





    }



}
