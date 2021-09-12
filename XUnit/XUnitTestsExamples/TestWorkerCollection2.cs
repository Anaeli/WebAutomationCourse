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
            output.WriteLine($"Worker Name: {workerFixture.Worker.Name}");
        }
        [Fact]
        public void TestWorker2()
        {
            output.WriteLine($"ID Name: {workerFixture.Worker.ID}");
        }
    }
}
