using System;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class WorkerFixture : IDisposable
    {
        public Worker Worker { get; private set; } 

        public WorkerFixture()
        {
            Worker = new Worker("Juanito", "Nieves");
        }

        public void Dispose()
        {
            //cleanup
        }
    }
}
