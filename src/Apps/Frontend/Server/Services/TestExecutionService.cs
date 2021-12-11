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

        public async Task<TestStatusUpdate> StartTestExecutionAsync(TestLevel testLevel)
        {
            TestStatusUpdate update = new TestStatusUpdate()
            {
                TestLevel = testLevel,
                TestId = Interlocked.Increment(ref _testId),
                Message = "Started test"
            };
            StartTestExecutionInternal(update);

            return update;
        }

        private void StartTestExecutionInternal(TestStatusUpdate update)
        {
            Task.Run(async () =>
            {
                // =======================================
                // test execution goes here
                // =======================================
                string typeOfTest = update.TestLevel.ToString();

                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    update.Message = $"'{typeOfTest}' executing: {i * 10}%";

                    await _channel.Writer.WriteAsync(update);
                }
                update.Message = $"test completed!";
                update.Completed = true;

                await _channel.Writer.WriteAsync(update);
            });
        }

        public async IAsyncEnumerable<TestStatusUpdate> SubscribeToTestStatusUpdate()
        {
            TestStatusUpdate update;
            while (true)
            {
                update = await _channel.Reader.ReadAsync();
                yield return update;
            }
        }
    }
}
