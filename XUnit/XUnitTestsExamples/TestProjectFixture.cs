using Xunit;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class TestProjectFixture : IClassFixture<ProjectFixture>
    {
        private readonly ProjectFixture projectFixture;
        private readonly ITestOutputHelper output;


        public TestProjectFixture(ProjectFixture projectFixture, ITestOutputHelper output)
        {
            this.projectFixture = projectFixture;
            this.output = output;
        }

        [Fact]
        public void TestStartProject()
        {
            Manager manager = new("Zeila", "Benavidez");
            Enginer enginer1 = new("Eliana", "Navia");
            Enginer enginer2 = new("Juan", "Perez");

            //Project project = new();
            //project.Manager = manager;
            //project.Enginers.Add(enginer1);
            //project.Enginers.Add(enginer2);
            //project.StartProject();
            //Assert.Contains(enginer1, project.Enginers);
            //Assert.Equal("Zeila", project.Manager.Name);
            //Assert.Equal("Started", project.State);

            projectFixture.Project.Manager = manager;
            projectFixture.Project.Enginers.Add(enginer1);
            projectFixture.Project.Enginers.Add(enginer2);
            projectFixture.Project.Name = "HighJump";
            projectFixture.Project.StartProject();

            Assert.Contains(enginer1, projectFixture.Project.Enginers);
            Assert.Equal("Zeila", projectFixture.Project.Manager.Name);
            Assert.Equal("Started", projectFixture.Project.State);
            output.WriteLine($"Project Id: {projectFixture.Project.ID}");
        }

        [Fact]
        public void TestEndProject()
        {
            //Manager manager = new("Zeila", "Benavidez");
            //Enginer enginer1 = new("Eliana", "Navia");
            //Enginer enginer2 = new("Juan", "Perez");
            //Project project = new();
            //project.Manager = manager;
            //project.Enginers.Add(enginer1);
            //project.Enginers.Add(enginer2);
            //project.EndProject();
            //Assert.Empty(project.Enginers);
            //Assert.Null(project.Manager);
            //Assert.Equal("Finished", project.State);

            output.WriteLine($"Project ID: {projectFixture.Project.ID}");
            output.WriteLine($"Project Name: {projectFixture.Project.Name}");

            projectFixture.Project.EndProject();
            Assert.Empty(projectFixture.Project.Enginers);
            Assert.Null(projectFixture.Project.Manager);
            Assert.Equal("Finished", projectFixture.Project.State);
        }
    }
}
