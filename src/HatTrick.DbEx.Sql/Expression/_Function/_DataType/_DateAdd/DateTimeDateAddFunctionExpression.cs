using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeDateAddFunctionExpression :
        DateAddFunctionExpression<DateTime>,
        IEquatable<DateTimeDateAddFunctionExpression>
    {
        #region constructors
        public DateTimeDateAddFunctionExpression(ExpressionContainer datePart, ExpressionContainer value, ExpressionContainer expression) : base(datePart, value, expression)
        {
        }
        #endregion

        #region as
        public new DateTimeDateAddFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeDateAddFunctionExpression obj)
            => obj is DateTimeDateAddFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeDateAddFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
