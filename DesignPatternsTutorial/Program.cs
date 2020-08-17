using System;
using Autofac;
using DesignPatternsTutorial.Decorator;


namespace DesignPatternsTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            //Console.WriteLine("Hello World!");
            //MyStringBuilder s = "hello ";
            //s += "world";
            //Console.WriteLine(s);

            var b = new ContainerBuilder();
            b.RegisterType<ReportingService>().Named<IReportingService>("reporting");
            b.RegisterDecorator<IReportingService>(
                (context, service) => new ReportingServiceWithLogging(service), "reporting"
            );

            using (var c = b.Build())
            {
                var r = c.Resolve<IReportingService>();
                r.Report();
            }

            Console.ReadLine();
        }
    }
}
