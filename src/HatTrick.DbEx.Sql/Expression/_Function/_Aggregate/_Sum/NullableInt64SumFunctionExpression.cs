using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64SumFunctionExpression :
        NullableSumFunctionExpression<long,long?>,
        NullInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64SumFunctionExpression>
    {
        #region constructors
        public NullableInt64SumFunctionExpression(NullInt64Element expression, bool isDistinct) : base(expression, typeof(long?), isDistinct)
        {

        }

        protected NullableInt64SumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(long?), isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullInt64Element As(string alias)
            => new NullableInt64SumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64SumFunctionExpression obj)
            => obj is NullableInt64SumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64SumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
