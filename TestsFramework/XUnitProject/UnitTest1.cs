using System;
using Xunit;
using Xunit.Abstractions;

namespace XUnitProject
{
    public class UnitTest1 : IClassFixture<PersonFixture>, IDisposable
    {
        private readonly ITestOutputHelper output;
        private readonly PersonFixture person;
        public UnitTest1(PersonFixture person, ITestOutputHelper output)
        {            
            this.person = person;
            this.output = output;
            this.output.WriteLine("Init test...");
        }

        [Fact]
        public void Test1()
        {
            person.Person.Name = "Eliana";
            person.Person.LastName = "Navia";
            Assert.Equal($"{person.Person.Name} {person.Person.LastName}", person.Person.FullName);
            Assert.Throws<ArgumentNullException>(() => person.Person.GetNickName());
            this.output.WriteLine($" Person ID : {person.Person.ID}");
        }

        [Fact]
        [Trait("Category", "Person")]
        public void Test2()
        {
            person.Person.Name = "Eliana";
            person.Person.LastName = "Navia";
            Assert.Equal($"{person.Person.Name} {person.Person.LastName}", person.Person.FullName);
            this.output.WriteLine($" Person ID : {person.Person.ID}");
        }

        [Theory]
        [InlineData("Eliana", "Navia")]
        [InlineData("Juan", "Perez")]
        public void Test3(string name, string lastName)
        {
            person.Person.Name = name;
            person.Person.LastName = lastName;
            Assert.Equal($"{person.Person.Name} {person.Person.LastName}", person.Person.FullName);
            this.output.WriteLine($" Person ID : {person.Person.ID}");
        }

        public void Dispose()
        {
            this.output.WriteLine("Clean test...");
        }
    }

    public class UnitTest2 : IClassFixture<PersonFixture>
    {
        private readonly ITestOutputHelper output;
        private readonly PersonFixture person;
        public UnitTest2(PersonFixture person, ITestOutputHelper output)
        {
            this.person = person;
            this.output = output;
        }

        [Theory(DisplayName = "Data driven - InternalData")]
        [MemberData(nameof(PersonData.TestData),
            MemberType = typeof(PersonData))]
        public void TestInternalData(string name, string lastName)
        {
            person.Person.Name = name;
            person.Person.LastName = lastName;
            Assert.Equal($"{person.Person.Name} {person.Person.LastName}", person.Person.FullName);
            this.output.WriteLine($" Person ID : {person.Person.ID}");
            this.output.WriteLine($" Person FullName : {person.Person.FullName}");
        }

        [Theory(DisplayName = "Data driven - ExternalData")]
        [MemberData(nameof(ExternalPersonData.TestData),
            MemberType = typeof(ExternalPersonData))]
        public void TestExternalData(string name, string lastName)
        {
            person.Person.Name = name;
            person.Person.LastName = lastName;
            Assert.Equal($"{person.Person.Name} {person.Person.LastName}", person.Person.FullName);
            this.output.WriteLine($" Person ID : {person.Person.ID}");
            this.output.WriteLine($" Person FullName : {person.Person.FullName}");
        }


        [Fact(Skip = "Don't need to run this")]
        public void TestSkip()
        {
            person.Person.Name = "Zeila";
            person.Person.LastName = "Benavidez";
            Assert.Equal($"{person.Person.Name} {person.Person.LastName}", person.Person.FullName);
            this.output.WriteLine($" Person ID : {person.Person.ID}");
        }
    }
}