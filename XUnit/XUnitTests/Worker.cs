using System;

namespace XUnitProject
{
    public class Worker
    {
        public Worker(string name, string lastname)
        {
            this.Name = name;
            this.LastName = lastname;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";
        public string Salary { get; set; }
        public int EntryHour { get; set; }
        public int ExitHour { get; set; }
        public int WorkHour { get; set; }

        public event EventHandler<EventArgs> WorkHours;

        public Guid ID { get; } = Guid.NewGuid();

        public void WorkedHours()
        {
            var workHours = CalculateWorkHours(EntryHour, ExitHour);
            WorkHour += workHours;
            CalculateHours(EventArgs.Empty);
        }

        protected virtual void CalculateHours(EventArgs e)
        {
            WorkHours?.Invoke(this, e);
        }

        private int CalculateWorkHours(int entryHour, int exitHour)
        {
            return exitHour - entryHour;
        }

        public string GetSalary()
        {
            string salary;
            if (Salary is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                salary = Salary;
            }
            return salary;
        }
    }
}
