using System;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class WorkerFixture : IDisposable
    {
        public Worker Worker
        { get; private set; }

        public WorkerFixture()
        {
            Worker = new Worker("Yoko", "Onno");
        }

        public void Dispose()
        {
            //cleanup
        }
    }
}