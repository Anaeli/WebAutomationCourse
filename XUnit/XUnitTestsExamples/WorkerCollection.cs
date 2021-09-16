using Xunit;

namespace XUnitTestsExamples
{
    [CollectionDefinition("Worker collection")]
    public class WorkerCollection : ICollectionFixture<WorkerFixture>
    {
    }
}
