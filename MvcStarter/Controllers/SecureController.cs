using MvcStarter.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcStarter.Controllers
{
    [Authorize]
    public class SecureController : ApiController
    {
        private readonly ApplicationUserManager _userManger;

        public SecureController(ApplicationUserManager userManager)
        {
            _userManger = userManager;
        }


        [HttpGet]
        [Route("api/me")]
        public IHttpActionResult Me()
        {
            return Ok(true);
        }
    }
}
