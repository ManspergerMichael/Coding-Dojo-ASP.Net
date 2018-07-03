    using Microsoft.AspNetCore.Mvc;
    namespace ASPTest.Controllers     //be sure to use your own project's namespace!
    {
        public class HelloController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public IActionResult Index()
            {
                ViewBag.Example = "Hello World!";
                return View("Hello");
            }

            /*Example of routers
                [HttpGet]
                [Route("template/{name}")]
                public JsonResult Method(string name)
                {
                    // Method body
                }
                [HttpGet]
                [Route("template/{id}/{action}")]
                public JsonResult Method(int id, string action)
                {
                    // Method body
                }
            */
        }
    }
