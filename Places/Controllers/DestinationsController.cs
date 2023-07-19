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

        [HttpGet("/destinations/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/destinations/delete")]
        public ActionResult DeleteAll()
        {
            Destination.ClearAll();
            return View();
        }

        [HttpPost("/destinations")]
        public ActionResult Create(string description)
        {
            Destination myDestination = new Destination(description);
            return RedirectToAction("Index");
        }

        [HttpGet("/destinations/{id}")]
        public ActionResult Show(int id)
        {
            Destination foundDestination = Destination.Find(id);
            return View(foundDestination);
        }

    }
}