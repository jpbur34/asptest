using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InotASPNetCoreStub.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class iNotController : ControllerBase
    {
        private readonly ILogger<iNotController> _logger;
        private Random rnd = new Random();

        public iNotController(ILogger<iNotController> logger)
        {
            _logger = logger;
        }

        [HttpGet("configurationEtude")]
        public async Task<string> Get()
        {
            int port = Request.HttpContext.Connection.LocalPort;
            int tempo = rnd.Next(100, 300);
            await Task.Delay(tempo);
            return $"NomEtude ({port})";
        }

        [HttpGet("BibleInfo")]
        public async Task<string> BibleInfo()
        {
            int tempo = rnd.Next(100, 300);
            await Task.Delay(tempo);
            return "Format";
        }

        [HttpGet("EndpointAuthenticated")]
        public async Task<string> EndpointAuthenticated()
        {
            if (HttpContext.Request.Headers.ContainsKey("Authorization") == false)
            {
                throw new Exception("Authorization header must be present");
            }
            else
            {
                var headerauth = HttpContext.Request.Headers["Authorization"];
                bool bearerfound = false;
                foreach (string value in headerauth)
                {
                    if (value.IndexOf("Bearer") > -1) bearerfound = true;
                }
                if (bearerfound ==false)
                {
                    throw new Exception("Bearer must be present");
                }
            }

            return "OK";
        }
    }
}
