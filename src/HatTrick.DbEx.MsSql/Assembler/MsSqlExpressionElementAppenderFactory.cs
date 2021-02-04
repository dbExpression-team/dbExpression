using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlExpressionElementAppenderFactory : ExpressionElementAppenderFactory
    {
        private static readonly DateAddFunctionExpressionAppender dateAddFunctionAppender = new DateAddFunctionExpressionAppender();
        private static readonly DateDiffFunctionExpressionAppender dateDiffFunctionAppender = new DateDiffFunctionExpressionAppender();
        private static readonly DatePartFunctionExpressionAppender datePartFunctionAppender = new DatePartFunctionExpressionAppender();
        private static readonly GetDateFunctionExpressionAppender getDateFunctionAppender = new GetDateFunctionExpressionAppender();
        private static readonly GetUtcDateFunctionExpressionAppender getUtcDateFunctionAppender = new GetUtcDateFunctionExpressionAppender();
        private static readonly NewIdFunctionExpressionAppender newIdFunctionAppender = new NewIdFunctionExpressionAppender();
        private static readonly SysDateTimeFunctionExpressionAppender sysDateTimeFunctionAppender = new SysDateTimeFunctionExpressionAppender();
        private static readonly SysDateTimeOffsetFunctionExpressionAppender sysDateTimeOffsetFunctionAppender = new SysDateTimeOffsetFunctionExpressionAppender();
        private static readonly SysUtcDateTimeFunctionExpressionAppender sysUtcDateTimeFunctionAppender = new SysUtcDateTimeFunctionExpressionAppender();

        public MsSqlExpressionElementAppenderFactory()
        {
            base.RegisterElementAppender(dateAddFunctionAppender);
            base.RegisterElementAppender(dateDiffFunctionAppender);
            base.RegisterElementAppender(datePartFunctionAppender);
            base.RegisterElementAppender(getDateFunctionAppender);
            base.RegisterElementAppender(getUtcDateFunctionAppender);
            base.RegisterElementAppender(newIdFunctionAppender);
            base.RegisterElementAppender(sysDateTimeFunctionAppender);
            base.RegisterElementAppender(sysDateTimeOffsetFunctionAppender);
            base.RegisterElementAppender(sysUtcDateTimeFunctionAppender);
        }
    }
}
