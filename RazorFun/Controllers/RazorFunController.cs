using Microsoft.AspNetCore.Mvc;
namespace RazorFun.Controllers{
    public class RazorFunController : Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Home(){
            return View("RazorFun");
        }
    }
}