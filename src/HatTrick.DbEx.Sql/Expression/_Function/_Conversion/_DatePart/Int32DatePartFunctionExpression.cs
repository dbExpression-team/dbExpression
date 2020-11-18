using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32DatePartFunctionExpression :
        DatePartFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32DatePartFunctionExpression>
    {
        #region constructors
        public Int32DatePartFunctionExpression(DatePartsExpression datePart, DateTimeElement expression) : base(datePart, expression)
        {

        }
        public Int32DatePartFunctionExpression(DatePartsExpression datePart, DateTimeOffsetElement expression) : base(datePart, expression)
        {

        }

        protected Int32DatePartFunctionExpression(DatePartsExpression datePart, IExpressionElement expression, string alias) : base(datePart, expression, alias)
        {

        }
        #endregion

        #region as
        public Int32Element As(string alias)
            => new Int32DatePartFunctionExpression(base.DatePart, base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(Int32DatePartFunctionExpression obj)
            => obj is Int32DatePartFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32DatePartFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
