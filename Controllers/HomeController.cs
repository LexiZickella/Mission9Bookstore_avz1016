﻿using Microsoft.AspNetCore.Mvc;
using Mission9Bookstore_avz1016.Models;
using Mission9Bookstore_avz1016.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016.Controllers
{
    public class HomeController : Controller
    {
        // instance of the respository
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookType, int pageNum = 1)
        {
            int pageSize = 5;

            var x = new BooksViewModel
            {
                // load the books
                Books = repo.Books
                .Where(b => b.Category == bookType || bookType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // load the pageinfo
                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                    (bookType == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category ==  bookType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            // sharing view to Index throught razor code
            return View(x);
        }

    }
}
