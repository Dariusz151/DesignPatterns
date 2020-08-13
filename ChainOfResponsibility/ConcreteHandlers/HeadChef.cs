using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// A ConcreteHandler class
    /// </summary>
    public class HeadChef : Approver
    {
        public override void ProcessRequest(PurchaseOrder purchase)
        {
            if (purchase.Price < 1000)
            {
                Console.WriteLine("{0} approved purchase request #{1}",
                    this.GetType().Name, purchase.RequestNumber);
            }
            else if (Supervisor != null)
            {
                Supervisor.ProcessRequest(purchase);
            }
        }
    }
}
