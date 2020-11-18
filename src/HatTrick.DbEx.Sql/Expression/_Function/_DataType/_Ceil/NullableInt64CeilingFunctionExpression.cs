using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64CeilingFunctionExpression :
        NullableCeilFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64CeilingFunctionExpression>
    {
        #region constructors
        public NullableInt64CeilingFunctionExpression(NullInt64Element expression) 
            : base(expression)
        {

        }

        protected NullableInt64CeilingFunctionExpression(IExpressionElement expression, string alias) 
            : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64CeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64CeilingFunctionExpression obj)
            => obj is NullableInt64CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
