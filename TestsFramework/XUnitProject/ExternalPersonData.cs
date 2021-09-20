using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XUnitProject
{
    public class ExternalPersonData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                string[] csvLines = File.ReadAllLines("TestData.csv");
                var testCases = new List<Object[]>();
                foreach(var csvLine in csvLines)
                {
                    IEnumerable<string> values = csvLine.Split(',');
                    object[] testCase = values.Cast<object>().ToArray();
                    testCases.Add(testCase);
                }
                return testCases;
            }
        }
    }
}
