
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestsExamples
{
    [Collection("Project collection")]
    public class TestProjectCollection2
    {
        private readonly ProjectFixture projectFixture;
        private readonly ITestOutputHelper output;

        public TestProjectCollection2(ProjectFixture projectFixture, ITestOutputHelper output)
        {
            this.projectFixture = projectFixture;
            this.output = output;
        }

        [Fact]
        public void TestProject1()
        {
            output.WriteLine($"Project ID: {projectFixture.Project.ID}");
            output.WriteLine($"Project Name: {projectFixture.Project.Name}");
        }

        [Fact]
        public void TestProject2()
        {
            output.WriteLine($"Project ID: {projectFixture.Project.ID}");
            output.WriteLine($"Project Name: {projectFixture.Project.Name}");
        }
    }
}
