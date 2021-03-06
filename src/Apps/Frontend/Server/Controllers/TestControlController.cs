using Frontend.Server.Services;
using Frontend.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace Frontend.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestControlController : Controller
    {
        private readonly ILogger<TestControlController> _logger;
        private readonly ITestExecution _testExecutionService;

        public TestControlController(ILogger<TestControlController> logger, ITestExecution testExecutionService)
        {
            _logger = logger;
            _testExecutionService = testExecutionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public async Task<TestStatusUpdate> StartTest(StartTestRequest request)
        {
            // test is going on in background, errors are reported through websocket connection
            var statusUpdate = await _testExecutionService.StartTestExecutionAsync(request.TestLevel);

            _logger.LogInformation("Started test execution ...");

            return statusUpdate;
        }
    }
}
