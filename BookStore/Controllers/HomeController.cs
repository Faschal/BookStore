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
        private readonly IEmailService _emailService;

        public HomeController(IUserService userService,
                                IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        [Route("~/")]
        public async Task<ViewResult> index()
        {
            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "test@gmail.com" },
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{ Username }}", "Alex")
            //    }
            //};

            //await _emailService.SendTestEmail(options);

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
