using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9Bookstore_avz1016.Models;

namespace Mission9Bookstore_avz1016.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket cartService)
        {
            basket = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
