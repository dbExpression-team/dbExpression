using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder();
    }
}
