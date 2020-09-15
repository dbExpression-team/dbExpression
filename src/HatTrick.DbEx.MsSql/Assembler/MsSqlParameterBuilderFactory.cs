using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        private readonly MsSqlTypeMaps typeMaps;

        public MsSqlParameterBuilderFactory(MsSqlTypeMaps typeMaps)
        {
            this.typeMaps = typeMaps ?? throw new ArgumentNullException($"{nameof(typeMaps)} is required.");
        }

        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder(typeMaps);
    }
}
