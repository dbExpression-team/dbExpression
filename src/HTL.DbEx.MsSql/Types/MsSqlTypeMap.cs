using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using HTL.DbEx.Utility;

namespace HTL.DbEx.MsSql.Types
{
    public static class MsSqlTypeMap
    {
        #region internals
        private static object _sqlTypeDictLock = new object();
        private static Dictionary<Type, SqlDbType> _sqlTypeDict;
        #endregion

        #region get sql type text
        public static string GetSqlTypeText(Type t, int? maxLength, int? precision, int? scale)
        {
            string sqlBase;
            if (MsSqlTypeMap.IsSqlTypeKnown(t))
            {
                sqlBase = MsSqlTypeMap.GetSqlType(t).ToString().ToLower();
                if (maxLength.HasValue)
                {
                    if (maxLength.Value == -1)
                    {
                        return sqlBase + "(max)";
                    }
                    else
                    {
                        return sqlBase + "(" + maxLength.Value.ToString() + ")";
                    }
                }
                else if (precision.HasValue)
                {
                    sqlBase = sqlBase + "(" + precision.Value.ToString();
                    if (scale.HasValue)
                    {
                        return sqlBase + "," + scale.Value.ToString() + ")";
                    }
                    else
                    {
                        return sqlBase + ",0)";
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
            if (t == null) { throw new ArgumentNullException("t", "Cannot resolve type 'null'"); }
            Dictionary<Type, SqlDbType> typeDict = GetSqlTypeDictionary();

            Type underlyingType;
            if (t.IsEnum)
            {
                underlyingType = TypeUtility.GetUnderlyingEnumType(t);
            }
            else
            {
                underlyingType = TypeUtility.EnsureUnderlyingType(t);
            }

            if (typeDict.ContainsKey(underlyingType))
            {
                return typeDict[underlyingType];
            }
            else
            {
                throw new ArgumentException("Input type could not be resolved to a valid SqlDbType.  param value: " + t.ToString(), "t");
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

            SqlDbType? sqlT = MsSqlTypeMap.GetSqlDBTypeFromDeclaration(sqlTypeText);

            if (sqlT != null && MsSqlTypeMap.SqlTypeAllowsPrecisionAndScale(sqlT.Value))
            {
                sqlTypeText = sqlTypeText.Replace(" ", string.Empty);
                int openIdx = sqlTypeText.IndexOf('(');
                int closeIdx = sqlTypeText.IndexOf(')');
                string val = sqlTypeText.Substring(openIdx, (sqlTypeText.Length - closeIdx));
                string[] vals = val.Split(',');

                if (vals.Length == 2)
                {
                    int p;
                    int s;
                    if (int.TryParse(vals[0], out p))
                    {
                        precision = p;
                    }
                    if (int.TryParse(vals[1], out s))
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
            else
            {
                return null;
            }
        }
        #endregion

        #region is compatible type
        public static bool IsCompatibleType(string sqlTypeDeclaration, Type assemblyType)
        {
            if (sqlTypeDeclaration == null)
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
                return (GetAssemblyType(sqlT, false) == TypeUtility.EnsureUnderlyingType(assemblyType));
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
            return (GetAssemblyType(sqlType, false) == TypeUtility.EnsureUnderlyingType(assemblyType));
        }
        #endregion

        #region is sql type known
        public static bool IsSqlTypeKnown(Type t)
        {
            if (t == null) { return false; }
            Type underlyingType;
            if (t.IsEnum)
            {
                underlyingType = TypeUtility.GetUnderlyingEnumType(t);
            }
            else
            {
                underlyingType = TypeUtility.EnsureUnderlyingType(t);
            }

            Dictionary<Type, SqlDbType> typeDict = MsSqlTypeMap.GetSqlTypeDictionary();
            return typeDict.ContainsKey(underlyingType);
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

        #region get sql type dictionary
        private static Dictionary<Type, SqlDbType> GetSqlTypeDictionary()
        {
            lock (_sqlTypeDictLock)
            {
                if (_sqlTypeDict == null)
                {
                    _sqlTypeDict = new Dictionary<Type, SqlDbType>();

                    _sqlTypeDict.Add(typeof(string), SqlDbType.VarChar); //TODO: JRod, how varchar/nvarchar (sqlserver isnt picky...sqlce is ?)
                    _sqlTypeDict.Add(typeof(int), SqlDbType.Int);
                    _sqlTypeDict.Add(typeof(decimal), SqlDbType.Decimal);
                    _sqlTypeDict.Add(typeof(DateTime), SqlDbType.DateTime);
                    _sqlTypeDict.Add(typeof(bool), SqlDbType.Bit);
                    _sqlTypeDict.Add(typeof(byte), SqlDbType.TinyInt);
                    _sqlTypeDict.Add(typeof(long), SqlDbType.BigInt);
                    _sqlTypeDict.Add(typeof(object), SqlDbType.Binary);
                    _sqlTypeDict.Add(typeof(double), SqlDbType.Float);
                    _sqlTypeDict.Add(typeof(Single), SqlDbType.Real);
                    _sqlTypeDict.Add(typeof(short), SqlDbType.SmallInt);
                    _sqlTypeDict.Add(typeof(Guid), SqlDbType.UniqueIdentifier);
                    _sqlTypeDict.Add(typeof(byte[]), SqlDbType.VarBinary);
                    _sqlTypeDict.Add(typeof(ushort), SqlDbType.SmallInt);
                    _sqlTypeDict.Add(typeof(sbyte), SqlDbType.TinyInt);
                    _sqlTypeDict.Add(typeof(uint), SqlDbType.Int);
                    _sqlTypeDict.Add(typeof(TimeSpan), SqlDbType.Time);

                    _sqlTypeDict.Add(typeof(int?), SqlDbType.Int);
                    _sqlTypeDict.Add(typeof(bool?), SqlDbType.Bit);
                    _sqlTypeDict.Add(typeof(DateTime?), SqlDbType.DateTime);
                    _sqlTypeDict.Add(typeof(decimal?), SqlDbType.Decimal);
                    _sqlTypeDict.Add(typeof(long?), SqlDbType.BigInt);
                    _sqlTypeDict.Add(typeof(ulong?), SqlDbType.BigInt);
                    _sqlTypeDict.Add(typeof(double?), SqlDbType.Float);
                    _sqlTypeDict.Add(typeof(Single?), SqlDbType.Real);
                    _sqlTypeDict.Add(typeof(short?), SqlDbType.SmallInt);
                    _sqlTypeDict.Add(typeof(ushort?), SqlDbType.SmallInt);
                    _sqlTypeDict.Add(typeof(byte?), SqlDbType.TinyInt);
                    _sqlTypeDict.Add(typeof(sbyte?), SqlDbType.TinyInt);
                    _sqlTypeDict.Add(typeof(uint?), SqlDbType.Int);
                }
            }
            return _sqlTypeDict;
        }
        #endregion
    }
}
