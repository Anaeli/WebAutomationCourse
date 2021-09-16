using Xunit;
using Xunit.Abstractions;


namespace XUnitTestsExamples
{
    [Collection("Worker collection")]
    public class TestWorkerCollection
    {
        public readonly WorkerFixture workerFixture;
        public readonly ITestOutputHelper output;

        public TestWorkerCollection(WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        public void TestWorker()
        {
            output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
            output.WriteLine($"Worker name: {workerFixture.worker.Name}");
        }

        [Fact]
        public void TestWorker2()
        {
            output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
            output.WriteLine($"Worker name: {workerFixture.worker.Name}");
        }
    }
}
