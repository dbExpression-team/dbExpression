using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class IsNullFunctionExpression : DataTypeFunctionExpression,
        IEquatable<IsNullFunctionExpression>
    {
        #region interface
        public IExpressionElement Value { get; }
        #endregion

        #region constructors
        protected IsNullFunctionExpression(IExpressionElement expression, Type declaredType, IExpressionElement value) : base(expression, declaredType)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
        #endregion

        #region to string
        public override string ToString() => $"ISNULL({Expression}, {Value})";
        #endregion

        #region equals
        public bool Equals(IsNullFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (this.Value is null && obj.Value is object) return false;
            if (this.Value is object && obj.Value is null) return false;
            if (!this.Value.Equals(obj.Value)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is IsNullFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (Value is object ? Value.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
