using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission9Bookstore_avz1016.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Models
{
    // setting a  session for the website
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            // checking to see if there is already an associated sessionBasket but if not then it will make a new sessionBasket
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        ISession Session { get; set; }
        public override void AddItem(Book boo, int qty)
        {
            base.AddItem(boo, qty);
            // setJson is brought in from the Infrastructure file
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book boo)
        {
            base.RemoveItem(boo);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }

    }
}
