using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DbTypeExpressionAppender : ExpressionElementAppender<DbTypeExpression>
    {
        #region methods
        public override void AppendElement(DbTypeExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.Appender.Write(expression.Expression.ToString());
        #endregion
    }
}
