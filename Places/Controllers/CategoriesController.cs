using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Places.Models;

namespace Places.Controllers
{
    public class CategoriesController : Controller
    {
        [HttpGet("/categories/new")]
        public ActionResult New()
        {
            return View();
        }
    }
}