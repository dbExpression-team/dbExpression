using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeDateAddFunctionExpression :
        NullableDateAddFunctionExpression<DateTime,DateTime?>,
        NullableDateTimeElement,
        AnyDateTimeElement,
        IEquatable<NullableDateTimeDateAddFunctionExpression>
    {
        #region constructors
        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, Int32Element value, NullableDateTimeElement expression)
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, Int32Element value, DateTimeElement expression) 
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, NullableInt32Element value, NullableDateTimeElement expression)
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, NullableInt32Element value, DateTimeElement expression)
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, AnyObjectElement value, NullableDateTimeElement expression) 
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, AnyObjectElement value, DateTimeElement expression)
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, Int32Element value, AnyObjectElement expression) 
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeDateAddFunctionExpression(DatePartsExpression datePart, NullableInt32Element value, AnyObjectElement expression)
            : base(datePart, value, expression)
        {

        }
        #endregion

        #region as
        public NullableDateTimeElement As(string alias)
            => new NullableDateTimeSelectExpression(this).As(alias);
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
