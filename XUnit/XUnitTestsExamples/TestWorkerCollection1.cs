using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitProject;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestsExamples
{
    [Collection("Worker Collection")]
    public class TestWorkerCollection1
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;

        public TestWorkerCollection1(WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        public void TestWorker1()
        {
            Assert.Equal("Juanito", workerFixture.Worker.Name);
            output.WriteLine($"Worker ID: {workerFixture.Worker.ID}");
            output.WriteLine($"Worker Name: {workerFixture.Worker.Name}");
            TestWorkerFixture.IDsList.Add(workerFixture.Worker.ID);
        }

        [Fact]
        public void TestWorker2()
        {
            output.WriteLine($"Worker ID: {workerFixture.Worker.ID}");
            output.WriteLine($"Worker Name: {workerFixture.Worker.Name}");
            TestWorkerFixture.IDsList.Add(workerFixture.Worker.ID);
        }
    }
}
