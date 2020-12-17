using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleCastFunctionExpression :
        CastFunctionExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleCastFunctionExpression>
    {
        #region constructors
        public  DoubleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        public DoubleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int precision, int? scale)
            : base(expression, convertToDbType, precision, scale)
        {

        }
        #endregion

        #region as
        public DoubleElement As(string alias)
            => new DoubleSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(DoubleCastFunctionExpression obj)
            => obj is DoubleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
