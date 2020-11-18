using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IExpressionElementAppender
    {
        void AppendElement(IExpressionElement element, ISqlStatementBuilder builder, AssemblyContext context);
    }
}
