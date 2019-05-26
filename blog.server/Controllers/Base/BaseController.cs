using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using blog.server.Authentication;
using blog.server.Businesses;
using blog.server.Middleware.Error;
using blog.server.Models;

namespace blog.server.Controllers.Base
{
    [Route("api/[controller]")]
    public class BaseController : Controller { }
}
