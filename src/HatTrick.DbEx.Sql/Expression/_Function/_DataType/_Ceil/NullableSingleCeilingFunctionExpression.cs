using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCeilingFunctionExpression :
        NullableCeilFunctionExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleCeilingFunctionExpression>
    {
        #region constructors
        public NullableSingleCeilingFunctionExpression(NullSingleElement expression) 
            : base(expression)
        {

        }

        protected NullableSingleCeilingFunctionExpression(IExpressionElement expression, string alias) 
            : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleCeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleCeilingFunctionExpression obj)
            => obj is NullableSingleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
