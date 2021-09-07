using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class PracticeFirstPart
    {
        [Fact]
        public void BooleanTest()
        {
            HumanResource hr = new("Juanito", "Nieves");
            Assert.Contains(hr.Name, hr.FullName);
            Assert.StartsWith("Ju", hr.Name);
            Assert.EndsWith("to", hr.Name);

            HumanResource hr2 = new("JUANITO", "nieves");
            Assert.True(hr2.LastName.ToLower().Equals("Nieves".ToLower()));
            
            HumanResource hr3 = new("juanito", "NIEVES");
            Assert.True(hr2.LastName.ToLower().Equals("Nieves".ToLower()));
            Assert.Matches("[a-z]+ [A-Z]+", hr3.FullName);

            HumanResource hr4 = new("Juanito", "");
            Assert.Empty(hr4.LastName);
        }

        [Fact]
        public void NumbersTest()
        {
            Rest rest = new();
            Assert.Equal(40, rest.RestInt(50, 10));

            Addition addition = new();
            Assert.InRange<int>(addition.RandomNumber(), 600, 700);
        }

        [Fact]
        public void DoubleTest()
        {
            Rest rest = new();
            Assert.Equal(16.153, rest.RestDouble(17.276, 1.1234), 3);
        }

        [Fact]
        public void CollectionTest()
        {
            Company company = new();
            HumanResource hr1 = new("Juanito", "Nieves");
            HumanResource hr2 = new("Roberto", "Bateon");
            HumanResource hr3 = new("Dany", "Tancara");
            HumanResource hr4 = new("Bran", "Estrella");

            List<Worker> hrList = new()
            {
                hr1, hr2, hr3
            };
            company.Workers = new List<Worker>
            {
                hr1, hr2, hr3
            };

            Assert.Equal(hrList, company.Workers);
            Assert.Contains(hr1, company.Workers);
            Assert.DoesNotContain(hr4, company.Workers);
            Assert.Contains(company.Workers, worker => worker.LastName.Contains("Tancara"));

            hr1.Salary = "20k";
            hr2.Salary = "18k";
            hr3.Salary = "21k";
            hr4.Salary = "0.5k";

            Assert.All(company.Workers, worker => Assert.False(string.IsNullOrEmpty(worker.Salary)));
        }



    }
}
