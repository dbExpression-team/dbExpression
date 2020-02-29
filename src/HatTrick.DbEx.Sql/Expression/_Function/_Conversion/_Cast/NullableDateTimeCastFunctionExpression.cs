using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeCastFunctionExpression :
        NullableCastFunctionExpression<DateTime>,
        IEquatable<NullableDateTimeCastFunctionExpression>
    {
        #region constructors
        public NullableDateTimeCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeCastFunctionExpression obj)
            => obj is NullableDateTimeCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
