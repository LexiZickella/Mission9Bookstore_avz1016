﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Models
{
    public class Basket
    {
        //  declares new items and sunstantiating items
        public List<BasketLineItem> Items { get; set; }  = new  List<BasketLineItem>();

        public void AddItem (Book boo, int qty)
        {
            // the functionality to add an item to a list of basketlineitems
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == boo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = boo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        
        public double CalculateTotal()
        {
            // the summ needs to be cahnged to a dynamic value. NOT 25!!
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}