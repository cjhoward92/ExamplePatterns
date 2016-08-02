using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using ExamplePatterns.Library;
using ExamplePatterns.Library.CommandPattern;
using ExamplePatterns.Library.CompositePattern;
using ExamplePatterns.Library.DecoratorPattern;
using ExamplePatterns.Library.QueryPattern;

namespace ExamplePatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrap();
            Run(container);
        }

        static Container Bootstrap()
        {
            var container = new Container();

            var assemblies = new System.Reflection.Assembly[] { typeof(Program).Assembly, typeof(IQuery<>).Assembly };

            // Get all of the open generics
            container.Register(typeof(IQueryHandler<,>), assemblies);
            container.Register(typeof(ICommandHandler<>), assemblies);

            // Register the USer Service
            container.Register<IUserService, UserService>();
            // Register the user service decorator
            container.RegisterDecorator<IUserService, UserServiceDecorator>();
            container.Register<ILogger, Logger>();

            // Get all of the composite types and register them
            var compositeAssembly = typeof(IComposite).Assembly;
            var composites = from type in compositeAssembly.GetExportedTypes() 
                             where typeof(IComposite).IsAssignableFrom(type) && type != typeof(Composite)
                                    && !type.IsInterface
                             select type;

            container.RegisterCollection<IComposite>(composites);
            container.Register(typeof(IComposite), typeof(Composite), Lifestyle.Singleton);

            container.Register<MainProcess>();

            // Call in debug only!
            container.Verify();
            return container;
        }
        static void Run(Container container)
        {
            var process = container.GetInstance<MainProcess>();
            process.Run();
        }
    }
}
