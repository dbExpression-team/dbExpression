using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleIsNullFunctionExpression :
        IsNullFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleIsNullFunctionExpression>
    {
        #region constructors
        public SingleIsNullFunctionExpression(AnySingleElement expression, SingleElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleIsNullFunctionExpression obj)
            => obj is SingleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
