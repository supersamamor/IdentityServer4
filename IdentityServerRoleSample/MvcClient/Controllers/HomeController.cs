using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Constants;
using MvcClient.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      
        public IActionResult Index()
        {
            return View();
        }     
       
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Policy = AuthorizationConsts.Module1Policy)]
        public IActionResult Module1()
        {
            return View();
        }
        [Authorize(Policy = AuthorizationConsts.Module2Policy)]
        public IActionResult Module2()
        {
            return View();
        }
        [Authorize(Policy = AuthorizationConsts.Module3Policy)]
        public IActionResult Module3()
        {
            return View();
        }
    }
}
