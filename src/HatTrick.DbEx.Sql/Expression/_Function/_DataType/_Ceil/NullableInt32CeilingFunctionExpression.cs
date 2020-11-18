using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CeilingFunctionExpression :
        NullableCeilFunctionExpression<int,int?>,
        NullInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32CeilingFunctionExpression>
    {
        #region constructors
        public NullableInt32CeilingFunctionExpression(NullInt32Element expression) 
            : base(expression)
        {

        }

        protected NullableInt32CeilingFunctionExpression(IExpressionElement expression, string alias) 
            : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullInt32Element As(string alias)
            => new NullableInt32CeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32CeilingFunctionExpression obj)
            => obj is NullableInt32CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
