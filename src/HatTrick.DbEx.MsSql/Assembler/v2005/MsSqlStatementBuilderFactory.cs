using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2005
{
    public class MsSqlStatementBuilderFactory : SqlStatementBuilderFactory
    {
        private static readonly MsSqlSelectSqlStatementAssembler _selectSqlStatementAssembler = new MsSqlSelectSqlStatementAssembler();
        private static readonly MsSql.v2005.Assembler.MsSqlInsertSqlStatementAssembler _insertManySqlStatementAssembler = new MsSql.v2005.Assembler.MsSqlInsertSqlStatementAssembler();
        private static readonly MsSqlDeleteSqlStatementAssembler _deleteSqlStatementAssembler = new MsSqlDeleteSqlStatementAssembler();
        private static readonly MsSqlUpdateSqlStatementAssembler _updateSqlStatementAssembler = new MsSqlUpdateSqlStatementAssembler();

        #region methods
        public override void RegisterDefaultStatementAssemblers()
        {
            base.RegisterDefaultStatementAssemblers();
            RegisterStatementAssembler<SelectQueryExpression, MsSqlSelectSqlStatementAssembler>(() => _selectSqlStatementAssembler);
            RegisterStatementAssembler<InsertQueryExpression, MsSql.v2005.Assembler.MsSqlInsertSqlStatementAssembler>(() => _insertManySqlStatementAssembler);
            RegisterStatementAssembler<DeleteQueryExpression, MsSqlDeleteSqlStatementAssembler>(() => _deleteSqlStatementAssembler);
            RegisterStatementAssembler<UpdateQueryExpression, MsSqlUpdateSqlStatementAssembler>(() => _updateSqlStatementAssembler);
        }
        #endregion
    }
}
