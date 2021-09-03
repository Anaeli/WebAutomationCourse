using System;
using System.Collections.Generic;
using XUnitProject;

namespace XUnitTests
{
    public class Project
    {
        public Manager Manager { get; set; }
        public List<Enginer> Enginers { get => enginers; set => enginers = value; }

        private List<Enginer> enginers = new();
        public string State { get; set; }
        
        public string Name { get; set; }

        public Guid ID { get; } = Guid.NewGuid();

        public void StartProject()
        {
            System.Threading.Thread.Sleep(2000);
            State = "Started";
        }

        public void EndProject()
        {
            Enginers.Clear();
            Manager = null;
            State = "Finished";
        }
    }
}
