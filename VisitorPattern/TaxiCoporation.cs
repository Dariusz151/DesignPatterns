using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiCorporation
{
    public abstract class Taxi
    {
        public abstract void VisitCustomer(TaxiCustomer customer);
        public abstract void VisitCustomer(PoorCustomer poorCustomer);
        public abstract void VisitCustomer(RichCustomer richCustomer);
    }

    public class Taxi1 : Taxi
    {
        public override void VisitCustomer(TaxiCustomer customer)
        {
            Console.WriteLine($"Customer: {customer.Name} has been visited by {GetType().Name}");
        }

        public override void VisitCustomer(PoorCustomer poorCustomer)
        {
            Console.WriteLine($"Customer: {poorCustomer.Name} can only pay 20zl for {GetType().Name}");
        }

        public override void VisitCustomer(RichCustomer richCustomer)
        {
            Console.WriteLine($"Customer: {richCustomer.Name} can pay 100zl for {GetType().Name}");
        }
    }

    public class Taxi2 : Taxi
    {
        public override void VisitCustomer(TaxiCustomer customer)
        {
            Console.WriteLine($"Customer: {customer.Name} has been visited by {GetType().Name}");
        }

        public override void VisitCustomer(PoorCustomer poorCustomer)
        {
            Console.WriteLine($"Customer: {poorCustomer.Name} cannot go {GetType().Name}. He has no money.");
        }

        public override void VisitCustomer(RichCustomer richCustomer)
        {
            Console.WriteLine($"Customer: {richCustomer.Name} can pay 300zl for {GetType().Name}");
        }
    }

    public abstract class Customer
    {
        public string Name;
        public abstract void Accept(Taxi taxi);
    }

    public class RichCustomer : Customer
    {
        public RichCustomer(string Name)
        {
            this.Name = Name;
        }
        public override void Accept(Taxi taxi)
        {
            taxi.VisitCustomer(this);
        }
    }

    public class PoorCustomer : Customer
    {
        public PoorCustomer(string Name)
        {
            this.Name = Name;
        }
        public override void Accept(Taxi taxi)
        {
            taxi.VisitCustomer(this);
        }
    }

    public class TaxiCustomer : Customer
    {
        public TaxiCustomer(string Name)
        {
            this.Name = Name;
        }
        public override void Accept(Taxi taxi)
        {
            taxi.VisitCustomer(this);
        }
    }

    public class CustomerStructure
    {
        private List<Customer> _customers = new List<Customer>();

        public void Attach(Customer customer)
        {
            _customers.Add(customer);
        }

        public void Detach(Customer customer)
        {
            _customers.Remove(customer);
        }

        public void Accept(Taxi taxi)
        {
            foreach (Customer cust in _customers)
            {
                cust.Accept(taxi);
            }
        }

    }
}
