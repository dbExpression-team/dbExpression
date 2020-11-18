using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32DatePartFunctionExpression :
        NullableDatePartFunctionExpression<int,int?>,
        NullInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32DatePartFunctionExpression>
    {
        #region constructors
        public NullableInt32DatePartFunctionExpression(DatePartsExpression datePart, NullDateTimeElement expression) : base(datePart, expression)
        {

        }

        public NullableInt32DatePartFunctionExpression(DatePartsExpression datePart, NullDateTimeOffsetElement expression) : base(datePart, expression)
        {

        }

        protected NullableInt32DatePartFunctionExpression(DatePartsExpression datePart, IExpressionElement expression, string alias) : base(datePart, expression, alias)
        {

        }
        #endregion

        #region as
        public NullInt32Element As(string alias)
            => new NullableInt32DatePartFunctionExpression(base.DatePart, base.Expression, alias);
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
