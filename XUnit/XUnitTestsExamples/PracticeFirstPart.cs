using System.Collections.Generic;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitProject
{
	public class PracticeFirstPart
	{

		//Boolean
		[Fact]
		public void test1()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.True(person1.Name.Equals("Harry"));
		}
		//String
		[Fact]
		public void test2()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.Equal("Harry Grajeda", person1.FullName);
		}

		[Fact]
		public void test3()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.StartsWith("Ha", person1.Name);
			
		}

		[Fact]
		public void test4()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.EndsWith("ry", person1.Name);

		}

		[Fact]
		public void test5()
		{
			HumanResources person2 = new("HARRY", "grajeda");
			Assert.Equal("GRAJEDA", person2.LastName, ignoreCase: true);
		}

		[Fact]
		public void test6()
		{
			HumanResources person3 = new("harry", "GRAJEDA");
			Assert.Matches("[a-z]+ [A-Z]+", person3.FullName);
		}

		[Fact]
		public void test7()
		{
			HumanResources person4 = new("Harry", "");
			Assert.Empty(person4.LastName);
		}

		//Numbers
		[Fact]
		public void test8()
		{
			Addition addition = new();
			Rest rest = new();
			Assert.Equal(20, rest.RestInt(30, 10));
			Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
		}

		[Fact]
		public void test9()
		{
			Addition addition = new();
			Rest rest = new();
			Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
		}
		//Double
		[Fact]
		public void test10()
		{
			Rest rest = new();
			Assert.Equal(3.4121, rest.RestDouble(8.8135, 5.4014));
		}
		//Collection
		[Fact]
		public void test11()
		{
			Company company = new();
			HumanResources enginer1 = new("Harry", "Grajeda");
			HumanResources enginer2 = new("Dante", "Guevara");
			HumanResources manager1 = new("Marcelo", "Perez");
			HumanResources manager2 = new("Juan", "Estrada");
			HumanResources enginer3 = new("Eduardo", "Galarza");

			List<HumanResources> hrList = new()
			{
				manager1,
				manager2,
				enginer1,
				enginer2
			};

			company.Workers = new List<Worker>
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
			};
			Assert.Equal(hrList, company.Workers);
		}

		[Fact]
		public void test12()
		{
		
			Company company = new();
			HumanResources enginer1 = new("Harry", "Grajeda");
			HumanResources enginer2 = new("Dante", "Guevara");
			HumanResources manager1 = new("Marcelo", "Perez");
			HumanResources manager2 = new("Juan", "Estrada");
			HumanResources enginer3 = new("Eduardo", "Galarza");

			List<HumanResources> hrList = new()
			{
				manager1,
				manager2,
				enginer1,
				enginer2
			};

			company.Workers = new List<Worker>
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
			};

			Assert.Contains(enginer2, company.Workers);
		}

		[Fact]
		public void test13()
		{
			
			Company company = new();
			HumanResources enginer1 = new("Harry", "Grajeda");
			HumanResources enginer2 = new("Dante", "Guevara");
			HumanResources manager1 = new("Marcelo", "Perez");
			HumanResources manager2 = new("Juan", "Estrada");
			HumanResources enginer3 = new("Eduardo", "Galarza");

			List<HumanResources> hrList = new()
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
				enginer3
			};

			company.Workers = new List<Worker>
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
			};

			Assert.DoesNotContain(enginer3, company.Workers);
		}

		[Fact]
		public void test14()
		{
			
			Company company = new();
			HumanResources enginer1 = new("Harry", "Grajeda");
			HumanResources enginer2 = new("Dante", "Guevara");
			HumanResources manager1 = new("Marcelo", "Perez");
			HumanResources manager2 = new("Juan", "Estrada");
			HumanResources enginer3 = new("Eduardo", "Galarza");

			List<HumanResources> hrList = new()
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
				enginer3
			};

			company.Workers = new List<Worker>
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
			};

			Assert.Contains(company.Workers, worker => worker.LastName.Contains("Grajeda"));
		}

		[Fact]
		public void test15()
		{
			
			Company company = new();
			HumanResources enginer1 = new("Harry", "Grajeda");
			HumanResources enginer2 = new("Dante", "Guevara");
			HumanResources manager1 = new("Marcelo", "Perez");
			HumanResources manager2 = new("Juan", "Estrada");
			HumanResources enginer3 = new("Eduardo", "Galarza");

			List<HumanResources> hrList = new()
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
				enginer3
			};

			company.Workers = new List<Worker>
			{
				manager1,
				manager2,
				enginer1,
				enginer2,
			};
			Assert.All(company.Workers, worker => Assert.True(string.IsNullOrWhiteSpace(worker.Salary)));
		}
	}
	
}
