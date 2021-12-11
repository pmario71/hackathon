using Frontend.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestControlController : Controller
    {
        private readonly ILogger<TestControlController> _logger;

        public TestControlController(ILogger<TestControlController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> StartTest(StartTestRequest request)
        {
            _logger.LogInformation("Start Test called:");

            await Task.Delay(2000);

            _logger.LogInformation("finished Start Test called");

            return Ok();
        }
    }
}
