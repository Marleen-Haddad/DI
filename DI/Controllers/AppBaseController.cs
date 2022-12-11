using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    public class AppBaseController<T> : ControllerBase
    {
        public readonly ILogger<T> _logger;
        public AppBaseController(ILogger<T> logger) { 

        _logger = logger;

        }
    }
}
