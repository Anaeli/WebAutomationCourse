using Persons;
using System;
using Xunit.Abstractions;

namespace XUnitProject
{
    public class PersonFixture :IDisposable
    {
        public Person Person { get; private set; }

        public PersonFixture()
        {
            Person = new Person();
        }


        public void Dispose()
        {
            //cleanup
        }
    }
}
