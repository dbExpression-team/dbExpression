namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAssemblyPartAppender
    {
        void AppendPart(object part, ISqlStatementBuilder builder, AssemblyContext context);
    }
}
