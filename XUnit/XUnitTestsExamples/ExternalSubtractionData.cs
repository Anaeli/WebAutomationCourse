using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XUnitTestsExamples
{
    public class ExternalSubtractionData
    {
        public static IEnumerable<object[]> TestDataPractice
        {
            get
            {
                string[] csvLines = File.ReadAllLines("TestDataPractice.csv");
                var testCases = new List<Object[]>();
                foreach (var csvLine in csvLines)
                {
                    IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);
                    object[] testCase = values.Cast<object>().ToArray();
                    testCases.Add(testCase);
                }
                return testCases;
            }
        }
    }
}
