using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2012
{
    public class MsSqlStatementBuilderFactory : SqlStatementBuilderFactory
    {
        private static readonly MsSqlSelectSqlStatementAssembler _selectSqlStatementAssembler = new MsSqlSelectSqlStatementAssembler();
        private static readonly MsSqlInsertSqlStatementAssembler _insertManySqlStatementAssembler = new MsSqlInsertSqlStatementAssembler();
        private static readonly MsSqlDeleteSqlStatementAssembler _deleteSqlStatementAssembler = new MsSqlDeleteSqlStatementAssembler();
        private static readonly MsSqlUpdateSqlStatementAssembler _updateSqlStatementAssembler = new MsSqlUpdateSqlStatementAssembler();
        private static readonly DateAddFunctionAppender _dateAddFunctionAppender = new DateAddFunctionAppender();
        private static readonly DateDiffFunctionAppender _dateDiffFunctionAppender = new DateDiffFunctionAppender();
        private static readonly DatePartFunctionAppender _datePartFunctionAppender = new DatePartFunctionAppender();
        private static readonly GetDateFunctionAppender _getDateFunctionAppender = new GetDateFunctionAppender();
        private static readonly GetUtcDateFunctionAppender _getUtcDateFunctionAppender = new GetUtcDateFunctionAppender();
        private static readonly NewIdFunctionAppender _newIdFunctionAppender = new NewIdFunctionAppender();
        private static readonly SysDateTimeFunctionAppender _sysDateTimeFunctionAppender = new SysDateTimeFunctionAppender();
        private static readonly SysDateTimeOffsetFunctionAppender _sysDateTimeOffsetFunctionAppender = new SysDateTimeOffsetFunctionAppender();
        private static readonly SysUtcDateTimeFunctionAppender _sysUtcDateTimeFunctionAppender = new SysUtcDateTimeFunctionAppender();
        private static readonly DateTimeAppender _dateTimeAppender = new DateTimeAppender();
        private static readonly NullableDateTimeAppender _nullableDateTimeAppender = new NullableDateTimeAppender();
        private static readonly DateTimeOffsetAppender _dateTimeOffsetAppender = new DateTimeOffsetAppender();
        private static readonly NullableDateTimeOffsetAppender _nullableDateTimeOffsetAppender = new NullableDateTimeOffsetAppender();

        #region methods
        public override void RegisterDefaultStatementAssemblers()
        {
            base.RegisterDefaultStatementAssemblers();
            RegisterStatementAssembler<SelectQueryExpression, MsSqlSelectSqlStatementAssembler>(() => _selectSqlStatementAssembler);
            RegisterStatementAssembler<InsertQueryExpression, MsSqlInsertSqlStatementAssembler>(() => _insertManySqlStatementAssembler);
            RegisterStatementAssembler<DeleteQueryExpression, MsSqlDeleteSqlStatementAssembler>(() => _deleteSqlStatementAssembler);
            RegisterStatementAssembler<UpdateQueryExpression, MsSqlUpdateSqlStatementAssembler>(() => _updateSqlStatementAssembler);
        }

        public override void RegisterDefaultPartAppenders()
        {
            base.RegisterDefaultPartAppenders();
            base.RegisterPartAppender(_dateAddFunctionAppender);
            base.RegisterPartAppender(_dateDiffFunctionAppender);
            base.RegisterPartAppender(_datePartFunctionAppender);
            base.RegisterPartAppender(_getDateFunctionAppender);
            base.RegisterPartAppender(_getUtcDateFunctionAppender);
            base.RegisterPartAppender(_newIdFunctionAppender);
            base.RegisterPartAppender(_sysDateTimeFunctionAppender);
            base.RegisterPartAppender(_sysDateTimeOffsetFunctionAppender);
            base.RegisterPartAppender(_sysUtcDateTimeFunctionAppender);
            base.RegisterPartAppender(_nullableDateTimeAppender);
            base.RegisterPartAppender(_dateTimeAppender);
            base.RegisterPartAppender(_dateTimeOffsetAppender);
            base.RegisterPartAppender(_nullableDateTimeOffsetAppender);
        }
        #endregion
    }
}
