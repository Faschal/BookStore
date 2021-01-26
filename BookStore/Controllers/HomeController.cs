using BookStore.Models;
using BookStore.Service;
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
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("~/")]
        public ViewResult index()
        {
            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();

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
