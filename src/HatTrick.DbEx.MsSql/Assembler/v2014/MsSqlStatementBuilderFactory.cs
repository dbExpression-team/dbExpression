using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler.v2014
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

        public override void RegisterDefaultAliasProviders()
        {
            base.RegisterDefaultAliasProviders();
            base.RegisterAliasProvider(_expressionSetAppender);
        }

        public override void RegisterDefaultValueFormatters()
        {
            base.RegisterDefaultValueFormatters();
            base.RegisterValueFormatter<string,StringValueTypeFormatter>();
        }
        #endregion
    }
}
