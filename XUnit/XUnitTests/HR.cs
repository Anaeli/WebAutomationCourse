using System;
namespace XUnitProject
{
    public class HR:Worker

    {
         public HR (string name, string lastname) : base(name, lastname)
        { 
            
        }

        public string GetName()
        {
            string name;
            if (Name is null)
            {
                throw new ArgumentNullException();

            }
            else
            {
                name=Name;
            }
            return Name;
        }
    }

     
}