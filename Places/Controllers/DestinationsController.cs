using Microsoft.AspNetCore.Mvc;
using Places.Models;
using System.Collections.Generic;

namespace Places.Controllers
{
    public class DestinationsController : Controller
    {

        [HttpGet("/destinations")]
        public ActionResult Index()
        {
            List<Destination> allDestinations = Destination.GetAll();
            return View(allDestinations);
        }

        [HttpGet("/categories/{categoryId}/destinations/new")]
        public ActionResult New(int categoryId)
        {
            Category category = Category.Find(categoryId);
            return View(category);
        }

        // [HttpGet("/destinations/new")]
        // public ActionResult New()
        // {
        //     return View();
        // }

        [HttpPost("/destinations/delete")]
        public ActionResult DeleteAll()
        {
            Destination.ClearAll();
            return View();
        }

        // [HttpPost("/destinations")]
        // public ActionResult Create(string cityName, string description)
        // {
        //     Destination myDestination = new Destination(cityName, description);
        //     return RedirectToAction("Index");
        // }

        // // [HttpGet("/destinations/{id}")]
        // // public ActionResult Show(int id)
        // // {
        // //     Destination foundDestination = Destination.Find(id);
        // //     return View(foundDestination);
        // // }

        [HttpGet("/categories/{categoryId}/destinations/{destinationId}")]
        public ActionResult Show(int categoryId, int destinationId)
        {
            Destination destination = Destination.Find(destinationId);
            Category category = Category.Find(categoryId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("destination", destination);
            model.Add("category", category);
            return View(model);
        }
    }
}