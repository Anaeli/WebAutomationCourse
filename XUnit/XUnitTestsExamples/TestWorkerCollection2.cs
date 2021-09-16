using Xunit;
using Xunit.Abstractions;

namespace XUnitTestsExamples
{
    //Sharing Instance in different classes
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
        }

        [Fact]
        public void TestWorker2()
        {
            output.WriteLine($"Worker ID2: {workerFixture.Worker.ID}");
        }
    }
}
