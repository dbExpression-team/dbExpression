using HatTrick.DbEx.Sql.Attribute;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression : 
        IExpression,
        IEquatable<ArithmeticExpression>
    {
        #region interface
        public ExpressionMediator LeftArg { get; private set; }
        public ExpressionMediator RightArg { get; private set; }
        public ArithmeticExpressionOperator ExpressionOperator { get; private set; }
        #endregion

        #region constructors
        public ArithmeticExpression(ExpressionMediator leftArg, ExpressionMediator rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ExpressionOperator = arithmeticOperator;
        }
        #endregion

        #region to string
        public override string ToString() => $"({LeftArg} {ExpressionOperator.GetArithmeticOperator()} {RightArg})";
        #endregion

        #region equals
        public bool Equals(ArithmeticExpression obj)
        {
            if (obj is null) return false;

            if (!ExpressionOperator.Equals(obj.ExpressionOperator)) return false;

            if (LeftArg is null && obj.LeftArg is object) return false;
            if (LeftArg is object && obj.LeftArg is null) return false;
            if (!LeftArg.Equals(obj.LeftArg)) return false;

            if (RightArg is null && obj.RightArg is object) return false;
            if (RightArg is object && obj.RightArg is null) return false;
            if (!RightArg.Equals(obj.RightArg)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is ArithmeticExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (LeftArg is object ? LeftArg.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (RightArg is object ? RightArg.GetHashCode() : 0);
                hash = (hash * multiplier) ^ ExpressionOperator.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
