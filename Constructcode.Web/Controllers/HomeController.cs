﻿using Microsoft.AspNetCore.Mvc;

namespace ConstructCode.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult Index()
        {
            ViewBag.AngularModule = "app";
            ViewBag.ShowFooter = true;
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.AngularModule = "app";
            return View();
        }
    }
}