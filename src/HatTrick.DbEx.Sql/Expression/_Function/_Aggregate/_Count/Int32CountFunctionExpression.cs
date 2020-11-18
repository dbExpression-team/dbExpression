using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32CountFunctionExpression :
        CountFunctionExpression<int>,
        Int32Element,
        AnyInt32Element,
        IEquatable<Int32CountFunctionExpression>
    {
        #region constructors
        public Int32CountFunctionExpression() : base()
        {

        }

        public Int32CountFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected Int32CountFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        //protected override IExpressionElement<int> AliasAs(string alias)
        //    => new Int32CountFunctionExpression(base.Expression, base.IsDistinct, alias);

        public Int32Element As(string alias)
            => new Int32CountFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(Int32CountFunctionExpression obj)
            => obj is Int32CountFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32CountFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
