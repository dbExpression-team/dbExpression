using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class ExpressionElementAppender<T> : ExpressionElementAppender,
        IExpressionElementAppender<T>
        where T : class, IExpressionElement
    {
        public override void AppendElement(IExpressionElement element, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendElement(element as T, builder, context);

        public abstract void AppendElement(T element, ISqlStatementBuilder builder, AssemblyContext context);
    }
}
