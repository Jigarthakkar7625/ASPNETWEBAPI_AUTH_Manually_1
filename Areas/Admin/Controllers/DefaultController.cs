using ASPNETWEBAPI_AUTH_Manually_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASPNETWEBAPI_AUTH_Manually_1.Areas.Admin.Controllers
{
    [RoutePrefix("Admin/api/Default")]
    public class DefaultController : ApiController
    {
        [Route("MyRegister")]
        [HttpGet]
        public async Task<IHttpActionResult> MyRegister()
        {
            return Ok();
        }
    }
}
