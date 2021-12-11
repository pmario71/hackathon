using Frontend.Shared;
using System.Threading.Channels;

namespace Frontend.Server.Services
{
    class TestExecutionService : ITestExecution, IDisposable
    {
        Channel<TestStatusUpdate> _channel = Channel.CreateBounded<TestStatusUpdate>(10);
        int _testId = 0;

        public void Dispose()
        {
            _channel.Writer.Complete();
        }

        public async Task<TestStatusUpdate> StartTestExecutionAsync()
        {
            TestStatusUpdate update = new TestStatusUpdate()
            {
                TestId = Interlocked.Increment(ref _testId),
                Message = "Started test"
            };
            await _channel.Writer.WriteAsync(update);

            return update;
        }

        public async IAsyncEnumerable<TestStatusUpdate> SubscribeToTestStatusUpdate()
        {
            TestStatusUpdate update;
            while (true)
            {
                update = await _channel.Reader.ReadAsync();
                yield return update;

                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    update.Message = $"test executing: {i * 10}%";

                    yield return update;
                }
                update.Message = $"test completed!";
                update.Completed = true;

                yield return update;
            }
        }
    }
}
