using System;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class WorkerFixture : IDisposable
    {
        public Worker Worker { get; set; }

        public WorkerFixture()
        {
            Worker = new Worker("Lacuna", "Coil");
        }

        public void Dispose()
        {
            //Cleanup
        }
    }
}
