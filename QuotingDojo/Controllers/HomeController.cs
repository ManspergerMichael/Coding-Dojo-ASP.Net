using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector cnx;

        public HomeController(){
            cnx = new DbConnector();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View("Home");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            
            string query = "SELECT * FROM User";
            var allUsers = DbConnector.Query(query);
            ViewBag.allUsers = allUsers;
            return View("Quotes");
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string name, string quote){
            string query = $"INSERT INTO User(Name, Quote) VALUES('{name}','{quote}')";
            DbConnector.Execute(query);
            return RedirectToAction("quotes");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
