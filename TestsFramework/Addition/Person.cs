using System;

namespace Persons
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public int Age { get; set; }

        public string GetNickName()
        {
            string nickName;
            if (NickName is null)
            {
                
                throw new ArgumentNullException();
            }
            else
            {
                nickName = NickName;
            }
            return nickName;
        }

        public string FullName => $"{Name} {LastName}";

        public Guid ID { get; } = Guid.NewGuid();
    }
}
