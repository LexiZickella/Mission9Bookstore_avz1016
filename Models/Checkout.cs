using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }

        // this is referencing the Basket.cs file and the BasketLineItem class, ICollection: a collection of information
        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }
        [Required(ErrorMessage ="Please enter the Name: ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the First Address: ")]
        public string AddressLine1 { get; set; }
        public string AddreassLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Please enter the City: ")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter the State: ")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter the Country: ")]
        public string Country { get; set; }
        public bool Anonymous { get; set; }
        public int OrderId { get; internal set; }
    }
}
