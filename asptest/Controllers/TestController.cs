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
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private Random rnd = new Random();
        static byte[] fileBytes;
        static string fileName = "download.msi";
        static FileContentResult content = null;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;

           

            _logger.LogInformation("test controller constructor");
        }

        [HttpGet("simple")]
        public async Task<string> Get()
        {
            int tempo = rnd.Next(100, 300);
            await Task.Delay(tempo);
            return "simple3";
        }

        [HttpGet("slow")]
        public async Task<string> GetSlow()
        {
            
            await Task.Delay(30000);
            return "slow";
        }

        [HttpGet("file")]
        public FileContentResult File()
        {
            try
            {
                var mimeType = "application/octet-stream";

                return content;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"error in donwload : {ex.Message.ToString()}");
            }

            return null;
        }

    }
}
