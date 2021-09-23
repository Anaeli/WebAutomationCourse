using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class WorkerFixture :IDisposable
    {
        public Worker Worker { get; private set; }

        public WorkerFixture()
        {
            Worker = new Worker("Harry", "Grajeda");
        }

        public void Dispose()
        {
            //cleanup
        }
    }
}
