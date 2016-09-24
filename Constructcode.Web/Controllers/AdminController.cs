﻿using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return Ok();
        }
    }
}
