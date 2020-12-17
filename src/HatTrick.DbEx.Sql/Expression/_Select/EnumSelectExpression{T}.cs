using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class EnumSelectExpression<TEnum> : SelectExpression<TEnum>,
        EnumElement<TEnum>
        where TEnum : struct, Enum, IComparable
    {
        public EnumSelectExpression(IExpressionElement<TEnum> expression)
            : base(expression)
        {

        }

        #region as
        public EnumElement<TEnum> As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region order by
        OrderByExpression AnyElement.Asc => throw new DbExpressionException("Select expressions cannot be used in Order By clauses.");

        OrderByExpression AnyElement.Desc => throw new DbExpressionException("Select expressions cannot be used in Order By clauses.");
        #endregion
    }
}
