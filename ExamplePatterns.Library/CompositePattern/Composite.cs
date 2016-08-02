using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePatterns.Library.CompositePattern
{
    public class Composite : IComposite
    {
        private readonly IEnumerable<IComposite> children;

        // This is the parent composite that encapsulates all of the children's functionality.
        // We cannot gurantee the order of the child operations
        public Composite(IEnumerable<IComposite> children)
        {
            this.children = children;
        }

        public void Run()
        {
            foreach (var child in children)
                child.Run();
        }
    }
}
