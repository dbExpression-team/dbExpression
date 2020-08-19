using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAssemblyPartAppenderFactory
    {
        IAssemblyPartAppender<T> CreatePartAppender<T>(T part)
            where T : IExpression;
    }
}
