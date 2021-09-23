using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitProject
{
	public class PracticeFirstPart : IClassFixture<Rest>
	{
		Rest rest;
		ITestOutputHelper output;
		public PracticeFirstPart(ITestOutputHelper output, Rest rest)
		{
			this.output = output;
			this.output.WriteLine(rest.RestInt(5, 6).ToString());
			this.rest = new();
		}


		//Boolean
		[Theory(DisplayName ="Contains name")]
		[Trait("Category", "Boolean")]
		[InlineData("Harry", "Grajeda", "Harry")]
		public void HRFullNameContainsName(string name, string lastName, string nameTest)
		{
			HumanResources person1 = new(name, lastName);
			Assert.True(person1.Name.Equals(nameTest));
			output.WriteLine(rest.RestInt(6, 2).ToString());
		}
		//String
		[Theory(DisplayName = "Validate name")]
		[Trait("Category", "String")]
		[InlineData("Harry", "Grajeda")]
		public void validateFullNameHR(string name, string lastName)
		{
			HumanResources person1 = new(name, lastName);
			Assert.Equal(name + " "+ lastName, person1.FullName);
			output.WriteLine(rest.RestInt(6, 1).ToString());
		}

		[Theory(DisplayName = "Validate starts name")]
		[Trait("Category", "String")]
		[InlineData("Harry", "Grajeda", "Ha")]
		public void validateHRnameStartsFirst2Characters(string name, string lastName, string startName)
		{
			HumanResources person1 = new(name, lastName);
			Assert.StartsWith(startName, person1.Name);
			output.WriteLine(rest.RestInt(4, 2).ToString());

		}

		[Theory(DisplayName = "Validate ends name")]
		[Trait("Category", "String")]
		[InlineData("Harry", "Grajeda", "ry")]
		public void validateHRnameEndsFirst2Characters(string name, string lastName, string endName)
		{
			HumanResources person1 = new(name, lastName);
			Assert.EndsWith(endName, person1.Name);
			output.WriteLine(rest.RestInt(10, 2).ToString());

		}

		[Theory(DisplayName = "Validate lastname ignore case")]
		[Trait("Category", "String")]
		[InlineData("HARRY", "grajeda", "GRAJEDA")]
		public void ignoreCaseValidateHRLastName(string name, string lastName, string lastNameCase)
		{
			HumanResources person2 = new(name, lastName);
			Assert.Equal(lastNameCase, person2.LastName, ignoreCase: true);
			output.WriteLine(rest.RestInt(2, 2).ToString());
		}

		[Theory(DisplayName = "Validate full name with regular expression")]
		[Trait("Category", "String")]
		[InlineData("harry", "GRAJEDA")]
		public void regularExpressionValidateFullName(string name, string lastName)
		{
			HumanResources person3 = new(name, lastName);
			Assert.Matches("[a-z]+ [A-Z]+", person3.FullName);
			output.WriteLine(rest.RestInt(6, 2).ToString());
		}

		[Theory(DisplayName = "Validate lastname is empty")]
		[Trait("Category", "String")]
		[InlineData("Harry", "")]
		public void HRLastNameEmpty(string name, string lastName)
		{
			HumanResources person4 = new(name, lastName);
			Assert.Empty(person4.LastName);
			output.WriteLine(rest.RestInt(45, 35).ToString());
		}

		//Numbers
		[Theory(DisplayName = "Validate expect result of rest")]
		[Trait("Category", "Numbers")]
		[InlineData(30, 10, 20)]
		public void validateExpectResultRest(int x, int y, int result)
		{
			Assert.Equal(result, rest.RestInt(x, y));
			output.WriteLine(rest.RestInt(11, 4).ToString());
		}

		[Theory(DisplayName = "Validate change random number method")]
		[Trait("Category", "Numbers")]
		[InlineData(600, 701)]
		public void changeRandomNumberMethod(int x, int y)
		{
			Addition addition = new();
			Assert.True(addition.RandomNumber(x,y) is >= 600 and <= 700, $"Random Number {addition.RandomNumber(x,y)}");
			output.WriteLine(rest.RestInt(53, 32).ToString());
		}
		//Double
		[Theory(DisplayName = "Validate result of the rest of two double")]
		[Trait("Category", "Double")]
		[InlineData(8.813, 5.401, 3.412)]
		public void validateResultRestTwoDouble (double x, double y, double result)
		{
			Assert.Equal(result, rest.RestDouble(x, y));
			output.WriteLine(rest.RestInt(17, 4).ToString());
		}
		//Collection
		[Fact(DisplayName ="Validate two list equals")]
		[Trait("Category", "Collection")]
		public void hrListEqualWorkersList()
		{
			Company company = new();
			HumanResources enginer1 = new("Harry", "Grajeda");
			HumanResources enginer2 = new("Dante", "Guevara");
			HumanResources manager1 = new("Marcelo", "Perez");
			HumanResources manager2 = new("Juan", "Estrada");

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
			output.WriteLine(rest.RestInt(234, 52).ToString());
		}

		[Fact(DisplayName ="Validate if is worker in list")]
		[Trait("Category", "Collection")]
		public void HRmemberExistWorkersList()
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
			output.WriteLine(rest.RestInt(69, 22).ToString());
		}

		[Fact (DisplayName ="Validate if worker is not in list")]
		[Trait("Category", "Collection")]
		public void workersListNotContainHRMember()
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
			output.WriteLine(rest.RestInt(654, 345).ToString());
		}

		[Fact (DisplayName ="Validate if some worker contains specific lastname")]
		[Trait("Category", "Collection")]
		public void workersListContainsHRmemberLastName()
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
			output.WriteLine(rest.RestInt(345, 123).ToString());
		}

		[Fact (DisplayName ="Validate if salary is not null")]
		[Trait("Category", "Collection")]
		public void salariesUpdated()
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
			output.WriteLine(rest.RestInt(234, 123).ToString());
		}

		[Fact (DisplayName ="Validate HR type")]
		[Trait("Category", "Object")]
		public void isHumanResourceType()
        {
			HumanResources enginer1 = new("Harry", "Grajeda");
			Assert.IsType<HumanResources>(enginer1);
			output.WriteLine(rest.RestInt(24, 12).ToString());
		}

		[Fact (DisplayName ="Validate if not manager type")]
		[Trait("Category", "Object")]
		public void isNotManagerType()
		{
			HumanResources enginer1 = new("Harry", "Grajeda");
			Assert.IsNotType<Manager>(enginer1);
			output.WriteLine(rest.RestInt(1634, 999).ToString());
		}

		[Fact (DisplayName ="Validate if is assignable from worker")]
		[Trait("Category", "Object")]
		public void isAssignableFromWorker()
		{
			HumanResources enginer1 = new("Harry", "Grajeda");
			Assert.IsAssignableFrom<Worker>(enginer1);
			output.WriteLine(rest.RestInt(14, 4).ToString());
		}

		[Fact (DisplayName ="Validate if is not the same")]
		[Trait("Category", "Object")]
		public void isNotTheSame()
		{
			HumanResources enginer1 = new("Harry", "Grajeda");
			HumanResources enginer2 = new("Dante", "Guevara");
			Assert.NotSame(enginer1, enginer2);
			output.WriteLine(rest.RestInt(164, 99).ToString());
		}
		
		[Fact (DisplayName ="Validate if is null instance")]
		[Trait("Category", "Object")]
		public void isNullInstance()
        {
			HumanResources enginer1 = new();
			enginer1 = null;
			Assert.Throws<NullReferenceException>(() => enginer1.isNullInstance(enginer1));
			output.WriteLine(rest.RestInt(4, 2).ToString());
		}
	}
	
}
