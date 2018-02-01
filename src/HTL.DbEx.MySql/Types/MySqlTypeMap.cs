using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.DbEx.Utility;
using MySql.Data.MySqlClient;

namespace HTL.DbEx.MySql.Types
{
    public class MySqlTypeMap
    {
        #region internals
        private static object _sqlTypeDictLock = new object();
        private static Dictionary<Type, MySqlDbType> _sqlTypeDict;
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

            Dictionary<Type, MySqlDbType> typeDict = MySqlTypeMap.GetSqlTypeDictionary();
            return typeDict.ContainsKey(underlyingType);
        }
        #endregion

        #region get sql type
        public static MySqlDbType GetSqlType(Type t)
        {
            if (t == null) { throw new ArgumentNullException("t", "Cannot resolve type 'null'"); }
            Dictionary<Type, MySqlDbType> typeDict = MySqlTypeMap.GetSqlTypeDictionary();

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
                throw new ArgumentException("Input type could not be resolved to a valid MyMySqlDbType.  param value: " + t.ToString(), "t");
            }
        }
        #endregion

        #region is known sql type delcaration
        public static bool IsKnownSqlTypeDeclaration(string sqlTypeDeclaration)
        {
            //try known types first...
            KnownMySqlDataType knownType;
            bool isKnown = Enum.TryParse<KnownMySqlDataType>(sqlTypeDeclaration, true, out knownType);
            if (!isKnown)
            {
                MySqlDbType mySqlType;
                isKnown = Enum.TryParse<MySqlDbType>(sqlTypeDeclaration, true, out mySqlType);
            }

            return isKnown;
        }
        #endregion

        #region sql type allows precision and scale
        public static bool SqlTypeAllowsPrecisionAndScale(MySqlDbType type)
        {
            return type == MySqlDbType.Decimal;
        }
        #endregion

        #region get assembly type
        public static Type GetAssemblyType(MySqlDbType dbType, bool allowNull)
        {
            Type t = null;
            switch (dbType)
            {
                case MySqlDbType.Decimal:
                    t = (allowNull) ? typeof(decimal?) : typeof(decimal);
                    break;
                case MySqlDbType.Byte:
                    t = (allowNull) ? typeof(sbyte?) : typeof(sbyte);
                    break;
                case MySqlDbType.Int16:
                    t = (allowNull) ? typeof(Int16?) : typeof(Int16);
                    break;
                case MySqlDbType.Int24:
                    t = (allowNull) ? typeof(Int32?) : typeof(Int32);
                    break;
                case MySqlDbType.Int32:
                    t = (allowNull) ? typeof(Int32?) : typeof(Int32);
                    break;
                case MySqlDbType.Int64:
                    t = (allowNull) ? typeof(Int64?) : typeof(Int64);
                    break;
                case MySqlDbType.Float:
                    t = (allowNull) ? typeof(Single?) : typeof(Single);
                    break;
                case MySqlDbType.Double:
                    t = (allowNull) ? typeof(double?) : typeof(double);
                    break;
                case MySqlDbType.Timestamp:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case MySqlDbType.Date:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case MySqlDbType.Time:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case MySqlDbType.DateTime:
                    t = (allowNull) ? typeof(DateTime?) : typeof(DateTime);
                    break;
                case MySqlDbType.Year:
                    t = (allowNull) ? typeof(Int16?) : typeof(Int16);
                    break;
                case MySqlDbType.Newdate:
                    //TODO: JRod, ???
                    break;
                case MySqlDbType.VarString:
                    t = typeof(string);
                    break;
                case MySqlDbType.Bit:
                    t = (allowNull) ? typeof(bool?) : typeof(bool);
                    break;
                case MySqlDbType.JSON:
                    t = typeof(string);
                    break;
                case MySqlDbType.NewDecimal:
                    t = (allowNull) ? typeof(decimal?) : typeof(decimal);
                    break;
                case MySqlDbType.Enum:
                    t = (allowNull) ? typeof(int?) : typeof(int);
                    break;
                case MySqlDbType.Set:
                    //TODO: JRod, ???
                    break;
                case MySqlDbType.TinyBlob:
                    t = typeof(byte[]);
                    break;
                case MySqlDbType.MediumBlob:
                    t = typeof(byte[]);
                    break;
                case MySqlDbType.LongBlob:
                    t = typeof(byte[]);
                    break;
                case MySqlDbType.Blob:
                    t = typeof(byte[]);
                    break;
                case MySqlDbType.VarChar:
                    t = typeof(string);
                    break;
                case MySqlDbType.String:
                    t = typeof(string);
                    break;
                case MySqlDbType.Geometry:
                    //TODO: JRod, ???
                    break;
                case MySqlDbType.UByte:
                    t = (allowNull) ? typeof(byte?) : typeof(byte);
                    break;
                case MySqlDbType.UInt16:
                    t = (allowNull) ? typeof(UInt16?) : typeof(UInt16);
                    break;
                case MySqlDbType.UInt24:
                    t = (allowNull) ? typeof(Int32?) : typeof(UInt32);
                    break;
                case MySqlDbType.UInt32:
                    t = (allowNull) ? typeof(Int32?) : typeof(UInt32);
                    break;
                case MySqlDbType.UInt64:
                    t = (allowNull) ? typeof(Int64?) : typeof(UInt64);
                    break;
                case MySqlDbType.Binary:
                    t = typeof(byte[]);
                    break;
                case MySqlDbType.VarBinary:
                    t = typeof(byte[]);
                    break;
                case MySqlDbType.TinyText:
                    t = typeof(string);
                    break;
                case MySqlDbType.MediumText:
                    t = typeof(string);
                    break;
                case MySqlDbType.LongText:
                    t = typeof(string);
                    break;
                case MySqlDbType.Text:
                    t = typeof(string);
                    break;
                case MySqlDbType.Guid:
                    t = (allowNull) ? typeof(Guid?) : typeof(Guid);
                    break;
                default:
                    throw new ArgumentException($"Encountered unknown MyMySqlDbType : {dbType}");
            }
            return t;
        }
        #endregion

        #region get sql db type from declaration
        public static MySqlDbType? GetSqlDBTypeFromDeclaration(string sqlTypeDeclaration)
        {
            MySqlDbType type;
            KnownMySqlDataType knownType;
            if (Enum.TryParse<MySqlDbType>(sqlTypeDeclaration, true, out type))
            {
                return type;
            }
            else if (Enum.TryParse<KnownMySqlDataType>(sqlTypeDeclaration, true, out knownType))
            {
                switch (knownType)
                {
                    case KnownMySqlDataType.@int:
                        return MySqlDbType.Int32;
                    case KnownMySqlDataType.varchar:
                        return MySqlDbType.VarChar;
                    case KnownMySqlDataType.datetime:
                        return MySqlDbType.DateTime;
                    case KnownMySqlDataType.@float:
                        return MySqlDbType.Float;
                    case KnownMySqlDataType.@decimal:
                        return MySqlDbType.Decimal;
                    case KnownMySqlDataType.date:
                        return MySqlDbType.Date;
                    case KnownMySqlDataType.longtext:
                        return MySqlDbType.LongText;
                    case KnownMySqlDataType.text:
                        return MySqlDbType.Text;
                    case KnownMySqlDataType.longblob:
                        return MySqlDbType.LongBlob;
                    case KnownMySqlDataType.blob:
                        return MySqlDbType.Blob;
                    case KnownMySqlDataType.bigint:
                        return MySqlDbType.Int64;
                    case KnownMySqlDataType.@char:
                        return MySqlDbType.VarChar;
                    case KnownMySqlDataType.mediumtext:
                        return MySqlDbType.MediumText;
                    default:
                        throw new InvalidOperationException("encounter un-expected known my sql type: " + knownType);
                }
            }

            return null;
        }
        #endregion

        #region get unsigned variant
        public static MySqlDbType GetUnsignedVariant(MySqlDbType type)
        {
            switch (type)
            {
                case MySqlDbType.Byte:
                    return MySqlDbType.UByte;
                case MySqlDbType.Int16:
                    return MySqlDbType.UInt16;
                case MySqlDbType.Int24:
                    return MySqlDbType.UInt24;
                case MySqlDbType.Int32:
                    return MySqlDbType.UInt32;
                case MySqlDbType.Int64:
                    return MySqlDbType.UInt64;
                default:
                    throw new InvalidOperationException("encounterd un-expected my sql db type: " + type);
            }
        }
        #endregion

        #region get sql type dictionary
        private static Dictionary<Type, MySqlDbType> GetSqlTypeDictionary()
        {
            lock (_sqlTypeDictLock)
            {
                if (_sqlTypeDict == null)
                {
                    _sqlTypeDict = new Dictionary<Type, MySqlDbType>();

                    _sqlTypeDict.Add(typeof(string), MySqlDbType.VarChar); //TODO: JRod, how varchar/nvarchar (sqlserver isnt picky...sqlce is ?)
                    _sqlTypeDict.Add(typeof(int), MySqlDbType.Int32);
                    _sqlTypeDict.Add(typeof(decimal), MySqlDbType.Decimal);
                    _sqlTypeDict.Add(typeof(DateTime), MySqlDbType.DateTime);
                    _sqlTypeDict.Add(typeof(bool), MySqlDbType.Bit);
                    _sqlTypeDict.Add(typeof(byte), MySqlDbType.UByte);
                    _sqlTypeDict.Add(typeof(long), MySqlDbType.Int64);
                    _sqlTypeDict.Add(typeof(object), MySqlDbType.Binary);
                    _sqlTypeDict.Add(typeof(double), MySqlDbType.Double);
                    _sqlTypeDict.Add(typeof(Single), MySqlDbType.Float);
                    _sqlTypeDict.Add(typeof(short), MySqlDbType.Int16);
                    _sqlTypeDict.Add(typeof(Guid), MySqlDbType.Guid);
                    _sqlTypeDict.Add(typeof(byte[]), MySqlDbType.VarBinary);
                    _sqlTypeDict.Add(typeof(ushort), MySqlDbType.UInt16);
                    _sqlTypeDict.Add(typeof(sbyte), MySqlDbType.Byte);
                    _sqlTypeDict.Add(typeof(uint), MySqlDbType.UInt64);
                    _sqlTypeDict.Add(typeof(TimeSpan), MySqlDbType.Time);

                    _sqlTypeDict.Add(typeof(int?), MySqlDbType.Int32);
                    _sqlTypeDict.Add(typeof(bool?), MySqlDbType.Bit);
                    _sqlTypeDict.Add(typeof(DateTime?), MySqlDbType.DateTime);
                    _sqlTypeDict.Add(typeof(decimal?), MySqlDbType.Decimal);
                    _sqlTypeDict.Add(typeof(long?), MySqlDbType.Int64);
                    _sqlTypeDict.Add(typeof(ulong?), MySqlDbType.UInt64);
                    _sqlTypeDict.Add(typeof(double?), MySqlDbType.Double);
                    _sqlTypeDict.Add(typeof(Single?), MySqlDbType.Float);
                    _sqlTypeDict.Add(typeof(short?), MySqlDbType.Int16);
                    _sqlTypeDict.Add(typeof(ushort?), MySqlDbType.UInt16);
                    _sqlTypeDict.Add(typeof(byte?), MySqlDbType.UByte);
                    _sqlTypeDict.Add(typeof(sbyte?), MySqlDbType.Byte);
                    _sqlTypeDict.Add(typeof(uint?), MySqlDbType.UInt32);
                }
            }
            return _sqlTypeDict;
        }
        #endregion
    }

    #region known mysql data types
    public enum KnownMySqlDataType
    {
        @int,
        varchar,
        datetime,
        @float,
        @decimal,
        date,
        longtext,
        text,
        longblob,
        blob,
        bigint,
        @char,
        mediumtext
    }
    #endregion
}
