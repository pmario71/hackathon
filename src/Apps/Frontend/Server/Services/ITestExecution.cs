using Frontend.Shared;

namespace Frontend.Server.Services
{
    public interface ITestExecution
    {
        IAsyncEnumerable<TestStatusUpdate> SubscribeToTestStatusUpdate();

        Task<TestStatusUpdate> StartTestExecutionAsync(TestLevel testLevel);
    }
}
