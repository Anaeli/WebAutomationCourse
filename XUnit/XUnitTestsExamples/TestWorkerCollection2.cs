using Xunit;
using Xunit.Abstractions;

namespace XUnitTestsExamples
{
    [Collection("Worker collection")]
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
        public void TestWorker()
        {
            output.WriteLine($"worker ID: {workerFixture.worker.ID}");
            output.WriteLine($"Wroker name: {workerFixture.worker.Name}");
        }

        [Fact]
        public void TestWorker2()
        {
            output.WriteLine($"worker ID: {workerFixture.worker.ID}");
            output.WriteLine($"Wroker name: {workerFixture.worker.Name}");
        }
    }
}
