using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder();
    }
}
