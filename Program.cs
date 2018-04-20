using System;
using System.Linq;
using System.Reflection;

namespace DependencyInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new DependencyContainer();
            container.Register<IBar,Bar>();
            container.Register<IFoo,Foo>();

            var bar = container.Resolve<IBar>();
            Console.WriteLine($"normal bar: {bar.Text}");

            var foo = container.Resolve<IFoo>();
            Console.WriteLine($"bar from foo: {foo.GetBar().Text}");
        }
    }
}
