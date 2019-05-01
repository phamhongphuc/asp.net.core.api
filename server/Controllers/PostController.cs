using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        // GET: /api/post
        [HttpGet]
        public ActionResult<string> Index()
        {
            return "Index";
        }
    }
}
