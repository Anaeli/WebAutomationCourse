using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        // dotnet test --filter "TestCategory=Example"
        [TestMethod]
        [TestCategory("Example")]
        public void TestMethod1()
        {
            Person person = new();
            person.Name = "Eliana";
            person.LastName = "Navia";
            Assert.IsTrue(person.Name.Equals("Eliana"));
            person.LastName = null;
            Assert.IsNull(person.LastName);
            Assert.AreEqual("Eliana", person.Name);
            Assert.AreNotEqual("Ana", person.Name);
            Assert.AreEqual("ELIANA", person.Name, true);
            Assert.ThrowsException<ArgumentNullException>(() => person.GetNickName());
        }

        [TestMethod]
        [TestCategory("Example")]
        public void TestMethodNumber()
        {
            Console.WriteLine("Testing numbers...");
            int i = 45;
            Assert.IsTrue(i > 20 && i <= 45);
        }

        [TestMethod]
        public void TestMethodString()
        {
            Console.WriteLine("Testing strings...");
            Person person = new();
            person.Name = "Eliana";
            person.LastName = "Navia";
            Assert.IsTrue(person.FullName.StartsWith("Eliana"));
            StringAssert.StartsWith(person.FullName, "Eliana");
            StringAssert.EndsWith(person.FullName, "Navia");
            StringAssert.Contains(person.FullName, "ana Na");
            StringAssert.Matches(person.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));           
        }

        [TestMethod]
        public void TestMethodCollection()
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

            CollectionAssert.Contains(personList, person1);
            CollectionAssert.DoesNotContain(personList, person3);

            // The collections should be in the same order.
            CollectionAssert.AreEqual(personList, personList1);

            // Checks the that items are equals without taken account the order of them.
            CollectionAssert.AreEquivalent(personList, personList1);

            CollectionAssert.AllItemsAreUnique(personList3);

            Assert.IsTrue(personList.Any(person => person.Name.Contains("Eli")));
        }

        [TestMethod]
        public void TestMethodObject()
        {
            Person person1 = new();
            person1.Name = "Eliana";
            person1.LastName = "Navia";

            Person person2 = new();
            person2.Name = "Juan";
            person2.LastName = "Perez";
            person2.Age = 25;

            Assert.AreSame(person1, person1);
            Assert.AreNotSame(person1, person2);

            Assert.IsNotInstanceOfType(person1, typeof(DateTime));
        }

        [TestMethod]
        //[Ignore]
        [Ignore("Test Case skipped!")]
        public void TestMethodIgnore()
        {
            int i = 45;
            Assert.IsTrue(i > 20 && i <= 45);
        }
    }
}
