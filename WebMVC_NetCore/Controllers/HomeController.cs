﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC_NetCore.Models;

namespace WebMVC_NetCore.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //[ValidateAntiForgeryToken()]
        public ActionResult TransferAmt()
        {
            // Money transfer logic goes here
            return Content(" has been transferred to account ");
        }
    }
}