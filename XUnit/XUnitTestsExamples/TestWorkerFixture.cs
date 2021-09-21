using System;
using Xunit;
using Xunit.Abstractions;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class TestWorkerFixture : IClassFixture<WorkerFixture>
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;
        public TestWorkerFixture(WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        [Trait("Workers", "ID")]
        public void IsIdBeingShared()
        {
            var workerId1 = workerFixture.Worker.ID;
            output.WriteLine($"Worker Id: {workerId1}");
            Assert.Equal(workerId1, workerFixture.Worker.ID);
        }
    }
}