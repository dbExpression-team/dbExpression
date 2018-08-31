using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IDbExpressionAssemblyPartAssembler<T> : IDbExpressionAssemblyPartAssembler
    {
        string AssemblePart(T expression, ISqlStatementBuilder builder, AssemblerOverrides overrides);
    }
}
