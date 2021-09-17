using System;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class WorkerFixture : IDisposable
    {
        public Worker Worker { get; private set; } 

        public WorkerFixture()
        {
            Worker = new Worker("John", "Snow");
        }

        public void Dispose()
        {
            //cleanup
        }
    }
}
