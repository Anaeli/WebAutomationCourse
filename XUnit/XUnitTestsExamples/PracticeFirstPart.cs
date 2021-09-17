using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class PracticeFirstPart : IDisposable
    {
        private readonly ITestOutputHelper output;

        public PracticeFirstPart(ITestOutputHelper output)
        {
            this.output = output;
            this.output.WriteLine("Init execution...");
        }

        [Fact(DisplayName = "String Test")]
        [Trait("Category", "String")]
        public void BooleanTest()
        {
            this.output.WriteLine("String Test");

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

        [Fact(DisplayName = "Number Test Int")]
        [Trait("Category", "Operations")]
        [Trait("Operations", "Int")]
        public void NumbersTest()
        {
            this.output.WriteLine("Number Test Int");

            Rest rest = new();
            int a = 50;
            int b = 10;

            Assert.Equal(40, rest.RestInt(a, b));

            Addition addition = new();
            Assert.InRange<int>(addition.RandomNumber(), 600, 700);

            this.output.WriteLine($"Substraction of two numbers (int): {rest.RestInt(a, b)}");
        }

        [Fact(DisplayName = "Number Test Double")]
        [Trait("Category", "Operations")]
        [Trait("Operations", "Double")]
        public void DoubleTest()
        {
            this.output.WriteLine("Number Test Double");

            Rest rest = new();
            double a = 17.276;
            double b = 1.1234;
            int c = 3;

            Assert.Equal(16.153, rest.RestDouble(a, b), c);

            this.output.WriteLine($"Substraction of two numbers (double): {rest.RestDouble(a, b)}");
        }

        [Fact(DisplayName = "Collection Test")]
        [Trait("Category", "Collections")]
        public void CollectionTest()
        {
            this.output.WriteLine("Collection Test");

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

        [Fact(DisplayName = "Type Test")]
        [Trait("Category", "Type")]
        public void TypeTest()
        {
            Company company = new();
            HumanResource hr1 = new("Juanito", "Nieves");
            HumanResource hr2 = new("Roberto", "Bateon");
            
            Assert.IsType<HumanResource>(hr1);
            Assert.IsNotType<Manager>(hr1);
            Assert.IsAssignableFrom<Worker>(hr1);
            Assert.NotSame(hr1, hr2);
        }

        [Fact(DisplayName = "Null Test")]
        [Trait("Category", "Null")]
        public void NullTest()
        {
            HumanResource hr1 = new("Juanito", "Nieves");
            hr1 = null;

            Assert.Throws<NullReferenceException>(() => hr1.IsHRnull(hr1));           
        }



        public void Dispose()
        {
            output.WriteLine("Cleaning code...");
        }
    }
}
