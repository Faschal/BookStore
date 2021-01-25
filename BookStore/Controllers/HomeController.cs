﻿using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {   
        [Route("~/")]
        public ViewResult index()
        {            
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
