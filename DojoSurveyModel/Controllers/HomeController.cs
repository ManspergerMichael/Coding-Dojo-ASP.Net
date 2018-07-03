using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyModel.Models;

namespace DojoSurveyModel.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home(){
            return View("Home");
        }

        [HttpPost("survey")]
        public IActionResult survey(Ninja submittedNinja){
            /* ViewBag.name = submittedNinja.name;
            ViewBag.language = submittedNinja.language;
            ViewBag.location = submittedNinja.location;
            ViewBag.comment = submittedNinja.comment; */
            return View("result", submittedNinja);
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
