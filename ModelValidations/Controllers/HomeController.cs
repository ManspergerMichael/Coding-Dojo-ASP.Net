using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelValidations.Models;

namespace ModelValidations.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home(){
            return View("Home");
        }

        [HttpPost("user/create")]
        public IActionResult Create(User user){
            if(ModelState.IsValid){
                return RedirectToAction("Success");
            }
            else{
               return View("Home");
            }
        }
        [HttpGet]
        [Route("Success")]
        public IActionResult Success(){
            return View("Success");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
