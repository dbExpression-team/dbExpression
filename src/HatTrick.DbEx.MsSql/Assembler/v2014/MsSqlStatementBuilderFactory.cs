using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler.v2014
{
    public class MsSqlStatementBuilderFactory : SqlStatementBuilderFactory
    {
        private static readonly MsSqlSelectSqlStatementAssembler _selectSqlStatementAssembler = new MsSqlSelectSqlStatementAssembler();
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
        public override void RegisterDefaultAssemblers()
        {
            base.RegisterDefaultAssemblers();
            RegisterAssembler(SqlStatementExecutionType.SelectOneType, () => _selectSqlStatementAssembler);
            RegisterAssembler(SqlStatementExecutionType.SelectOneDynamic, () => _selectSqlStatementAssembler);
            RegisterAssembler(SqlStatementExecutionType.SelectOneValue, () => _selectSqlStatementAssembler);
            RegisterAssembler(SqlStatementExecutionType.SelectManyType, () => _selectSqlStatementAssembler);
            RegisterAssembler(SqlStatementExecutionType.SelectManyDynamic, () => _selectSqlStatementAssembler);
            RegisterAssembler(SqlStatementExecutionType.SelectManyValue, () => _selectSqlStatementAssembler);
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
