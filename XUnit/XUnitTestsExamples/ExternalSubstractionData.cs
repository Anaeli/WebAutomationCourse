using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XUnitTestsExamples
{
    public class ExternalSubstractionData
    {
        public static IEnumerable<object[]> SubstractionTestData
        {
            get
            {
                string[] csvLines = File.ReadAllLines("SubstractionTestData.csv");
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
