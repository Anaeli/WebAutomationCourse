using NUnit.Framework;
using Persons;
using System;
using System.Collections.Generic;

namespace NUnitProject
{
    // Optional
    // [Ignore ("Ignore all test methods")]
    // Documentation: https://docs.nunit.org/ 
    //[Category("Examples")]
    [ExampleAttribute]
    public class Tests
    {
        private Person person;
        private Person personEliana;

       /// <summary>
       /// Simulate long setup init time for this person
       /// we assume that this person will not be modified by any tests
       /// as this will potentially break other tests (i.e. break test isolation)
       /// </summary>       
       [OneTimeSetUp]
       public void OneTimeSetUp()
        {
            // Run once before tests execution
            personEliana = new();
            personEliana.Name = "Eliana";
            personEliana.LastName = "Navia";
        }

        [SetUp]
        public void Setup()
        {
            // Runs before each test executes
            person = new Person();
        }

        [Test]
        [Category("Person")]
        public void Test1()
        {
            Assert.That($"{personEliana.Name} {personEliana.LastName}", Is.EqualTo(personEliana.FullName));
        }

        [Test]
        public void Test2()
        {
            Person person1 = new();
            person1.Name = "Eliana";
            person1.LastName = "Navia";
            Person person2 = person1;

            Person person3 = new();
            person3.Name = "Juan";
            person3.LastName = "Perez";
            person3.Age = 25;

            List<Person> personList = new()
            {
                person1,
                person2,
            };         

            List<Person> personList1 = personList;

            List<Person> personList2 = new()
            {
                person1,
            };

            List<Person> personList3 = new()
            {
                person1,
                person3,
            };

            // Object
            Assert.That(person1, Is.SameAs(person2));

            //List
            Assert.That(personList, Is.SameAs(personList1));
            Assert.That(personList, Is.Not.SameAs(personList2));

            Assert.That(personList, Has.Exactly(2).Items);
            Assert.That(personList3, Is.Unique);
            Assert.That(personList, Does.Contain(person1));

            Assert.That(personList3, Has.Exactly(1)
                .Property("Name").EqualTo("Juan")
                .And
                .Property("LastName").EqualTo("Perez")
                .And
                .Property("Age").GreaterThan(20));

            Assert.That(personList3, Has.Exactly(1)
                .Matches<Person>(item => item.Name == "Juan" &&
                                         item.Age > 20));
        }


        [Test]
        [Category("Example")]
        [Category("Numbers")]
        public void Test3()
        {
            int sumResult = 3 + 4;
            double a = 1.0 / 3.0;

            Assert.That(7, Is.EqualTo(sumResult));
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }

        /// <summary>
        /// Cmd: dotnet test --filter "TestCategory=Example"
        /// </summary>
        [Test]
        [Category("Example")]
        public void TestBoolean()
        {
            bool isNew = true;
            Assert.That(isNew);
            Assert.That(isNew, Is.True);

            bool areMarried = false;
            Assert.That(areMarried == false);
            Assert.That(areMarried, Is.False);
            Assert.That(areMarried, Is.Not.True);
        }

        [Test]
        public void TestRange()
        {
            int i = 42;

            Assert.That(i, Is.GreaterThan(20));
            Assert.That(i, Is.GreaterThanOrEqualTo(42));
            Assert.That(i, Is.LessThan(50));
            Assert.That(i, Is.LessThanOrEqualTo(42));
            Assert.That(i, Is.InRange(40, 50));

            DateTime d1 = new(2020, 2, 20);
            DateTime d2 = new(2020, 2, 25);

            Assert.That(d1, Is.Not.EqualTo(d2));
            Assert.That(d1, Is.EqualTo(d2).Within(8).Days);
        }

        [Test]
        [TestCase("Eliana", "Navia", TestName = "Verify person fullname")]
        public void TestString(string name, string lastName)
        {
            person.Name = name;
            person.LastName = lastName;
            Assert.AreEqual($"{person.Name} {person.LastName}", person.FullName);
            Assert.That(name.ToUpper, Is.EqualTo(person.Name).IgnoreCase);
            Assert.That(name, Does.StartWith("El"));
            Assert.That(name, Does.EndWith("ana"));
            Assert.That(name, Does.Contain("lia"));
            Assert.That(name, Does.Not.Contain("Am"));
            Assert.That(name, Does.StartWith("El").Or.EndsWith("ana"));
            Assert.That(person.FullName.Equals($"{person.Name} {person.LastName}"), $"Name: {person.Name} LastName: {person.LastName}");
            Assert.That(() => person.GetNickName(), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase("Eliana", "Navia")]
        [TestCase("Juan", "Perez")]
        public void TestDataDriven(string name, string lastName)
        {
            person.Name = name;
            person.LastName = lastName;
            Assert.AreEqual($"{person.Name} {person.LastName}", person.FullName);
            Assert.That(name.ToUpper, Is.EqualTo(person.Name).IgnoreCase);
        }

        [Test]
        [TestCase(2, 5, ExpectedResult = 7)]
        [TestCase(5, 3, ExpectedResult = 8)]
        public int TestDataDriven1(int num1, int num2)
        {
            int sumResult = num1 + num2;
            return sumResult;
        }

        [Test]
        [TestCaseSource(typeof(PersonTestData), "TestData")]
        public void TestDataDrivenTestData(string name, string lastName)
        {
            person.Name = name;
            person.LastName = lastName;
            Assert.AreEqual($"{person.Name} {person.LastName}", person.FullName);
            Assert.That(name.ToUpper, Is.EqualTo(person.Name).IgnoreCase);
        }

        [Test]
        [TestCaseSource(typeof(PersonCsvData), "TestData")]
        public void TestDataDrivenCsvTestData(string name, string lastName)
        {
            person.Name = name;
            person.LastName = lastName;
            Assert.AreEqual($"{person.Name} {person.LastName}", person.FullName);
            Assert.That(name.ToUpper, Is.EqualTo(person.Name).IgnoreCase);
        }

        [Test]
        [Ignore("Test to Ignore")]
        public void TestSkip()
        {
            person.Name = "Eliana";
            person.LastName = "Navia";
            Assert.AreEqual($"{person.Name} {person.LastName}", person.FullName);
            Assert.That(person.Name, Is.Not.EqualTo(person.FullName), "Message"); ;
        }

        [TearDown]
        public void TearDown()
        {
            // Runs after each test executes
            // person.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Runs once after tests execution
            // person.Dispose();
        }
    }
}