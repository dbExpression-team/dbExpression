using HTL.DbEx.Sql.Assembler;

namespace HTL.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder();
    }
}
