using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Assembler
{
    public interface ISqlPartAssembler<T> : ISqlPartAssembler
    {
        string Assemble(T expression, ISqlStatementBuilder builder);
    }
}
