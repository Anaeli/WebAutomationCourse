using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using XUnitProject;

namespace XUnitTestsExamples
{
    [CollectionDefinition("Worker Collection")]
    public class WorkerCollection : ICollectionFixture<WorkerFixture>
    {
        
    }
}