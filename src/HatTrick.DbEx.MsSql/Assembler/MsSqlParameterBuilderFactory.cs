using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        private readonly MsSqlTypeMaps typeMaps;
        private readonly Func<IValueConverterFactory> valueConverterFactory;

        public MsSqlParameterBuilderFactory(MsSqlTypeMaps typeMaps, Func<IValueConverterFactory> valueConverterFactory)
        {
            this.typeMaps = typeMaps ?? throw new ArgumentNullException($"{nameof(typeMaps)} is required.");
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException($"{nameof(valueConverterFactory)} is required.");
        }

        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder(typeMaps, valueConverterFactory());
    }
}
