using System;
using System.Collections.Generic;
using System.Text;
using TaxiCorporation;

namespace VisitorPattern
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionExpression ae);
    }

    public class AdditionExpression : Expression
    {
        public Expression left, right;
        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }
        public override void Accept(IExpressionVisitor visitor)
        {
            //double dispatch
            visitor.Visit(this);
        }
    }

    public class DoubleExpression : Expression
    {
        public double value;
        public DoubleExpression(double value)
        {
            this.value = value;
        }
        public override void Accept(IExpressionVisitor visitor)
        {
            //double dispatch
            visitor.Visit(this);
        }
    }

    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class ExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb = new StringBuilder();

        public void Visit(DoubleExpression de)
        {
            sb.Append(de.value);
        }

        public void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.left.Accept(this);
            sb.Append("+");
            ae.right.Accept(this);
            sb.Append(")");
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class ExpressionCalculator : IExpressionVisitor
    {
        public double Result;

        public void Visit(DoubleExpression de)
        {
            Result = de.value;
        }

        public void Visit(AdditionExpression ae)
        {
            ae.left.Accept(this);
            var a = Result;
            ae.right.Accept(this);
            var b = Result;
            Result = a + b;
        }
    }

    public class Visitor
    {
        public static void Main(string[] args)
        {
            var e = new AdditionExpression(
               new DoubleExpression(1),
               new AdditionExpression(
                   new DoubleExpression(2),
                   new DoubleExpression(3)));
            
            var ep = new ExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep);

            var calc = new ExpressionCalculator();
            calc.Visit(e);
            Console.WriteLine($"{ep} = {calc.Result}");

            Console.WriteLine("Taxi Visitor!");


            CustomerStructure o = new CustomerStructure();

            o.Attach(new TaxiCustomer("Andrzej"));
            o.Attach(new TaxiCustomer("Seba"));
            o.Attach(new TaxiCustomer("Pudzian"));
            o.Attach(new RichCustomer("Musk"));
            o.Attach(new PoorCustomer("Żul"));

            Taxi t1 = new Taxi1();
            Taxi t2 = new Taxi2();

            o.Accept(t1);

            Console.WriteLine();

            o.Accept(t2);

            Console.ReadLine();
        }
    }
}
