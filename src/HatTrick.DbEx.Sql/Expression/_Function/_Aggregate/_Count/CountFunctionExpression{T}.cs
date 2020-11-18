using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CountFunctionExpression<TValue> : CountFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region internals
        private static readonly StringExpressionMediator STAR = new StringExpressionMediator(new LiteralExpression<string>("*"));
        #endregion

        #region constructors
        protected CountFunctionExpression() : this(STAR, false, null)
        {

        }

        protected CountFunctionExpression(bool isDistinct) : this(STAR, isDistinct, null)
        {

        }

        protected CountFunctionExpression(IExpressionElement expression, bool isDistinct) : this(expression, isDistinct, null)
        {

        }

        protected CountFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(int), isDistinct, alias)
        {

        }
        #endregion

        #region as
        //public virtual IExpressionElement<TValue> As(string alias)
        //    => AliasAs(alias);

        //protected abstract IExpressionElement<TValue> AliasAs(string alias);
        #endregion
    }
}
