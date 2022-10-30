using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DIController : ControllerBase
    {
    

        private readonly ILogger<DIController> _logger;

        public DIController(ILogger<DIController> logger)
        {
            _logger = logger;
        }

        
    }
}