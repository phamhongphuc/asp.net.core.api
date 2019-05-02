using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [Route("api/[controller]")]
    public abstract class BaseController : Controller { }
}
