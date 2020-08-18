using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2017
{
    public class MsSqlSelectSqlStatementAssembler : HatTrick.DbEx.MsSql.Assembler.MsSqlSelectSqlStatementAssembler
    {
        protected override void AssembleStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            base.AssembleStatement(expression, builder, context);
            if (expression.SkipValue.HasValue)
            {
                builder.Appender
                    .Indentation++
                    .Indent()
                    .Write("OFFSET ")
                    .Write(builder.Parameters.Add(expression.SkipValue.Value).ParameterName)
                    .Indent().Write(" ROWS")
                    .LineBreak()
                    .Indentation--;
            }
            if (expression.LimitValue.HasValue)
            {
                builder.Appender
                    .Indentation++
                    .Indent()
                    .Write("FETCH NEXT ")
                    .Write(builder.Parameters.Add(expression.LimitValue.Value).ParameterName)
                    .Indent()
                    .Write(" ROWS ONLY")
                    .LineBreak()
                    .Indentation--;
            }
        }
    }
}
