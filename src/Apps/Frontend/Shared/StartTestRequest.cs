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
}
