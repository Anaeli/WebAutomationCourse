using Xunit;
using Xunit.Abstractions;

namespace XUnitTestsExamples
{
    [Collection("Worker collection")]
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
        public void TestProject1()
        {
            output.WriteLine($"Project ID: {workerFixture.worker.ID}");
            output.WriteLine($"Project Name: {workerFixture.worker.Name}");
        }

        [Fact]
        public void TestProject2()
        {
            output.WriteLine($"Project ID: {workerFixture.worker.ID}");
            output.WriteLine($"Project Name: {workerFixture.worker.Name}");
        }
    }
}
