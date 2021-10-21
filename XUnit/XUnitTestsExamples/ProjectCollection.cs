using Xunit;

namespace XUnitTestsExamples
{
    [CollectionDefinition("Project collection")]
    public class ProjectCollection : ICollectionFixture<ProjectFixture> { }
}
