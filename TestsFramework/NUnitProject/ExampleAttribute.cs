using NUnit.Framework;
using System;

namespace NUnitProject
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    class ExampleAttribute : CategoryAttribute
    {
    }
}
