using System;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class ProjectFixture : IDisposable
    {
        public Project Project { get; private set; }

        public ProjectFixture()
        {
            Project = new Project();
        }

        public void Dispose()
        {
            //cleanup
        }
    }
}
