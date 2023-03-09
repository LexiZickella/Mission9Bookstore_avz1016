using Microsoft.AspNetCore.Mvc;
using Mission9Bookstore_avz1016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Components
{
    // Data+Model part set up for the component 
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
