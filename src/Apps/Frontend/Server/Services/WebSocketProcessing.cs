using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace Frontend.Server.Services
{
    public class WebSocketProcessing
    {
        private readonly ITestExecution _testExecutionService;

        public WebSocketProcessing(ITestExecution testExecutionService)
        {
            _testExecutionService = testExecutionService;
        }
        public async Task Process(HttpContext http)
        {
            using WebSocket webSocket = await http.WebSockets.AcceptWebSocketAsync();

            var subscription = _testExecutionService.SubscribeToTestStatusUpdate();

            await foreach (var item in subscription)
            {
                var json = JsonSerializer.Serialize(item);
                await webSocket.SendAsync(Encoding.UTF8.GetBytes(json), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
