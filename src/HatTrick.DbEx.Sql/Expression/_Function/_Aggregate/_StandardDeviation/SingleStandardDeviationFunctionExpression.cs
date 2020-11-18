using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleStandardDeviationFunctionExpression :
        StandardDeviationFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleStandardDeviationFunctionExpression>
    {
        #region constructors
        public SingleStandardDeviationFunctionExpression(ByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleStandardDeviationFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleStandardDeviationFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleStandardDeviationFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected SingleStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleStandardDeviationFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(SingleStandardDeviationFunctionExpression obj)
            => obj is SingleStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
