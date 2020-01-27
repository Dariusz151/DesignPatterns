using System;

namespace ChainOfResponsibility // BEHAVIORAL PATTERN
{
    public class Program
    {
        static void Main(string[] args)
        {
            Approver Dariusz = new HeadChef();
            Approver Jacek = new GeneralManager();
            Approver Michal = new PurchasingManager();

            Dariusz.SetSupervisor(Jacek);
            Jacek.SetSupervisor(Michal);

            PurchaseOrder order1 = new PurchaseOrder(1, 20, 30, "Product");
            Dariusz.ProcessRequest(order1);

            PurchaseOrder order2 = new PurchaseOrder(1, 20, 1300, "Product");
            Dariusz.ProcessRequest(order2);

            PurchaseOrder order3 = new PurchaseOrder(1, 20, 3500, "Product");
            Dariusz.ProcessRequest(order3);

            PurchaseOrder order4 = new PurchaseOrder(1, 20, 130000, "Product");
            Dariusz.ProcessRequest(order4);


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
