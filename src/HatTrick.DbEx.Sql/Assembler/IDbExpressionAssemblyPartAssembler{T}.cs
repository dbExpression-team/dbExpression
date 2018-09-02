using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IDbExpressionAssemblyPartAssembler<T> : IDbExpressionAssemblyPartAssembler
    {
        string Assemble(T expression, ISqlStatementBuilder builder, AssemblerOverrides overrides);
    }
}
