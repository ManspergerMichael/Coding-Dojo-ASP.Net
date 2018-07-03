using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {

        private RestContext _context;

        public HomeController(RestContext context){
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Home(){
            
            return View("Home");
        }
        
        [HttpPost("Create")]
        public IActionResult Create(reviews review){
            System.Console.WriteLine("Hello review");
            if(ModelState.IsValid){
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else{
                System.Console.WriteLine("Should return errors");
                return View("Home",review);
            }
            
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews(){
            List<reviews> returned = _context.reviews.OrderByDescending(rev =>rev.date).ToList();
            ViewBag.reviews = returned;
            return View("Reviews");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
