using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Models.ViewModels
{
    public class BooksViewModel
    {
        // original books dataset 
        public IQueryable<Book> Books { get; set; }
        // pageinfo
        public PageInfo PageInfo { get; set; }
    }
}
