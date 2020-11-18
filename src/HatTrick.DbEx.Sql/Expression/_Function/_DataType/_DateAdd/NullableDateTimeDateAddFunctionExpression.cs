using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeDateAddFunctionExpression :
        NullableDateAddFunctionExpression<DateTime,DateTime?>,
        NullDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeDateAddFunctionExpression>
    {
        #region constructors
        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, AnyInt32Element value, NullDateTimeElement expression)
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, AnyInt32Element value, DateTimeElement expression) 
            : base(datePart, value, expression)
        {

        }

        protected NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, IExpressionElement value, IExpressionElement expression, string alias)
            : base(datePart, value, expression, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeElement As(string alias)
            => new NullableDateTimeDateAddFunctionExpression(base.DatePart, base.Value, base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeDateAddFunctionExpression obj)
            => obj is NullableDateTimeDateAddFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeDateAddFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
