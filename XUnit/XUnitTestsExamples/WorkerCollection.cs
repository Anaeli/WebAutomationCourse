using Xunit;

namespace XUnitTestsExamples
{
    [CollectionDefinition("Worker Collection")]
    public class WorkerCollection : ICollectionFixture<WorkerFixture>
    {

    }
}