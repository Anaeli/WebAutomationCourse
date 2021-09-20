using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MSTestProject
{
    [TestClass]
    public class Assembly
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Console.WriteLine("AssemblyInit");
        }

        [AssemblyCleanup]
        public static void AssemblyClean()
        {
            Console.WriteLine("AssemblyClean");
            // AssemblyCleanup is executed - put a breakpoint inside your method and verify it yourself.
            // Problem is, that this method is executed after all of your tests are completed, 
            // so you cannot write message from that method in test output report. 
        }
    }
}
