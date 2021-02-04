using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2016
{
    public class MsSqlStatementBuilderFactory : SqlStatementBuilderFactory
    {
        private static readonly MsSqlSelectSqlStatementAssembler selectSqlStatementAssembler = new MsSqlSelectSqlStatementAssembler();
        private static readonly MsSqlInsertSqlStatementAssembler insertManySqlStatementAssembler = new MsSqlInsertSqlStatementAssembler();
        private static readonly MsSqlDeleteSqlStatementAssembler deleteSqlStatementAssembler = new MsSqlDeleteSqlStatementAssembler();
        private static readonly MsSqlUpdateSqlStatementAssembler updateSqlStatementAssembler = new MsSqlUpdateSqlStatementAssembler();

        #region constructors
        public MsSqlStatementBuilderFactory()
        {
            RegisterStatementAssembler<SelectQueryExpression, MsSqlSelectSqlStatementAssembler>(selectSqlStatementAssembler);
            RegisterStatementAssembler<InsertQueryExpression, MsSqlInsertSqlStatementAssembler>(insertManySqlStatementAssembler);
            RegisterStatementAssembler<DeleteQueryExpression, MsSqlDeleteSqlStatementAssembler>(deleteSqlStatementAssembler);
            RegisterStatementAssembler<UpdateQueryExpression, MsSqlUpdateSqlStatementAssembler>(updateSqlStatementAssembler);
        }
        #endregion
    }
}
