using System;
using System.Text;

namespace WithoutVisitorPattern
{
    public abstract class Expression
    {
        //public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        public double value;
        public DoubleExpression(double value)
        {
            this.value = value;
        }

        //public override void Print(StringBuilder sb)
        //{
        //    sb.Append(value);
        //}
    }

    public class AdditionExpression : Expression
    {
        public Expression left, right;
        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        //public override void Print(StringBuilder sb)
        //{
        //    sb.Append("(");
        //    left.Print(sb);
        //    sb.Append("+");
        //    right.Print(sb);
        //    sb.Append(")");
        //}
    }

    public static class ExpressinPrinter
    {
        public static void Print(Expression e, StringBuilder sb)
        {
            if (e is DoubleExpression de)
            {
                sb.Append(de.value);
            }
            else if (e is AdditionExpression ae)
            {
                sb.Append("(");
                Print(ae.left, sb);
                sb.Append("+");
                Print(ae.right, sb);
                sb.Append(")");
            }
        }
    }

    public class WithoutVisitor
    {
        //public static void Main(string[] args)
        //{
        //    var e = new AdditionExpression(
        //        new DoubleExpression(1),
        //        new AdditionExpression(
        //            new DoubleExpression(2),
        //            new DoubleExpression(3)));

        //    var sb = new StringBuilder();
        //    //e.Print(sb);
        //    ExpressinPrinter.Print(e, sb);
        //    Console.WriteLine(sb); ;

        //    Console.WriteLine("Hello World!");
        //    Console.ReadLine();
        //}
    }
}
