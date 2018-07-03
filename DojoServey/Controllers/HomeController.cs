using Microsoft.AspNetCore.Mvc;
namespace DojoServey.Controllers{
    public class DojoServeyController: Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Home(){
            return View("Home");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string name, string location, string language,string comment){
            //System.Console.WriteLine(name);
            return RedirectToAction("result", new {name = name,location = location,language=language,comment=comment});

        }

        [HttpGet]
        [Route("result/{name}/{location}/{language}/{comment}")]
        public IActionResult result(string name, string location,string language, string comment){
           ViewBag.name = name;
           ViewBag.location = location;
           ViewBag.language = language;
           ViewBag.comment = comment;
           return View("result");
        }
    }
}