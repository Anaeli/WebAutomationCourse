using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestsExamples
{
    public class TestWorkerFixture : IClassFixture<WorkerFixture>
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;
        public static List<Guid> IdList = new List<Guid>();

        public TestWorkerFixture(WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        public void TestWorkerFixtureName()
        {
            Assert.Equal("John", workerFixture.Worker.Name);
            IdList.Add(workerFixture.Worker.ID);
        }

        [Fact]
        public void TestWorkerFixtureLastName()
        {
            Assert.Equal("Snow", workerFixture.Worker.LastName);
            IdList.Add(workerFixture.Worker.ID);
        }

        [Fact]
        public void TestSharedIDMethods()
        {
            Assert.All(IdList, workerID => Assert.Equal(workerID, workerFixture.Worker.ID));
        }
    }
}
