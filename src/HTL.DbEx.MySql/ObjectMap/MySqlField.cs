using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HTL.DbEx.Sql.ObjectMap;
using HTL.DbEx.MySql.Types;

namespace HTL.DbEx.MySql.ObjectMap
{
    public class MySqlField : SqlField
    {
        #region internals
        private MySqlDbType? _knownSqlDBType;
        #endregion

        #region interface
        #endregion

        #region constructors
        public MySqlField(ColumnInfo column, List<SqlRelationship> relationships) : base(column, relationships)
        {
        }
        #endregion

        #region extract
        protected override void Extract()
        {
            base.Extract();

            base._isKnownSqlType = MySqlTypeMap.IsKnownSqlTypeDeclaration(_column.DataType);
            _knownSqlDBType = (_isKnownSqlType) ? MySqlTypeMap.GetSqlDBTypeFromDeclaration(_column.DataType) : null;

            if (_isKnownSqlType && base.UnSigned)
            {
                _knownSqlDBType = MySqlTypeMap.GetUnsignedVariant(_knownSqlDBType.Value);
            }

            base.AssemblyType = (_isKnownSqlType) ? MySqlTypeMap.GetAssemblyType(_knownSqlDBType.Value, _column.IsNullable) : typeof(object);

            if (_knownSqlDBType.HasValue)
            {
                base.MaxLength = _column.CharacterMaxLength;
                //TODO: JRod, we need to bring in the encoding and divide max length by 2 if 16 bits required
                //if ((base.MaxLength > 0) && char encoding != 8 bit encoding))
                //{
                //    base.MaxLength = base.MaxLength / 2;
                //}
                //base.SqlTypeDefinition = MySqlTypeMap.GetSqlTypeText(base.AssemblyType, base.MaxLength, null, null);
            }

            if (_knownSqlDBType.HasValue && MySqlTypeMap.SqlTypeAllowsPrecisionAndScale(_knownSqlDBType.Value))
            {
                base.Precision = _column.Precision;
                base.Scale = _column.Scale;
                //base.SqlTypeDefinition = MySqlTypeMap.GetSqlTypeText(base.AssemblyType, null, _column.Precision, _column.Scale);
            }

            base.IsPrimaryKey = _column.IsPrimaryKey;
        }
        #endregion
    }
}
