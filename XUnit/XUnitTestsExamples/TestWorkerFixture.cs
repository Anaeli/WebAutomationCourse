using Xunit;
using Xunit.Abstractions;

namespace XUnitTestsExamples
{
    public class TestWorkerFixture : IClassFixture<WorkerFixture>
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;

        public TestWorkerFixture (WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        public void TestWorkerIDMethod1()
        {
            output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
            Assert.Equal("Daniela", workerFixture.worker.Name);
        }

        [Fact]
        public void TestWorkerIDMethod2()
        {
            output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
            Assert.Equal("Fernandez", workerFixture.worker.LastName);
        }
    }
}
