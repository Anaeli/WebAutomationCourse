using System;

namespace XUnitProject
{
	public class HumanResources : Worker
	{
	public HumanResources(string name, string lastname):base(name, lastname)
		{

		}

		public HumanResources()
		{

		}
		public HumanResources isNullInstance(HumanResources humanResources)
		{
			if (humanResources is null)
			{
				throw new ArgumentNullException();
			}
			else
			{
				return humanResources;
			}
		}
	}

	
}

