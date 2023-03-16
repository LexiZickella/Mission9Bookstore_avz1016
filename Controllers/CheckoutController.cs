using Microsoft.AspNetCore.Mvc;
using Mission9Bookstore_avz1016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Basket basket { get; set; }
        public CheckoutController (ICheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Correspond()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Correspond(Checkout checkout)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty. Add the books you'd like to purchase to your cart.");
            }
            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkout);
                basket.ClearBasket();

                return RedirectToPage("/CheckoutCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
