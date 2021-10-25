using System;
using System.Threading;

namespace DemoQA.Automation.Core.Extensions
{
    public static class Wait
    {
        private static bool TryIgnoreStaleReferences(Func<bool> criteria)
        {
            try
            {
                return criteria();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("stale"))
                {
                    throw;
                }
                return false;
            }
        }

        public static void For(int milleseconds)
        {
            Thread.Sleep(milleseconds);
        }

        public static bool For(Func<bool> criteria)
        {
            return For(criteria, 50, 40);
        }

        public static bool For(Func<bool> criteria, int sleep, int iterations)
        {
            AutomationTrace.WriteLine("Waiting for {0} iterations with a {1} milliseconds sleep between each iteration", iterations, sleep);
            try
            {
                AutomationTrace.Indent();
                if (TryIgnoreStaleReferences(criteria))
                {
                    AutomationTrace.WriteLine("Returning true on first try");
                    return true;
                }
                for (int i = 0; i < iterations; i++)
                {
                    Thread.Sleep(sleep);
                    if (TryIgnoreStaleReferences(criteria))
                    {
                        AutomationTrace.WriteLine("Iteration {0} returned true. Exiting loop", i + 1);
                        return true;
                    }
                    AutomationTrace.WriteLine("Iteration {0} returned false.", i + 1, sleep);
                }
                AutomationTrace.WriteLine("Done waiting.  Returning false.");
                return false;
            }
            finally
            {
                AutomationTrace.Unindent();
            }
        }

        public static bool WaitFor<t>(this t arg, Func<t, bool> criteria, int sleep, int iterations)
        {
            return For(() => criteria(arg), sleep, iterations);
        }

        public static bool WaitFor<t>(this t arg, Func<t, bool> criteria, int sleep)
        {
            return For(() => criteria(arg), sleep / 10, 10);
        }

        public static bool WaitFor<t>(this t arg, Func<t, bool> criteria)
        {
            return For(() => criteria(arg));
        }
    }
}
