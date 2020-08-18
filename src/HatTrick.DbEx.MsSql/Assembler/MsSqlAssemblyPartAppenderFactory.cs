using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlAssemblyPartAppenderFactory : AssemblyPartAppenderFactory
    {
        private static readonly DateAddFunctionAppender _dateAddFunctionAppender = new DateAddFunctionAppender();
        private static readonly DateDiffFunctionAppender _dateDiffFunctionAppender = new DateDiffFunctionAppender();
        private static readonly DatePartFunctionAppender _datePartFunctionAppender = new DatePartFunctionAppender();
        private static readonly GetDateFunctionAppender _getDateFunctionAppender = new GetDateFunctionAppender();
        private static readonly GetUtcDateFunctionAppender _getUtcDateFunctionAppender = new GetUtcDateFunctionAppender();
        private static readonly NewIdFunctionAppender _newIdFunctionAppender = new NewIdFunctionAppender();
        private static readonly SysDateTimeFunctionAppender _sysDateTimeFunctionAppender = new SysDateTimeFunctionAppender();
        private static readonly SysDateTimeOffsetFunctionAppender _sysDateTimeOffsetFunctionAppender = new SysDateTimeOffsetFunctionAppender();
        private static readonly SysUtcDateTimeFunctionAppender _sysUtcDateTimeFunctionAppender = new SysUtcDateTimeFunctionAppender();

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
        }
    }
}
