using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleVarianceFunctionExpression :
        VarianceFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleVarianceFunctionExpression>
    {
        #region constructors
        public SingleVarianceFunctionExpression(ByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleVarianceFunctionExpression(Int16Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleVarianceFunctionExpression(Int32Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleVarianceFunctionExpression(Int64Element expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleVarianceFunctionExpression(DoubleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleVarianceFunctionExpression(DecimalElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public SingleVarianceFunctionExpression(SingleElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected SingleVarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleVarianceFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(SingleVarianceFunctionExpression obj)
            => obj is SingleVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
