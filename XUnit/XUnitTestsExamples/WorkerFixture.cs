using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class WorkerFixture : IDisposable
    {
        public Worker Worker { get; private set; }

        public WorkerFixture()
        {
            Worker = new Worker("John", "Snow");
        }

        public void Dispose()
        {
            //cleanup
        }
    }
}
