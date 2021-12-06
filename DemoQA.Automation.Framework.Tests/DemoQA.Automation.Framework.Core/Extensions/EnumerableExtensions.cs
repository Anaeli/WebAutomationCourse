namespace DemoQA.Automation.Core.Extensions
{
	using System.Collections.Generic;

	internal static class EnumerableExtensions
	{
		internal static bool CompareLists(this IEnumerable<string> expectedValues, IEnumerable<string> actualValues)
		{
			AutomationTrace.WriteLine("Comparing lists");
			if (expectedValues == null && actualValues == null)
			{
				AutomationTrace.WriteLine("Both lists are null.  Returning true");
				return true;
			}
			if (expectedValues == null || actualValues == null)
			{
				AutomationTrace.WriteLine("One of the lists is null.  Returning false");
				return false;
			}
			List<string> expectedAsList = new List<string>(expectedValues);
			List<string> actualAsList = new List<string>(actualValues);
			if (expectedAsList.Count != actualAsList.Count)
			{
				AutomationTrace.WriteLine($"expectedValues.Count({expectedAsList.Count}) != actualValues.Count({actualAsList.Count}).  Returning false");
				return false;
			}
			try
			{
				AutomationTrace.Indent();
				for (int i = 0; i < expectedAsList.Count; i++)
				{
					if (expectedAsList[i] != actualAsList[i])
					{
						AutomationTrace.WriteLine($"{expectedAsList[i]} != {actualAsList[i]}.  Returning false.");
						return false;
					}
					AutomationTrace.WriteLine($"{expectedAsList[i]} == {actualAsList[i]}");
				}
			}
			finally
			{
				AutomationTrace.Unindent();
			}
			AutomationTrace.WriteLine("expectedValues == actualValues.  Returning True");
			return true;
		}
	}
}
