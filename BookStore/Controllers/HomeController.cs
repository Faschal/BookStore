﻿using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult index()
        {
            ViewData["book"] = new Book() { Author = "Alex", Id = 1};
            return View();
        }

        public ViewResult aboutUs()
        {
            return View();
        }

        public ViewResult contactUs()
        {
            return View();
        }
    }
}
