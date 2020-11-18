using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IExpressionElementAppender<T> : IExpressionElementAppender
        where T : IExpressionElement
    {
        void AppendElement(T element, ISqlStatementBuilder builder, AssemblyContext context);
    }
}
