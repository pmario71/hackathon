using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Shared
{
    public class StartTestRequest
    {
        public TestLevel TestLevel { get; set; }
    }

    public enum TestLevel
    {
        RegressionTest,
        StressTest,
    }

    public record TestStatusUpdate
    {
        public int TestId { get; set; } = 0;

        public TestLevel TestLevel { get; init; }

        public string Message { get; set; } = "na";

        public bool Completed { get; set; } = false;
    }
}
