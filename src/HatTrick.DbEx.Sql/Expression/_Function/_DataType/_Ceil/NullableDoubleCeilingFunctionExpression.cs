using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleCeilingFunctionExpression :
        NullableCeilFunctionExpression<double,double?>,
        NullDoubleElement,
        AnyDoubleElement,
        IEquatable<NullableDoubleCeilingFunctionExpression>
    {
        #region constructors
        public NullableDoubleCeilingFunctionExpression(NullDoubleElement expression) 
            : base(expression)
        {

        }

        protected NullableDoubleCeilingFunctionExpression(IExpressionElement expression, string alias) :
            base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullDoubleElement As(string alias)
            => new NullableDoubleCeilingFunctionExpression(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleCeilingFunctionExpression obj)
            => obj is NullableDoubleCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
