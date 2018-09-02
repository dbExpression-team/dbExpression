using HatTrick.DbEx.Sql.Attribute;

namespace HatTrick.DbEx.Sql.Expression
{
    public enum ArithmeticExpressionOperator
    {
        [ExpressionOperator(" + ")]
        Add, //TODO: JRod, Concatenation???
        [ExpressionOperator(" - ")]
        Subtract,
        [ExpressionOperator(" * ")]
        Multiply,
        [ExpressionOperator(" / ")]
        Divide,
        [ExpressionOperator(" % ")]
        Modulo
    }
}
