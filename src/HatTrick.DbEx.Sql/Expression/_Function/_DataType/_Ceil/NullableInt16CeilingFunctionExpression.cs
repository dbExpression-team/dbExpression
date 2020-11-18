using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16CeilingFunctionExpression :
        NullableCeilFunctionExpression<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16CeilingFunctionExpression>
    {
        #region constructors
        public NullableInt16CeilingFunctionExpression(NullInt16Element expression) 
            : base(expression)
        {

        }

        protected NullableInt16CeilingFunctionExpression(IExpressionElement expression, string alias) 
            : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16CeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16CeilingFunctionExpression obj)
            => obj is NullableInt16CeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16CeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
