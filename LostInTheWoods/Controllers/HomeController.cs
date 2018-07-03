using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostInTheWoods.Models;
using LostInTheWoods.Factory;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController(){
            trailFactory = new TrailFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Home(){
            ViewBag.trails = trailFactory.FindAll();
            return View("Home");
        }
        [HttpGet]
        [Route("NewTrail")]
        public IActionResult NewTrail(){
            return View("Add");
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(string trailName, string Description, double trailLength, double elevationChange, double Longitude, double Latitude){
            Trail insert = new Trail(trailName,Description,trailLength,elevationChange,Longitude,Latitude);
            trailFactory.Add(insert);
            return RedirectToAction("Home");

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
