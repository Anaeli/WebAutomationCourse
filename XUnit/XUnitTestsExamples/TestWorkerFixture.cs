using Xunit;
using Xunit.Abstractions;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class TestWorkerFixture: IClassFixture<WorkerFixture>
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;

        public TestWorkerFixture(WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        public void TestStartWorker()
        {
            //Worker worker1 = new("test", "123");
            //workerFixture.Worker = worker1;
            //workerFixture.Worker.Name = "Rayus";
            output.WriteLine($"Worker ID: {workerFixture.Worker.ID}");
            output.WriteLine($"Worker FullName: {workerFixture.Worker.FullName}");
        }

        [Fact]
        public void TestEndWorker()
        {
            Assert.IsType<Worker>(workerFixture.Worker);
            output.WriteLine($"Worker ID: {workerFixture.Worker.ID}");
            output.WriteLine($"Worker FullName: {workerFixture.Worker.FullName}");
        }
    }
}
