using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class TestWorkerFixture : IClassFixture<WorkerFixture>
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;
        public static List<Guid> IDsList = new List<Guid>();

        public TestWorkerFixture(WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        public void TestWorkerFixtureDefaultName()
        {
            Assert.Equal("Juanito", workerFixture.Worker.Name);
            IDsList.Add(workerFixture.Worker.ID);
        }

        [Fact]
        public void TestWorkerFixtureDefaultLastName()
        {
            Assert.Equal("Nieves", workerFixture.Worker.LastName);
            IDsList.Add(workerFixture.Worker.ID);
        }

        [Fact]
        public void TestSharedIDMethods()
        {
            Assert.NotEmpty(IDsList);
            Assert.All(IDsList, workerID => Assert.Equal(workerID, workerFixture.Worker.ID));
        }
    }
}
