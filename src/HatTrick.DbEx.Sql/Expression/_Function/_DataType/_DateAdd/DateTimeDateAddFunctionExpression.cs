using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeDateAddFunctionExpression :
        DateAddFunctionExpression<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<DateTimeDateAddFunctionExpression>
    {
        #region constructors
        public DateTimeDateAddFunctionExpression(DatePartsExpression datePart, Int32Element value, DateTimeElement expression) : base(datePart, value, expression)
        {

        }

        protected DateTimeDateAddFunctionExpression(DatePartsExpression datePart, IExpressionElement value, IExpressionElement expression, string alias) : base(datePart, value, expression, alias)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeDateAddFunctionExpression(base.DatePart, base.Value, base.Expression, alias);
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
