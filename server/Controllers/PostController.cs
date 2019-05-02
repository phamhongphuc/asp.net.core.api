using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    /// <summary>
    /// Post Controller
    /// </summary>
    public class PostController : BaseController
    {
        /// <summary>
        /// Get A List of Post
        /// </summary>
        [HttpGet]
        public ActionResult<string> Index() { return "A list"; }

        /// <summary>
        /// Get a Post
        /// </summary>
        /// <param name="id">Post Id</param>
        [HttpGet("{id:int}")]
        public ActionResult<string> Item(int id) { return "An item"; }

        /// <summary>
        /// Create a new Post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Post() { return "Post"; }
    }
}
