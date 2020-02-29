using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class NewIdFunctionAppender : PartAppender<NewIdFunctionExpression>
    {
        #region methods
        public override void AppendPart(NewIdFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("NEWID()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
