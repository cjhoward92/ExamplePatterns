using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamplePatterns.Library.CommandPattern;
using ExamplePatterns.Library.CompositePattern;
using ExamplePatterns.Library.DecoratorPattern;
using ExamplePatterns.Library.QueryPattern;

namespace ExamplePatterns
{
    public class MainProcess
    {
        private readonly IUserService userService;
        private readonly IComposite composite;
        private readonly ICommandHandler<SaveUserCommand> saveUserCommand;
        private readonly IQueryHandler<NumberOfUsersQuery, int> numberOfUsersQuery;

        public MainProcess(IUserService userService,
            IComposite composite,
            ICommandHandler<SaveUserCommand> saveUserCommand,
            IQueryHandler<NumberOfUsersQuery, int> numberOfUsersQuery)
        {
            this.userService = userService;
            this.composite = composite;
            this.saveUserCommand = saveUserCommand;
            this.numberOfUsersQuery = numberOfUsersQuery;
        }

        public void Run()
        {
            Console.WriteLine("Decorator test!");
            userService.AddUserToActiveDirectory(new User() { Email = "carson.howard@kochfoods.com" });
            Console.WriteLine();

            Console.WriteLine("Composite test!");
            composite.Run();
            Console.WriteLine();

            Console.WriteLine("Command test!");
            saveUserCommand.Handle(new SaveUserCommand()
            {
                User = new User()
                {
                    Name = "Carson Howard"
                }
            });
            Console.WriteLine();

            Console.WriteLine("Query test!");
            var numberOfUsers = numberOfUsersQuery.Handle(new NumberOfUsersQuery());
            Console.WriteLine($"Number of users: {numberOfUsers}");
            Console.WriteLine();

            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }
    }
}
