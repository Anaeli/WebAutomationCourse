using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitProject;
using XUnitTests;
using Xunit.Abstractions;
using Xunit;

namespace XUnitTestsExamples
{
    public class TestWorkerFixture : IClassFixture<WorkerFixture>
    {
        private readonly WorkerFixture workerFixture;
        private readonly ITestOutputHelper output;

        public TestWorkerFixture (WorkerFixture workerFixture, ITestOutputHelper output)
        {
            this.workerFixture = workerFixture;
            this.output = output;
        }

        [Fact]
        public void TestWorkerAttributesMethod1()
        {
            output.WriteLine($"Worker Id is {workerFixture.worker.ID}");
            Assert.Equal("Jose", workerFixture.worker.Name);
        }

        [Fact]
        public void TestWorkerAttributesMethod2()
        {
            output.WriteLine($"Worker Id is {workerFixture.worker.ID}");
            Assert.Equal("Jose", workerFixture.worker.Name);
        }
    }
}
