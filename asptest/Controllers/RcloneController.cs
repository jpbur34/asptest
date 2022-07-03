using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InotASPNetCoreStub.Controllers
{
    [ApiController]
    [Route("api/rclone")]
    public class RcloneController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public RcloneController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("stub")]
        public async Task<string> Get()
        {
            int port = Request.HttpContext.Connection.LocalPort;

            return $"rclone stub ok ({port})";
        }
    }
}
