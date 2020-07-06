using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32DatePartFunctionExpression :
        NullableDatePartFunctionExpression<int>,
        IEquatable<NullableInt32DatePartFunctionExpression>
    {
        #region constructors
        public NullableInt32DatePartFunctionExpression(ExpressionContainer datePart, NullableExpressionMediator<DateTime> expression) : base(datePart, expression)
        {
        }

        public NullableInt32DatePartFunctionExpression(ExpressionContainer datePart, NullableExpressionMediator<DateTimeOffset> expression) : base(datePart, expression)
        {
        }
        #endregion

        #region as
        public new NullableInt32DatePartFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt32DatePartFunctionExpression obj)
            => obj is NullableInt32DatePartFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32DatePartFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
