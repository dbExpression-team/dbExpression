using System;
using System.Collections.Generic;
using System.Data;
using HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql.Types
{
    public static class MsSqlTypeMap
    {
        #region internals
        private static Dictionary<Type, SqlDbType> sqlTypeMap = new Dictionary<Type, SqlDbType>()
        {
            { typeof(string), SqlDbType.VarChar }, //TODO: JRod, how varchar/nvarchar (sqlserver isnt picky...sqlce is ?)
            { typeof(int), SqlDbType.Int },
            { typeof(decimal), SqlDbType.Decimal },
            { typeof(DateTime), SqlDbType.DateTime },
            { typeof(bool), SqlDbType.Bit },
            { typeof(byte), SqlDbType.TinyInt },
            { typeof(long), SqlDbType.BigInt },
            { typeof(object), SqlDbType.Binary },
            { typeof(double), SqlDbType.Float },
            { typeof(float), SqlDbType.Real },
            { typeof(short), SqlDbType.SmallInt },
            { typeof(Guid), SqlDbType.UniqueIdentifier },
            { typeof(byte[]), SqlDbType.VarBinary },
            { typeof(ushort), SqlDbType.SmallInt },
            { typeof(sbyte), SqlDbType.TinyInt },
            { typeof(uint), SqlDbType.Int },
            { typeof(TimeSpan), SqlDbType.Time },
            
            { typeof(int?), SqlDbType.Int },
            { typeof(bool?), SqlDbType.Bit },
            { typeof(DateTime?), SqlDbType.DateTime },
            { typeof(decimal?), SqlDbType.Decimal },
            { typeof(long?), SqlDbType.BigInt },
            { typeof(ulong?), SqlDbType.BigInt },
            { typeof(double?), SqlDbType.Float },
            { typeof(float?), SqlDbType.Real },
            { typeof(short?), SqlDbType.SmallInt },
            { typeof(ushort?), SqlDbType.SmallInt },
            { typeof(byte?), SqlDbType.TinyInt },
            { typeof(sbyte?), SqlDbType.TinyInt },
            { typeof(uint?), SqlDbType.Int }
        };
        #endregion

        #region get sql type text
        public static string GetSqlTypeText(Type t, int? maxLength, int? precision, int? scale)
        {
            string sqlBase;
            if (IsSqlTypeKnown(t))
            {
                sqlBase = GetSqlType(t).ToString().ToLower();
                if (maxLength.HasValue)
                {
                    if (maxLength.Value == -1)
                    {
                        return $"{sqlBase}(max)";
                    }
                    else
                    {
                        return $"{sqlBase}({maxLength.Value})";
                    }
                }
                else if (precision.HasValue)
                {
                    sqlBase = $"{sqlBase}({precision.Value})";
                    if (scale.HasValue)
                    {
                        return $"{sqlBase},{scale.Value})";
                    }
                    else
                    {
                        return $"{sqlBase},0)";
                    }
                }
                else
                {
                    return sqlBase;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region get assembly type
        public static Type GetAssemblyType(SqlDbType dbType, bool allowNull)
        {
            Type t = null;
            switch (dbType)
            {
                case SqlDbType.BigInt:
                    t = (allowNull) ? typeof(long?) : typeof(long);
                    break;
                case SqlDbType.Binary:
                    t = typeof(byte[]);
                    break;
                case SqlDbType.Bit:
                    t = (allowNull) ? typeof(bool?) : typeof(bool);
                    break;
                case SqlDbType.Char:
                    t = typeof(string);
                    break;
                case SqlDbType.Date:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case SqlDbType.DateTime:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case SqlDbType.DateTime2:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case SqlDbType.DateTimeOffset:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime); //TODO: JRod, this may be timespan
                    break;
                case SqlDbType.Decimal:
                    t = (allowNull) ? typeof(decimal?) : typeof(decimal);
                    break;
                case SqlDbType.Float:
                    t = (allowNull) ? typeof(double?) : typeof(double);  //TODO: JRod, this may be single...
                    break;
                case SqlDbType.Image:
                    t = typeof(byte[]);
                    break;
                case SqlDbType.Int:
                    t = (allowNull) ? typeof(int?) : typeof(int);
                    break;
                case SqlDbType.Money:
                    t = (allowNull) ? typeof(decimal?) : typeof(decimal);
                    break;
                case SqlDbType.NChar:
                    t = typeof(string);
                    break;
                case SqlDbType.NText:
                    t = typeof(string);
                    break;
                case SqlDbType.NVarChar:
                    t = typeof(string);
                    break;
                case SqlDbType.Real:
                    t = (allowNull) ? typeof(float?) : typeof(float); //TODO: JRod, this may be double/single???
                    break;
                case SqlDbType.SmallDateTime:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case SqlDbType.SmallInt:
                    t = (allowNull) ? typeof(Int16?) : typeof(Int16);
                    break;
                case SqlDbType.SmallMoney:
                    t = (allowNull) ? typeof(decimal?) : typeof(decimal);
                    break;
                case SqlDbType.Structured:
                    throw new ArgumentException("Structured??? Seriously???  --> JROD E.");
                case SqlDbType.Text:
                    t = typeof(string);
                    break;
                case SqlDbType.Time:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime); //?????
                    break;
                case SqlDbType.Timestamp:
                    t = typeof(byte[]); //?????
                    break;
                case SqlDbType.TinyInt:
                    t = (allowNull) ? typeof(byte?) : typeof(byte);
                    break;
                case SqlDbType.Udt:
                    t = typeof(byte[]); //?????
                    break;
                case SqlDbType.UniqueIdentifier:
                    t = typeof(Guid);
                    break;
                case SqlDbType.VarBinary:
                    t = typeof(byte[]);
                    break;
                case SqlDbType.VarChar:
                    t = typeof(string);
                    break;
                case SqlDbType.Variant:
                    t = typeof(object);
                    break;
                case SqlDbType.Xml:
                    t = typeof(string);
                    break;
                default:
                    throw new ArgumentException("Encountered unknown SqlDbType.");
            }
            return t;
        }
        #endregion

        #region get sql type
        public static SqlDbType GetSqlType(Type t)
        {
            if (t is null) { throw new ArgumentNullException("t", "Cannot resolve type 'null'"); }

            Type underlyingType;
            if (t.IsEnum)
            {
                underlyingType = t.GetUnderlyingEnumType();
            }
            else
            {
                underlyingType = t.EnsureUnderlyingType();
            }

            if (sqlTypeMap.ContainsKey(underlyingType))
            {
                return sqlTypeMap[underlyingType];
            }
            else
            {
                throw new ArgumentException($"Input type could not be resolved to a valid SqlDbType.  param value: {t}", "t");
            }
        }
        #endregion

        #region get sql db type from declaration
        public static SqlDbType? GetSqlDBTypeFromDeclaration(string sqlTypeDeclaration)
        {
            if (string.IsNullOrEmpty(sqlTypeDeclaration)) { return null; }
            int idx = sqlTypeDeclaration.IndexOf('(');
            if (idx > 0)
            {
                sqlTypeDeclaration = sqlTypeDeclaration.Substring(0, idx);
            }
            sqlTypeDeclaration = sqlTypeDeclaration.Replace(" ", string.Empty).ToLower();
            try
            {
                SqlDbType sqlT = (SqlDbType)Enum.Parse(typeof(SqlDbType), sqlTypeDeclaration, true);
                return sqlT;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region sql type allows precision and scale
        public static bool SqlTypeAllowsPrecisionAndScale(SqlDbType sqlDbType)
        {
            return sqlDbType == SqlDbType.Decimal;
        }
        #endregion

        #region parse precision and scale from sql type text
        public static void ParsePrecisionAndScaleFromSqlTypeText(string sqlTypeText, out int? precision, out int? scale)
        {
            precision = null;
            scale = null;

            SqlDbType? sqlT = GetSqlDBTypeFromDeclaration(sqlTypeText);

            if (sqlT is object && SqlTypeAllowsPrecisionAndScale(sqlT.Value))
            {
                sqlTypeText = sqlTypeText.Replace(" ", string.Empty);
                int openIdx = sqlTypeText.IndexOf('(');
                int closeIdx = sqlTypeText.IndexOf(')');
                string val = sqlTypeText.Substring(openIdx, (sqlTypeText.Length - closeIdx));
                string[] vals = val.Split(',');

                if (vals.Length == 2)
                {
                    if (int.TryParse(vals[0], out int p))
                    {
                        precision = p;
                    }
                    if (int.TryParse(vals[1], out int s))
                    {
                        scale = s;
                    }
                }
            }

        }
        #endregion

        #region sql db type allows length declaration
        public static bool SqlDbTypeAllowsLengthDeclaration(SqlDbType sqlDbType)
        {
            return sqlDbType == SqlDbType.VarChar
                   || sqlDbType == SqlDbType.NVarChar
                   || sqlDbType == SqlDbType.VarBinary
                   || sqlDbType == SqlDbType.Binary
                   || sqlDbType == SqlDbType.Char
                   || sqlDbType == SqlDbType.NChar;
        }
        #endregion

        #region parse length delcaration from sql type text
        public static int? ParseLengthDeclarationFromSqlTypeText(string sqlTypeText)
        {
            sqlTypeText = sqlTypeText.Replace(" ", string.Empty);
            int openIdx = sqlTypeText.IndexOf('(');
            int closeIdx = sqlTypeText.IndexOf(')');

            if (openIdx > 0 && closeIdx > 0)
            {
                string length = sqlTypeText.Substring(openIdx, (sqlTypeText.Length - closeIdx));
                if (length.ToLower() == "max")
                {
                    return -1;
                }
                else
                {
                    int l;
                    if (int.TryParse(length, out l))
                    {
                        return l;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }
        #endregion

        #region is compatible type
        public static bool IsCompatibleType(string sqlTypeDeclaration, Type assemblyType)
        {
            if (sqlTypeDeclaration is null)
            {
                throw new ArgumentNullException("sqlTypeDeclaration");
            }
            if (sqlTypeDeclaration == string.Empty)
            {
                return false;
            }
            if (!IsSqlTypeKnown(assemblyType))
            {
                throw new ArgumentException("The assembly type supplied is not a known type.", "assemblyType");
            }
            int idx = sqlTypeDeclaration.IndexOf('(');
            if (idx > 0)
            {
                sqlTypeDeclaration = sqlTypeDeclaration.Substring(0, idx);
            }
            sqlTypeDeclaration = sqlTypeDeclaration.Replace(" ", string.Empty).ToLower();
            try
            {
                SqlDbType sqlT = (SqlDbType)Enum.Parse(typeof(SqlDbType), sqlTypeDeclaration, true);
                return (GetAssemblyType(sqlT, false) == assemblyType.EnsureUnderlyingType());
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region is compatible type
        public static bool IsCompatibleType(SqlDbType sqlType, Type assemblyType)
        {
            if (!IsSqlTypeKnown(assemblyType))
            {
                throw new ArgumentException("The assembly type supplied is not a known type.", "assemblyType");
            }
            return GetAssemblyType(sqlType, false) == assemblyType.EnsureUnderlyingType();
        }
        #endregion

        #region is sql type known
        public static bool IsSqlTypeKnown(Type t)
        {
            if (t is null) { return false; }
            Type underlyingType;
            if (t.IsEnum)
            {
                underlyingType = t.GetUnderlyingEnumType();
            }
            else
            {
                underlyingType = t.EnsureUnderlyingType();
            }

            return sqlTypeMap.ContainsKey(underlyingType);
        }
        #endregion

        #region is known sql type delcaration
        public static bool IsKnownSqlTypeDeclaration(string sqlTypeDeclaration)
        {
            if (string.IsNullOrEmpty(sqlTypeDeclaration)) { return false; }
            int idx = sqlTypeDeclaration.IndexOf('(');
            if (idx > 0)
            {
                sqlTypeDeclaration = sqlTypeDeclaration.Substring(0, idx);
            }
            sqlTypeDeclaration = sqlTypeDeclaration.Replace(" ", string.Empty).ToLower();
            try
            {
                SqlDbType sqlT = (SqlDbType)Enum.Parse(typeof(SqlDbType), sqlTypeDeclaration, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
