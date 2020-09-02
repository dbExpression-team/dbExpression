using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        private readonly Func<Type, SqlDbType> typeMap;

        public MsSqlParameterBuilderFactory(Func<Type, SqlDbType> typeMap)
        {
            this.typeMap = typeMap ?? throw new ArgumentNullException($"{nameof(typeMap)} is required.");
        }

        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder(typeMap);
    }
}
