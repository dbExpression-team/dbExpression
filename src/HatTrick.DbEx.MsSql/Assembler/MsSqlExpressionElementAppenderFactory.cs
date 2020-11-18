using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlExpressionElementAppenderFactory : ExpressionElementAppenderFactory
    {
        private static readonly DateAddFunctionExpressionAppender _dateAddFunctionAppender = new DateAddFunctionExpressionAppender();
        private static readonly DateDiffFunctionExpressionAppender _dateDiffFunctionAppender = new DateDiffFunctionExpressionAppender();
        private static readonly DatePartFunctionExpressionAppender _datePartFunctionAppender = new DatePartFunctionExpressionAppender();
        private static readonly GetDateFunctionExpressionAppender _getDateFunctionAppender = new GetDateFunctionExpressionAppender();
        private static readonly GetUtcDateFunctionExpressionAppender _getUtcDateFunctionAppender = new GetUtcDateFunctionExpressionAppender();
        private static readonly NewIdFunctionExpressionAppender _newIdFunctionAppender = new NewIdFunctionExpressionAppender();
        private static readonly SysDateTimeFunctionExpressionAppender _sysDateTimeFunctionAppender = new SysDateTimeFunctionExpressionAppender();
        private static readonly SysDateTimeOffsetFunctionExpressionAppender _sysDateTimeOffsetFunctionAppender = new SysDateTimeOffsetFunctionExpressionAppender();
        private static readonly SysUtcDateTimeFunctionExpressionAppender _sysUtcDateTimeFunctionAppender = new SysUtcDateTimeFunctionExpressionAppender();

        public override void RegisterDefaultElementAppenders()
        {
            base.RegisterDefaultElementAppenders();
            base.RegisterElementAppender<DateAddFunctionExpression>(_dateAddFunctionAppender);
            base.RegisterElementAppender<DateDiffFunctionExpression>(_dateDiffFunctionAppender);
            base.RegisterElementAppender<DatePartFunctionExpression>(_datePartFunctionAppender);
            base.RegisterElementAppender<GetDateFunctionExpression>(_getDateFunctionAppender);
            base.RegisterElementAppender<GetUtcDateFunctionExpression>(_getUtcDateFunctionAppender);
            base.RegisterElementAppender<NewIdFunctionExpression>(_newIdFunctionAppender);
            base.RegisterElementAppender<SysDateTimeFunctionExpression>(_sysDateTimeFunctionAppender);
            base.RegisterElementAppender<SysDateTimeOffsetFunctionExpression>(_sysDateTimeOffsetFunctionAppender);
            base.RegisterElementAppender<SysUtcDateTimeFunctionExpression>(_sysUtcDateTimeFunctionAppender);
        }
    }
}
