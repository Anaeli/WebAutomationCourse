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

        [Fact]
        public void TestSharedIDMethods()
        {
            Assert.NotEmpty(TestWorkerFixture.IDsList);
            Assert.All(TestWorkerFixture.IDsList, workerID => Assert.Equal(workerID, workerFixture.Worker.ID));
        }
    }
}
