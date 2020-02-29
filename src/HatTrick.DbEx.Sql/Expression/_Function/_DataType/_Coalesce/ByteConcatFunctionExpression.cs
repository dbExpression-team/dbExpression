using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteConcatFunctionExpression : 
        ConcatFunctionExpression<byte>,
        IEquatable<ByteConcatFunctionExpression>
    {
        #region constructors
        protected ByteConcatFunctionExpression()
        {
        }

        protected ByteConcatFunctionExpression(params ExpressionContainer[] expressions) : base(expressions)
        {
        }
        #endregion

        #region as
        public new ByteConcatFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteConcatFunctionExpression obj)
            => obj is ByteConcatFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteConcatFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
