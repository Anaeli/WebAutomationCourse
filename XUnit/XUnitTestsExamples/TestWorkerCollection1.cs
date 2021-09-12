using Xunit;
using Xunit.Abstractions;
using XUnitProject;

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
            workerFixture.Worker.Name = "Rayus";
        }

        [Fact]
        public void TestWorker1()
        {
            //workerFixture.Worker.Name = "Rayus";
            output.WriteLine($"Worker Name: {workerFixture.Worker.Name}");
        }
        [Fact]
        public void TestWorker2()
        {
            output.WriteLine($"ID Name: {workerFixture.Worker.ID}");
        }
    }
}
