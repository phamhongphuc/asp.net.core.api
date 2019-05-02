using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Home/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
