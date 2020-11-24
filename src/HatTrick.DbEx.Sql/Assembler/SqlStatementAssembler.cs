using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementAssembler : ISqlStatementAssembler
    {
        #region methods
        public abstract void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context);
        #endregion
    }
}
