using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using server.Authentication;
using server.Businesses;
using server.Middleware.Error;
using server.Models;

namespace server.Controllers.Base
{
    [Route("api/[controller]")]
    public class BaseController : Controller { }
}
