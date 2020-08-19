using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

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
            base.RegisterPartAppender<DateAddFunctionExpression>(_dateAddFunctionAppender);
            base.RegisterPartAppender<DateDiffFunctionExpression>(_dateDiffFunctionAppender);
            base.RegisterPartAppender<DatePartFunctionExpression>(_datePartFunctionAppender);
            base.RegisterPartAppender<GetDateFunctionExpression>(_getDateFunctionAppender);
            base.RegisterPartAppender<GetUtcDateFunctionExpression>(_getUtcDateFunctionAppender);
            base.RegisterPartAppender<NewIdFunctionExpression>(_newIdFunctionAppender);
            base.RegisterPartAppender<SysDateTimeFunctionExpression>(_sysDateTimeFunctionAppender);
            base.RegisterPartAppender<SysDateTimeOffsetFunctionExpression>(_sysDateTimeOffsetFunctionAppender);
            base.RegisterPartAppender<SysUtcDateTimeFunctionExpression>(_sysUtcDateTimeFunctionAppender);
        }
    }
}
