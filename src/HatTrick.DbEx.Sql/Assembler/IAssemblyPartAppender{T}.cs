using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAssemblyPartAppender<T> : IAssemblyPartAppender
    {
        void AppendPart(T expression, ISqlStatementBuilder builder, AssemblerContext context);
    }
}
