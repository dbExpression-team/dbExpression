using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression : 
        IEquatable<ArithmeticExpression>
    {
        #region interface
        public ExpressionContainer Expression { get; private set; }
        public ExpressionContainer LeftPart => ((ExpressionContainerPair)Expression.Object).LeftPart;
        public ExpressionContainer RightPart => ((ExpressionContainerPair)Expression.Object).RightPart;
        public ArithmeticExpressionOperator ExpressionOperator { get; private set; }
        #endregion

        #region constructors
        public ArithmeticExpression(ExpressionContainer leftArg, ExpressionContainer rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = new ExpressionContainer(new ExpressionContainerPair(leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required."), rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.")));
            ExpressionOperator = arithmeticOperator;
        }
        #endregion

        #region to string
        public override string ToString() => $"({LeftPart.Object} {ExpressionOperator} {RightPart.Object})";
        #endregion

        #region equals
        public bool Equals(ArithmeticExpression obj)
        {
            if (obj is null) return false;

            if (Expression is null && obj.Expression is object) return false;
            if (Expression is object && obj.Expression is null) return false;
            if (!Expression.Equals(obj.Expression)) return false;

            if (!ExpressionOperator.Equals(obj.ExpressionOperator)) return false;

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
                hash = (hash * multiplier) ^ (Expression is object ? Expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ ExpressionOperator.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
