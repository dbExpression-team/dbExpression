using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32DatePartFunctionExpression :
        NullableDatePartFunctionExpression<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32DatePartFunctionExpression>
    {
        #region constructors
        public NullableInt32DatePartFunctionExpression(DatePartsExpression datePart, NullableDateTimeElement expression) : base(datePart, expression)
        {

        }

        public NullableInt32DatePartFunctionExpression(DatePartsExpression datePart, NullableDateTimeOffsetElement expression) : base(datePart, expression)
        {

        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
        {
            Alias = alias;
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
