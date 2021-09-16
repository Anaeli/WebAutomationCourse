using System;
using XUnitTests;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class WorkerFixture : IDisposable
    {
        public Worker worker { get; private set; }

        public WorkerFixture ()
        {
            worker = new Worker("Jose", "Avila");
        }

        public void Dispose()
        {
            //Clean..
        }
    }
}
