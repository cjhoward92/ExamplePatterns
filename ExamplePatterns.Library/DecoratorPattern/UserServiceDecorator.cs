using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePatterns.Library.DecoratorPattern
{
    public class UserServiceDecorator : IUserService
    {
        private readonly ILogger logger;
        private readonly IUserService mainService;

        public UserServiceDecorator(IUserService mainService, ILogger logger)
        {
            this.logger = logger;
            this.mainService = mainService;
        }

        // This decorator adds functionality to an existing implementation without altering the implementation itself.
        // This is an example of the Open-Closed Principle
        public void AddUserToActiveDirectory(User user)
        {
            // Call the original functionality and "decorate" it with some extra logging afterwards
            mainService.AddUserToActiveDirectory(user);
            // Call the logging functionality
            logger.Log("logging some data");
        }
    }
}
