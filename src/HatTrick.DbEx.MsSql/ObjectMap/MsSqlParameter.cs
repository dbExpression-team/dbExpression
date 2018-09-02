using System.Data;
using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql.ObjectMap;

namespace HatTrick.DbEx.MsSql.ObjectMap
{
    public class MsSqlParameter : SqlParameter
    {
        #region constructors
        public MsSqlParameter(ParameterInfo parameterInfo) : base(parameterInfo)
        {
        }
        #endregion

        #region extract
        protected override void Extract()
        {
            base.Extract();

            bool isKnownSqlType = MsSqlTypeMap.IsKnownSqlTypeDeclaration(_parameterInfo.DataType);
            SqlDbType? knownSqlDBType = (isKnownSqlType) ? MsSqlTypeMap.GetSqlDBTypeFromDeclaration(_parameterInfo.DataType) : null;
            base.AssemblyType = (isKnownSqlType) ? MsSqlTypeMap.GetAssemblyType(knownSqlDBType.Value, true) : typeof(object);

            this.IsOutputParameter = _parameterInfo.IsOutputParameter;

            if (knownSqlDBType.HasValue)
            {
                this.MaxLength = _parameterInfo.MaxLength;
                if ((this.MaxLength > 0) && (knownSqlDBType.Value == SqlDbType.NChar || knownSqlDBType.Value == SqlDbType.NText || knownSqlDBType.Value == SqlDbType.NVarChar))
                {
                    this.MaxLength = this.MaxLength / 2;
                }
                this.SqlTypeDefinition = MsSqlTypeMap.GetSqlTypeText(this.AssemblyType, this.MaxLength, null, null);
            }

            if (knownSqlDBType.HasValue && MsSqlTypeMap.SqlTypeAllowsPrecisionAndScale(knownSqlDBType.Value))
            {
                this.Precision = _parameterInfo.Precision;
                this.Scale = _parameterInfo.Scale;
                this.SqlTypeDefinition = MsSqlTypeMap.GetSqlTypeText(this.AssemblyType, null, _parameterInfo.Precision, _parameterInfo.Scale);
            }
        }
        #endregion
    }
}
