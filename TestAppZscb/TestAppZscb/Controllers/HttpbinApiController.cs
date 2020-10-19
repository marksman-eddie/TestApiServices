using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryTestApi.Model.Httpbin.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LibraryTestApi;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace TestAppZscb.Controllers
{
    [Route("api/[controller]")]
    public class HttpbinApiController : Controller
    {
        private readonly HttpbinClient _client;

        public HttpbinApiController(HttpbinClient client) => _client = client;

        [HttpGet("basicAuth")]
        public BasicAuthResponseModel BasicAuth(BasicAuthRequestModel authQuery)
        {
            return _client.BasicAuth(authQuery);
        }

        [HttpGet("digestAuth")]
        public DigestAuthResponseModel DigestAuth(DigestAuthRequestModel authQuery)
        {
            return _client.DigestAuth(authQuery);
        }


        [HttpGet("getImage")]
        public IActionResult GetImage()
        {          
            return File(_client.GetImage(), "image/jpeg");

        }
    }
}
