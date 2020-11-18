using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IExpressionElementAppenderFactory
    {
        IExpressionElementAppender CreateElementAppender(IExpressionElement element);
    }
}
