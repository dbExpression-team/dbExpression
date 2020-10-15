using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        private readonly IDbTypeMapFactory<SqlDbType> typeMaps;
        private readonly Func<IValueConverterFactory> valueConverterFactory;

        public MsSqlParameterBuilderFactory(IDbTypeMapFactory<SqlDbType> typeMaps, Func<IValueConverterFactory> valueConverterFactory)
        {
            this.typeMaps = typeMaps ?? throw new ArgumentNullException($"{nameof(typeMaps)} is required.");
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException($"{nameof(valueConverterFactory)} is required.");
        }

        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder(typeMaps, valueConverterFactory());
    }
}
