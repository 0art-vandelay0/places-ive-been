using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Places.Models;

namespace Places.Controllers
{
    public class CategoriesController : Controller
    {

        [HttpGet("/categories")]
        public ActionResult Index()
        {
            List<Category> allCategories = Category.GetAll();
            return View(allCategories);
        }


        [HttpGet("/categories/new")]
        public ActionResult New()
        {
            return View();
        }

        // This one creates new Category (see below Create() comment):
        [HttpPost("/categories")]
        public ActionResult Create(string categoryName)
        {
            Category newCategory = new Category(categoryName);
            return RedirectToAction("Index");
        }


        // This one creates new Destinations within a given Category, not new Categories:
        [HttpPost("/categories/{categoryId}/destinations")]
        public ActionResult Create(int categoryId, string cityName, string destinationDescription)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category foundCategory = Category.Find(categoryId);
            Destination newDestination = new Destination(cityName, destinationDescription);
            foundCategory.AddDestination(newDestination);
            List<Destination> categoryDestinations = foundCategory.Destinations;
            model.Add("destinations", categoryDestinations);
            model.Add("category", foundCategory);
            return View("Show", model);
        }

        // this is orginal destinations/ Create, above was updated and moved here bc it updates the categories list before destinations as categories contain the destinations
        // [HttpGet("/destinations/{id}")]
        // public ActionResult Show(int id)
        // {
        //     Destination foundDestination = Destination.Find(id);
        //     return View(foundDestination);
        // }

        [HttpGet("/categories/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category selectedCategory = Category.Find(id);
            List<Destination> categoryDestinations = selectedCategory.Destinations;
            model.Add("category", selectedCategory);
            model.Add("destinations", categoryDestinations);
            return View(model);
        }
    }
}