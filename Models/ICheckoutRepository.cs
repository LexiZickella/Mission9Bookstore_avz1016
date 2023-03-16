using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Models
{
    public interface ICheckoutRepository
    {
        public IQueryable<Checkout> Checkouts { get; }
        public void SaveCheckout(Checkout checkout);
    }
}
