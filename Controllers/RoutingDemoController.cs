
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNETWEBAPI_AUTH_Manually_1.Controllers
{
    [RoutePrefix("api/RoutingDemo")]
    public class RoutingDemoController : ApiController
    {
        // /api/RoutingDemo/GetData
        [Route("~/GetDataList/{userid}/{userid12?}")] // It will not consider RoutePrefix
        // /api/RoutingDemo/GetDataList
        // /api/RoutingDemo/GetDataList/1/2
        // /api/RoutingDemo/GetDataList
        public IHttpActionResult GetData(int? userid = null, int? userid12 = null)
        {
            return Ok();
        }
    }
}
