﻿using Xunit;
using Xunit.Abstractions;

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
        }

        [Fact]
        public void TestWorker1 ()
        {
            output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
            output.WriteLine($"Worker Name: {workerFixture.worker.Name}");
        }

        [Fact]
        public void TestWorker2()
        {
            output.WriteLine($"Worker ID: {workerFixture.worker.ID}");
            output.WriteLine($"Worker Name: {workerFixture.worker.Name}");
        }
    }
}
