namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class PartAppender<T> : PartAppender,
        IAssemblyPartAppender<T>
        where T : class
    {
        public override void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as T, builder, context);

        public abstract void AppendPart(T expression, ISqlStatementBuilder builder, AssemblyContext context);
    }
}
