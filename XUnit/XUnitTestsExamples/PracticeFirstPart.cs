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
		public void HRFullNameContainsName()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.True(person1.Name.Equals("Harry"));
		}
		//String
		[Fact]
		public void validateFullNameHR()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.Equal("Harry Grajeda", person1.FullName);
		}

		[Fact]
		public void validateHRnameStartsFirst2Characters()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.StartsWith("Ha", person1.Name);
			
		}

		[Fact]
		public void validateHRnameEndsFirst2Characters()
		{
			HumanResources person1 = new("Harry", "Grajeda");
			Assert.EndsWith("ry", person1.Name);

		}

		[Fact]
		public void ignoreCaseValidateHRLastName()
		{
			HumanResources person2 = new("HARRY", "grajeda");
			Assert.Equal("GRAJEDA", person2.LastName, ignoreCase: true);
		}

		[Fact]
		public void regularExpressionValidateFullName()
		{
			HumanResources person3 = new("harry", "GRAJEDA");
			Assert.Matches("[a-z]+ [A-Z]+", person3.FullName);
		}

		[Fact]
		public void HRLastNameEmpty()
		{
			HumanResources person4 = new("Harry", "");
			Assert.Empty(person4.LastName);
		}

		//Numbers
		[Fact]
		public void validateExpectResultRest()
		{
			Addition addition = new();
			Rest rest = new();
			Assert.Equal(20, rest.RestInt(30, 10));
		}

		[Fact]
		public void changeRandomNumberMethod()
		{
			Addition addition = new();
			Rest rest = new();
			Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
		}
		//Double
		[Fact]
		public void validateResultRestTwoDouble ()
		{
			Rest rest = new();
			Assert.Equal(3.412, rest.RestDouble(8.813, 5.401));
		}
		//Collection
		[Fact]
		public void hrListEqualWorkersList()
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
		}

		[Fact]
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
		}

		[Fact]
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
		}

		[Fact]
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
		}
	}
	
}
