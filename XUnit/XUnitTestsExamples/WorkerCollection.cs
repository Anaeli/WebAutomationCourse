using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitProject;
using Xunit;

namespace XUnitTestsExamples
{
    [CollectionDefinition("Worker Collection")]
    public class WorkerCollection : ICollectionFixture<WorkerFixture> { }
}
