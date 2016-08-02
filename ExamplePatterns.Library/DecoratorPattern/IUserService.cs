using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePatterns.Library.DecoratorPattern
{
    // This interface is used as a placeholder for something that could have potential functionality
    // We need it to demonstrate the decorator pattern effectively
    public interface IUserService
    {
        void AddUserToActiveDirectory(User user);
    }
}
