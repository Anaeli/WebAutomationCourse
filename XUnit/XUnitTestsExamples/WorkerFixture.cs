using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnitTests;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class WorkerFixture: IDisposable
    {    
    
        public Worker worker { get; private set; }

        public WorkerFixture()
        {
            worker = new Worker("Ruddy","Torrez");
        }

        public void Dispose()
        {
            //cleanup
        }
    
    }
}