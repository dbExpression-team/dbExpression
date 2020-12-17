using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class ExpressionElementAppender : 
        IExpressionElementAppender
    {
        public abstract void AppendElement(IExpressionElement expression, ISqlStatementBuilder builder, AssemblyContext context);

        protected static void AppendDistinct(IExpressionIsDistinctProvider distinct, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (distinct.IsDistinct)
                builder.Appender.Write("DISTINCT ");
        }
    }
}
