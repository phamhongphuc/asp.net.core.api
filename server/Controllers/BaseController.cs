using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using server.Businesses;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public Account CurrentUser
        {
            get
            {
                var email = User.Claims.First(i => i.Type == ClaimTypes.Email).Value;
                return AccountBusiness.GetByEmail(email);
            }
        }
    }
}
