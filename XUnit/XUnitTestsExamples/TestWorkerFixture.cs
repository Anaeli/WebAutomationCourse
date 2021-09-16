using Xunit;
using Xunit.Abstractions;

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
        public void TestStartProject()
        {
            workerFixture.worker.WorkHour = 8;
            workerFixture.worker.Salary = "1000";

            Assert.Equal("Jessica", workerFixture.worker.Name);
            Assert.Equal("1000", workerFixture.worker.GetSalary());
            output.WriteLine($"Project Id: {workerFixture.worker.ID}");
            output.WriteLine($"Project Name: {workerFixture.worker.Name}");
            output.WriteLine($"Project Salary: {workerFixture.worker.Salary}");
            output.WriteLine($"Project WorkHour: {workerFixture.worker.WorkHour}");
        }

        [Fact]
        public void TestEndProject()
        {
            output.WriteLine($"Project ID: {workerFixture.worker.ID}");
            output.WriteLine($"Project Name: {workerFixture.worker.Name}");
            output.WriteLine($"Project Id: {workerFixture.worker.WorkHour}");
        }
    }
}
