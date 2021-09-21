using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    [Collection("Worker Collection")]
    public class TestWorkerCollection2
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;

        public TestWorkerCollection2(WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
                        
        }
        [Fact]
        public void TestWorker1()
        {
        output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
        
        }
        [Fact]
        public void TestWorker2()
        {
        output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
        
        }
    }
}