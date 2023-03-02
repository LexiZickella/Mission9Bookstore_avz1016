using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Models.ViewModels
{
    // stores information about the page
    public class PageInfo
    {
        // number of pages
        public int TotalNumBooks { get; set; }
        // number of books on a page
        public int BooksPerPage { get; set; }
        // page being viewed
        public int CurrentPage { get; set; }

        // Figure out how many pages we need, by casting to a decimal finding the ceiling and changing it back into an int
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
