using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MSTestProject
{
    // dotnet test --filter "ClassName=MSTestProject.Lifecycle" -v n
    [TestClass]
    public class Lifecycle
    {
        static string someTestContext;

        [TestInitialize]
        public void LifecycleInit()
        {
            Console.WriteLine("Test Initialize Lifecycle");
        }

        [TestCleanup]
        public void LifecycleClean()
        {
            Console.WriteLine("Test Cleanup Lifecycle");
        }

        [ClassInitialize]
        public static void LifecycleClassInit(TestContext context)
        {
            Console.WriteLine("Class Initialize Lifecycle");
            Console.WriteLine("Data loaded from disk or some expensive object creation");
            someTestContext = "42";
        }

        [ClassCleanup()]
        public static void LifecycleClassClean()
        {
            Console.WriteLine("Class Clean Lifecycle");
            // ClassCleanup is executed - put a breakpoint inside your method and verify it yourself.
            // Problem is, that this method is executed after all of your tests are completed, 
            // so you cannot write message from that method in test output report. 
        }

        [TestMethod]

        public void TestA()
        {
            Console.WriteLine("Test A Starting....");
            Console.WriteLine($"Shared test context: {someTestContext}");
        }

        [TestMethod]

        public void TestB()
        {
            Console.WriteLine("Test B Starting....");
            Console.WriteLine($"Shared test context: {someTestContext}");
        }
    }
}
