﻿using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        [Route("Post/{url}")]
        public IActionResult Index(string url)
        {
            return View();
        }
    }
}