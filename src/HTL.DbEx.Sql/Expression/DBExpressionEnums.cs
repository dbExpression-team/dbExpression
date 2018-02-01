using System;

namespace HTL.DbEx.Sql.Expression
{
    #region filter
    public enum DBFilterExpressionOperator
    {
        Equal = 0,
        NotEqual = 1,
        LessThan = 2,
        LessThanOrEqual = 3,
        GreaterThan = 4,
        GreaterThanOrEqual = 5,
        Like = 6,
        In = 7
    }
    #endregion

    #region conditional
    public enum DBConditionalExpressionOperator
    {
        And = 0,
        Or = 1
    }
    #endregion

    #region order
    public enum DBOrderExpressionDirection
    {
        ASC = 0,
        DESC = 1
    }
    #endregion

    #region aggregate function
    public enum DBSelectExpressionAggregateFunction
    {
        AVG,
        MIN,
        MAX,
        SUM,
        COUNT
    }
    #endregion

    #region join
    public enum DBExpressionJoinType
    {
        LEFT,
        RIGHT,
        INNER,
        FULL,
        CROSS
    }
    #endregion

    #region arithmentic operator
    public enum DBArithmeticExpressionOperator
    {
        Add, //TODO: JRod, Concatenation???
        Subtract,
        Multiply,
        Divide,
        Modulo
    }
    #endregion
}