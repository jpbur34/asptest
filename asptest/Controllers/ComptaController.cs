using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace InotASPNetCoreStub.Controllers
{
    public class ComptaFilter : ActionFilterAttribute
    {
        private IDisposable _logProperty = null;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int port = context.HttpContext.Connection.LocalPort;

            if (port != 30001)
            {
                throw new Exception("only port 30100 is authorized");
            }
        }
        
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            
        }
    }

    [ApiController]
    [Route("api")]
    public class ComptaController : ControllerBase
    {
        private readonly ILogger<iNotController> _logger;
        private Random rnd = new Random();

        public ComptaController(ILogger<iNotController> logger)
        {
            _logger = logger;
        }

        [ComptaFilter]
        [HttpGet("ServeurInfos")]
        public async Task<string> Get()
        {
            int port = Request.HttpContext.Connection.LocalPort;

            int tempo = rnd.Next(100, 300);
            await Task.Delay(tempo);
            return $"iNotComptabilité ({port})";
        }
    }
}
