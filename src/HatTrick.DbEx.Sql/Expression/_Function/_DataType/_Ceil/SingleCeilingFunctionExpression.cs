using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleCeilingFunctionExpression :
        CeilingFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleCeilingFunctionExpression>
    {
        #region constructors
        public SingleCeilingFunctionExpression(SingleElement expression) : base(expression)
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
        public bool Equals(SingleCeilingFunctionExpression obj)
            => obj is SingleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
