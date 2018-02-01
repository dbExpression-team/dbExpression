using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HTL.DbEx.MsSql.Types;
using HTL.DbEx.Sql.ObjectMap;

namespace HTL.DbEx.MsSql.ObjectMap
{
    public class MsSqlField : SqlField
    {
        #region internals
        protected SqlDbType? _knownSqlDBType;
        #endregion

        #region constructors
        public MsSqlField(ColumnInfo column, List<SqlRelationship> relationships) : base(column, relationships)
        {
        }
        #endregion

        #region extract
        protected override void Extract()
        {
            base.Extract();

            base._isKnownSqlType = MsSqlTypeMap.IsKnownSqlTypeDeclaration(_column.DataType);
            _knownSqlDBType = (_isKnownSqlType) ? MsSqlTypeMap.GetSqlDBTypeFromDeclaration(_column.DataType) : null;

            base.AssemblyType = (_isKnownSqlType) ? MsSqlTypeMap.GetAssemblyType(_knownSqlDBType.Value, _column.IsNullable) : typeof(object);

            if (_knownSqlDBType.HasValue)
            {
                base.MaxLength = _column.CharacterMaxLength;
                if ((base.MaxLength > 0) && (_knownSqlDBType.Value == SqlDbType.NChar || _knownSqlDBType.Value == SqlDbType.NText || _knownSqlDBType.Value == SqlDbType.NVarChar))
                {
                    base.MaxLength = base.MaxLength / 2;
                }
                base.SqlTypeDefinition = MsSqlTypeMap.GetSqlTypeText(base.AssemblyType, base.MaxLength, null, null);
            }

            if (_knownSqlDBType.HasValue && MsSqlTypeMap.SqlTypeAllowsPrecisionAndScale(_knownSqlDBType.Value))
            {
                base.Precision = _column.Precision;
                base.Scale = _column.Scale;
                base.SqlTypeDefinition = MsSqlTypeMap.GetSqlTypeText(base.AssemblyType, null, _column.Precision, _column.Scale);
            }
        }
        #endregion
    }
}
