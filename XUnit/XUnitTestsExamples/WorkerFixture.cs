using System;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class WorkerFixture : IDisposable
    {
        public Worker worker { get; private set; }

        public WorkerFixture()
        {
            worker = new Worker("Daniela", "Fernandez");
        }
        public void Dispose()
        {
           //cleanup
        }
    }
}
