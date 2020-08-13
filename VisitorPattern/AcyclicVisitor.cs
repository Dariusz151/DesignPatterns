using System;
using System.Collections.Generic;
using System.Text;

namespace AcyclicVisitor
{
    public interface IVisitor<TVisitable>
    {
        void Visit(TVisitable obj);
    }

    public interface IVisitor { }


    // 3 - Double Expression
    // 1 + 2 - Addition Expresion
    public abstract class Expression
    {
        public virtual void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<Expression> typed)
                typed.Visit(this);
        }
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double val)
        {
            Value = val;
        }

        public override void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<DoubleExpression> typed)
                typed.Visit(this);
        }

    }

    public class AdditionExpression : Expression
    {
        public Expression Left, Right;
        public AdditionExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public override void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<AdditionExpression> typed)
                typed.Visit(this);
        }
    }

    public class ExpressionPrinter : IVisitor, IVisitor<Expression>,
        IVisitor<DoubleExpression>, IVisitor<AdditionExpression>
    {

        private StringBuilder sb = new StringBuilder();
        public void Visit(Expression obj)
        {
            
        }

        public void Visit(DoubleExpression obj)
        {
            sb.Append(obj.Value);
        }

        public void Visit(AdditionExpression obj)
        {
            sb.Append("(");
            obj.Left.Accept(this);
            sb.Append("+");
            obj.Right.Accept(this);
            sb.Append(")");
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }




    public class AcyclicVisitor
    {

    }
}
