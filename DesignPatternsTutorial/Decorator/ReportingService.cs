using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTutorial.Decorator
{
    public class ReportingService : IReportingService
    {
        public void Report()
        {
            Console.WriteLine("This is oyur report.");
        }
    }

    public class ReportingServiceWithLogging : IReportingService
    {
        private IReportingService decorated;

        public ReportingServiceWithLogging(IReportingService decorated)
        {
            this.decorated = decorated; 
        }

        public void Report()
        {
            Console.WriteLine("Commencing log..");
            decorated.Report();
            Console.WriteLine("Ending log.");
        }
    }

    public interface IReportingService
    {
        void Report();
    }
}
