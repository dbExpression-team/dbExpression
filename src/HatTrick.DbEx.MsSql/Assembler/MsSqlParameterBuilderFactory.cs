using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Types;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        #region internals
        private readonly IDbTypeMapFactory<SqlDbType> typeMaps;
        private readonly IValueConverterFactory valueConverterFactory;
        #endregion

        #region constructors
        public MsSqlParameterBuilderFactory(IDbTypeMapFactory<SqlDbType> typeMaps, IValueConverterFactory valueConverterFactory)
        {
            this.typeMaps = typeMaps ?? throw new ArgumentNullException($"{nameof(typeMaps)} is required.");
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException($"{nameof(valueConverterFactory)} is required.");
        }
        #endregion

        #region methods
        public ISqlParameterBuilder CreateSqlParameterBuilder() => new MsSqlParameterBuilder(typeMaps, valueConverterFactory);
        #endregion
    }
}
