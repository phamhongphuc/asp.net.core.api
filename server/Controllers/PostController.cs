using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        // GET: /api/post
        [HttpGet]
        public ActionResult<string> List()
        {
            return "Get A List";
        }

        // GET: /api/post/7
        [HttpGet("{id:int}")]
        public ActionResult<string> Item(int id)
        {
            return "Get An Item";
        }

        // POST: /api/post
        [HttpPost]
        public ActionResult<string> AddPost()
        {
            return "Add a new post";
        }
    }
}
