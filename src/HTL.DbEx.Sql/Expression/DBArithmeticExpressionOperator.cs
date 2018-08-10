using HTL.DbEx.Sql.Attribute;

namespace HTL.DbEx.Sql.Expression
{
    public enum DBArithmeticExpressionOperator
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
