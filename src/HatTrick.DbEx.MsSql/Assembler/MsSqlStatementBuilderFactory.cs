using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public abstract class MsSqlStatementBuilderFactory : SqlStatementBuilderFactory
    {
        #region methods
        public override void RegisterDefaultAssemblers()
        {
            base.RegisterDefaultAssemblers();
            base.RegisterAssembler(SqlStatementExecutionType.SelectAllType, new SelectAllMsSqlAssembler());
            base.RegisterAssembler(SqlStatementExecutionType.SelectAllDynamic, new SelectAllMsSqlAssembler());
            base.RegisterAssembler(SqlStatementExecutionType.SelectAllValue, new SelectAllMsSqlAssembler());
        }

        public override void RegisterDefaultValueFormatters()
        {
            base.RegisterDefaultValueFormatters();
            base.RegisterValueFormatter<string,StringValueTypeFormatter>();
        }
        #endregion
    }
}
