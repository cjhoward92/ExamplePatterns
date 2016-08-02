using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePatterns.Library.CommandPattern
{
    public class SaveUserCommand : ICommand
    {
        public DecoratorPattern.User User { get; set; }
    }

    public class SaveUserCommandHandler : ICommandHandler<SaveUserCommand>
    {
        // Abstracts the command logic
        public void Handle(SaveUserCommand command)
        {
            var user = command.User;
            // Save user
            Console.WriteLine($"User {command.User.Name} saved!");
        }
    }
}
