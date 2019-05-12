using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler.v2012
{
    public class MsSqlStatementBuilderFactory : SqlStatementBuilderFactory
    {
        private static readonly ExpressionSetAppender _expressionSetAppender = new MsSqlExpressionSetAppender();

        #region methods
        public override void RegisterDefaultPartAppenders()
        {
            base.RegisterDefaultPartAppenders();
            base.RegisterPartAppender(_expressionSetAppender);
        }

        public override void RegisterDefaultValueFormatters()
        {
            base.RegisterDefaultValueFormatters();
            base.RegisterValueFormatter<string,StringValueTypeFormatter>();
        }
        #endregion
    }
}
