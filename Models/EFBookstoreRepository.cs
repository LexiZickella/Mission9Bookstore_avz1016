using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        //
        private BookstoreContext context { get; set; }

        // require a bookstore file to be passed in
        public EFBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
