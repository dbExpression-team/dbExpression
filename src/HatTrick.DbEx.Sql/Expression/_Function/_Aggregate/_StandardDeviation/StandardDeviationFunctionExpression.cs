using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class StandardDeviationFunctionExpression : AggregateFunctionExpression,
        IDbNumericFunctionExpression,
        IAssemblyPart,
        IDbExpressionIsDistinctProvider,
        ISupportedForFunctionExpression<CastFunctionExpression>,
        IEquatable<StandardDeviationFunctionExpression>,
        ISupportedForSelectExpression
    {
        #region internals
        protected bool IsDistinct { get; private set; }
        #endregion

        #region interface
        bool IDbExpressionIsDistinctProvider.IsDistinct => IsDistinct;
        #endregion

        #region constructors
        protected StandardDeviationFunctionExpression()
        {
        }

        public StandardDeviationFunctionExpression((Type,object) expression, bool isDistinct)
            : base(expression)
        {
            IsDistinct = isDistinct;
        }
        #endregion

        #region to string
        public override string ToString() => $"STDEV({(IsDistinct ? "DISTINCT " : string.Empty)}{Expression})";
        #endregion

        #region equals
        public bool Equals(StandardDeviationFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;
            if (this.IsDistinct != obj.IsDistinct) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is StandardDeviationFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
