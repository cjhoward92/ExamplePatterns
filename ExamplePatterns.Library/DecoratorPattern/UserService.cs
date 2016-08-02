using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePatterns.Library.DecoratorPattern
{
    public class UserService : IUserService
    {
        // This is the original functionality
        public void AddUserToActiveDirectory(User user)
        {
            // Do something
            Console.WriteLine($"User email {user.Email} added to active directory!");
        }
    }
}
