using System.Collections.Generic;
using Xunit;
using XUnitProject;
using XUnitTests;
namespace XUnitTestsExamples
{
    public class PracticeFirstPart
    {
           [Fact]
        public void FullNameCheck()
        {
            HR worker1 = new HR("Ruddy","torrez");
            Assert.True(worker1.FullName == "Ruddy torrez");
            
        }
            [Fact]
        public void ExpectedFullName()
        {
            HR worker1 = new HR("Ruddy","torrez");
            Assert.Equal("Ruddy torrez", worker1.FullName);
            
        }

            [Fact]
        public void StartEndwith()
        {
            HR worker1 = new HR("Ruddy","torrez");
            Assert.StartsWith("Ru", worker1.Name);
            Assert.EndsWith("dy", worker1.Name);
        }
            [Fact]
        public void upperCase()
        {
            HR worker1 = new HR("RUDDY","torrez");
            Assert.Equal("TOrRez", worker1.LastName, ignoreCase:true);
            
        }
             [Fact]
        public void RegExp()
        {
            HR worker1 = new HR("ruddy","TORREZ");
            Assert.Matches("[a-z]+ [A-Z]+", worker1.FullName);
            
        }
             [Fact]
        public void emptyValue()
        {
            HR worker1 = new HR("ruddy","");
            Assert.Empty(worker1.LastName);
            
        }

             [Fact]
        public void Numbers()
        {
            Rest r1 = new();
            Assert.Equal(-2,r1.restInt(3,5));
            Addition a1= new();
            Assert.InRange<int>(a1.RandomNumber(), 600, 700);
        }
             [Fact]
        public void Double()
        {
            Rest r1 = new();
            Assert.Equal(-2.113,r1.restDouble(3.554,5.667),3);
        }
        [Fact]
        public void Collection()
        {
            Company company = new();
            HR hr1 = new("Eliana", "Navia");
            HR hr2 = new("Juan", "Perez");
            HR hr3 = new("Ruddy", "Torrez");
            HR hr4 = new("juan", "Torrez");

            List<HR> hrList = new()
            {
                hr1,hr2,hr3
            };

            company.Workers = new List<Worker>
            {
                hr1,hr2,hr3
            };
            

            Assert.Equal(hrList, company.Workers);
            Assert.Contains(hr1, company.Workers);
            Assert.DoesNotContain(hr4, company.Workers);
            Assert.Contains(hrList, Worker => Worker.Name.Contains("Eliana"));
            hr1.Salary="3000";
            hr2.Salary="3000";
            hr3.Salary="3000";
            Assert.All(company.Workers, Worker => Assert.False(string.IsNullOrWhiteSpace(Worker.Salary)));
        }

    }
}