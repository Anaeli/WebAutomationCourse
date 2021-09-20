using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MSTestProject
{
    [TestClass]
    public class UnitTestDataDriven
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 45, 20, 45 };
                yield return new object[] { 100, 99, 101 };
            }
        }

        [DataTestMethod]
        [DataRow(45, 20, 45)]
        [DataRow(65, 50, 74)]
        [DataRow(100, 50, 101)]
        [TestCategory("Example")]
        public void TestMethodDataDriven(int num, int num1, int num2)
        {
            Console.WriteLine("Testing numbers...");
            int i = num;
            Assert.IsTrue(i > num1 && i <= num2, $"num i = {i}, num1 {num1}, num2 {num2}");
        }


        [DataTestMethod]
        [DynamicData(nameof(TestData))]
        [TestCategory("Example")]
        public void TestMethodDataDriven1(int num, int num1, int num2)
        {
            Console.WriteLine("Testing numbers...");
            int i = num;
            Assert.IsTrue(i > num1 && i <= num2, $"num i = {i}, num1 {num1}, num2 {num2}");
        }

        [DataTestMethod]
        [DynamicData(nameof(NumberData.TestData),
                     typeof(NumberData),
                     DynamicDataSourceType.Method)]
        [TestCategory("Example")]
        public void TestMethodDataDriven2(int num, int num1, int num2)
        {
            Console.WriteLine("Testing numbers...");
            int i = num;
            Assert.IsTrue(i > num1 && i <= num2, $"num i = {i}, num1 {num1}, num2 {num2}");
        }


        [DataTestMethod]
        [DynamicData(nameof(NumberCsvData.TestData),
                     typeof(NumberCsvData))]
        public void TestMethodDataDriven3(int num, int num1, int num2)
        {
            Console.WriteLine("Testing numbers...");
            int i = num;
            Assert.IsTrue(i > num1 && i <= num2, $"num i = {i}, num1 {num1}, num2 {num2}");
        }
    }
}
