using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePatterns.Library.CompositePattern
{
    public class EmployeeLeaf : IComposite
    {
        public void Run()
        {
            Console.WriteLine("this is the employee leaf");
        }
    }
}
