using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class PartAppender<T> : PartAppender,
        IAssemblyPartAppender<T>
        where T : class, IExpression
    {
        public abstract void AppendPart(T expression, ISqlStatementBuilder builder, AssemblyContext context);

        public override void AppendPart(IExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as T, builder, context);
    }
}
