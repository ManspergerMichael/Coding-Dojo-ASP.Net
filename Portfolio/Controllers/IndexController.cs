using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controlers{
    public class IndexController : Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        [Route("/projects")]
        public IActionResult Projects(){
            return View();
        }

        [HttpGet]
        [Route("/contact")]
        public IActionResult Contact(){
            return View();
        }
    }
}