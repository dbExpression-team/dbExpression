using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class IsNullFunctionExpression : DataTypeFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        ISupportedForExpression<SelectExpression>,
        IEquatable<IsNullFunctionExpression>
    {
        #region interface
        public (Type, object) Value { get; }
        #endregion

        #region constructors
        protected IsNullFunctionExpression()
        {
        }

        protected IsNullFunctionExpression((Type, object) expression, (Type, object) value)
            : base(expression)
        {
            Value = value;
        }
        #endregion

        #region to string
        public override string ToString() => $"ISNULL({Expression.Item2}, {Value.Item2})";
        #endregion

        #region equals
        public bool Equals(IsNullFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (obj.Value != this.Value) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is IsNullFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
