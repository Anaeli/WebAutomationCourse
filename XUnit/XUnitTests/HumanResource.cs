using XUnitProject;

namespace XUnitTests
{
    public class HumanResource : Worker
    {
        public HumanResource(string name, string lastname) : base(name, lastname)
        {
            this.Name = name;
        }
    }
}
