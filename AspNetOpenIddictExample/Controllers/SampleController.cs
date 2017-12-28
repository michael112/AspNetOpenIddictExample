using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationServer.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public string AdminMethod()
        {
            return "access_granted";
        }
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public string UserMethod()
        {
            return "access_granted";
        }
        [HttpGet("useroradmin")]
        [Authorize(Roles = "Admin, User")]
        public string UserOrAdminMethod()
        {
            return "access_granted";
        }
    }
}
