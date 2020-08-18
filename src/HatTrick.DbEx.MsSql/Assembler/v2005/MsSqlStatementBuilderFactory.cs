using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2005
{
    public class MsSqlStatementBuilderFactory : SqlStatementBuilderFactory
    {
        private static readonly MsSqlSelectSqlStatementAssembler _selectSqlStatementAssembler = new MsSqlSelectSqlStatementAssembler();
        private static readonly MsSqlDeleteSqlStatementAssembler _deleteSqlStatementAssembler = new MsSqlDeleteSqlStatementAssembler();
        private static readonly MsSqlUpdateSqlStatementAssembler _updateSqlStatementAssembler = new MsSqlUpdateSqlStatementAssembler();

        #region methods
        public override void RegisterDefaultStatementAssemblers()
        {
            base.RegisterDefaultStatementAssemblers();
            RegisterStatementAssembler<SelectQueryExpression, MsSqlSelectSqlStatementAssembler>(() => _selectSqlStatementAssembler);
            RegisterStatementAssembler<InsertQueryExpression, MsSqlInsertSqlStatementAssembler>(() => throw new DbExpressionException("MsSql version 2005 does not support inserting multiple records in a single statement."));
            RegisterStatementAssembler<DeleteQueryExpression, MsSqlDeleteSqlStatementAssembler>(() => _deleteSqlStatementAssembler);
            RegisterStatementAssembler<UpdateQueryExpression, MsSqlUpdateSqlStatementAssembler>(() => _updateSqlStatementAssembler);
        }
        #endregion
    }
}
