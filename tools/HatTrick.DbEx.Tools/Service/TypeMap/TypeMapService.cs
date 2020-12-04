using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HatTrick.DbEx.Tools.Service
{
    public class TypeMapService
    {
        #region is nullable type
        //TODO: what will happen here when Ms rolls out the new nullable reference types ???
        public bool IsNullableType(Type t)
        {
            return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        #endregion

        #region ensure nullable underlying type
        public Type EnsureNullableUnderlyingType(Type t)
        {
            return this.IsNullableType(t) ? Nullable.GetUnderlyingType(t) : t;
        }
        #endregion

        #region get enum underlying type
        public Type GetEnumUnderlyingType(Type t)
        {
            //ensure underlying to ensure we dont have a nullable..
            Type underlying = this.EnsureNullableUnderlyingType(t);

            if (!underlying.IsEnum) { return null; }

            //return the integral base of this enum...
            return Enum.GetUnderlyingType(underlying);
        }
        #endregion

        #region get assembly type
        public Type GetAssemblyType(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt: return typeof(long);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.Udt:
                case SqlDbType.VarBinary: return typeof(byte[]);

                case SqlDbType.Bit: return typeof(bool);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar: return typeof(string);

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime: return typeof(DateTime);

                case SqlDbType.DateTimeOffset: return typeof(DateTimeOffset);

                case SqlDbType.Decimal: return typeof(decimal);

                case SqlDbType.Float:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney: return typeof(double);

                case SqlDbType.Int: return typeof(int);

                case SqlDbType.SmallInt: return typeof(short);

                case SqlDbType.TinyInt: return typeof(byte);

                case SqlDbType.UniqueIdentifier: return typeof(Guid);

                case SqlDbType.Real: return typeof(float);

                case SqlDbType.Time: return typeof(TimeSpan);

                case SqlDbType.Structured:
                case SqlDbType.Variant:
                case SqlDbType.Xml:
                default:
                    throw new NotImplementedException($"The sql database type {sqlDbType} is not compatible with dbExpression.");
            }
        }
        #endregion

        #region get assembly type
        public string GetAssemblyTypeShortName(SqlDbType sqlDbType, bool isNullable)
        {
            string format(string name, bool allowNull) => allowNull ? $"{name}?" : name;

            switch (sqlDbType)
            {
                case SqlDbType.BigInt: return format("long", isNullable);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.Udt:
                case SqlDbType.VarBinary: return format("byte[]", false);

                case SqlDbType.Bit: return format("bool", isNullable);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar: return format("string", false);

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime: return format(nameof(DateTime), isNullable);

                case SqlDbType.DateTimeOffset: return format(nameof(DateTimeOffset), isNullable);

                case SqlDbType.Decimal: return format("decimal", isNullable);

                case SqlDbType.Float:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney: return format("double", isNullable);

                case SqlDbType.Int: return format("int", isNullable);

                case SqlDbType.SmallInt: return format("short", isNullable);

                case SqlDbType.TinyInt: return format("byte", isNullable);

                case SqlDbType.UniqueIdentifier: return format(nameof(Guid), isNullable);

                case SqlDbType.Real: return format("float", isNullable);

                case SqlDbType.Time: return format(nameof(TimeSpan), isNullable);
                
                case SqlDbType.Structured:
                case SqlDbType.Variant:
                case SqlDbType.Xml:
                default:
                    throw new NotImplementedException($"The sql database type {sqlDbType} is not compatible with dbExpression.");
            }
        }

        public Type GetType(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt: return typeof(long);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.Udt:
                case SqlDbType.VarBinary: return typeof(byte[]);

                case SqlDbType.Bit: return typeof(bool);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar: return typeof(string);

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime: return typeof(DateTime);

                case SqlDbType.DateTimeOffset: return typeof(DateTimeOffset);

                case SqlDbType.Decimal: return typeof(decimal);

                case SqlDbType.Float: return typeof(double);

                case SqlDbType.Int: return typeof(int);

                case SqlDbType.Money:
                case SqlDbType.SmallMoney: return typeof(double);

                case SqlDbType.SmallInt: return typeof(short);

                case SqlDbType.TinyInt: return typeof(byte);

                case SqlDbType.UniqueIdentifier: return typeof(Guid);

                case SqlDbType.Real: return typeof(float);

                case SqlDbType.Time: return typeof(TimeSpan);

                case SqlDbType.Structured:
                case SqlDbType.Variant:
                case SqlDbType.Xml:
                default:
                    throw new NotImplementedException($"The sql database type {sqlDbType} is not compatible with dbExpression.");
            }
        }

        public Type GetNullableType(SqlDbType sqlDbType, bool isNullable)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt: return isNullable ? typeof(long?) : typeof(long);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.Udt:
                case SqlDbType.VarBinary: return typeof(byte[]);

                case SqlDbType.Bit: return isNullable ? typeof(bool?) : typeof(bool);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar: return typeof(string);

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime: return isNullable ? typeof(DateTime?) : typeof(DateTime);

                case SqlDbType.DateTimeOffset: return isNullable ? typeof(DateTimeOffset?) : typeof(DateTimeOffset);

                case SqlDbType.Decimal: return isNullable ? typeof(decimal?) : typeof(decimal);

                case SqlDbType.Float: return isNullable ? typeof(double?) : typeof(double);

                case SqlDbType.Int: return isNullable ? typeof(int?) : typeof(int);

                case SqlDbType.Money:
                case SqlDbType.SmallMoney: return isNullable ? typeof(double?) : typeof(double);

                case SqlDbType.SmallInt: return isNullable ? typeof(short?) : typeof(short);

                case SqlDbType.TinyInt: return isNullable ? typeof(byte?) : typeof(byte);

                case SqlDbType.UniqueIdentifier: return isNullable ? typeof(Guid?) : typeof(Guid);

                case SqlDbType.Real: return isNullable ? typeof(float?) : typeof(float);

                case SqlDbType.Time: return isNullable ? typeof(TimeSpan?) : typeof(TimeSpan);

                case SqlDbType.Structured:
                case SqlDbType.Variant:
                case SqlDbType.Xml:
                default:
                    throw new NotImplementedException($"The sql database type {sqlDbType} is not compatible with dbExpression.");
            }
        }

        public string GetAssemblyTypeName(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt: return nameof(Int64);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.Udt:
                case SqlDbType.VarBinary: return "ByteArray";
                
                case SqlDbType.Bit: return nameof(Boolean);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar: return nameof(String);

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime: return nameof(DateTime);

                case SqlDbType.DateTimeOffset: return nameof(DateTimeOffset);

                case SqlDbType.Decimal: return nameof(Decimal);

                case SqlDbType.Float: return nameof(Double);

                case SqlDbType.Int: return nameof(Int32);

                case SqlDbType.Money:
                case SqlDbType.SmallMoney: return nameof(Double);

                case SqlDbType.SmallInt: return nameof(Int16);

                case SqlDbType.TinyInt: return nameof(Byte);

                case SqlDbType.UniqueIdentifier: return nameof(Guid);
                
                case SqlDbType.Real: return nameof(Single);

                case SqlDbType.Time: return nameof(TimeSpan);

                case SqlDbType.Structured:
                case SqlDbType.Variant:
                case SqlDbType.Xml:
                default:
                    throw new NotImplementedException($"The sql database type {sqlDbType} is not compatible with dbExpression.");
            }
        }

        public string GetAliasTypeName(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt: return "long";

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.Udt:
                case SqlDbType.VarBinary: return "ByteArray";

                case SqlDbType.Bit: return "bool";

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar: return "string";

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime: return nameof(DateTime);

                case SqlDbType.DateTimeOffset: return nameof(DateTimeOffset);

                case SqlDbType.Decimal: return "decimal";

                case SqlDbType.Float: return "double";

                case SqlDbType.Int: return "int";

                case SqlDbType.Money:
                case SqlDbType.SmallMoney: return "double";

                case SqlDbType.SmallInt: return "short";

                case SqlDbType.TinyInt: return "byte";

                case SqlDbType.UniqueIdentifier: return nameof(Guid);

                case SqlDbType.Real: return "float";

                case SqlDbType.Time: return nameof(TimeSpan);

                case SqlDbType.Structured:
                case SqlDbType.Variant:
                case SqlDbType.Xml:
                default:
                    throw new NotImplementedException($"The sql database type {sqlDbType} is not compatible with dbExpression.");
            }
        }

        public string GetTypeNameFromAlias(string alias)
        {
            switch (alias)
            {
                case "long": return nameof(Int64);
                case "string": return nameof(String);
                case "bool": return nameof(Boolean);
                case "byte": return nameof(Byte);
                case "decimal": return nameof(Decimal);
                case "double": return nameof(Double);
                case "float": return nameof(Single);
                case "int": return nameof(Int32);
                case "short": return nameof(Int16);
                default:
                    return alias;
            }
        }

        public string GetNullableAliasFromTypeName(string typeName, bool isNullable)
        {
            string format(string name, bool allowNull) => allowNull ? $"{name}?" : name;

            switch (typeName)
            {
                case "string": return format("string", false); ;
                case "byte[]": return format("byte[]", false); ;
                case "object": return format("object", false); ;
                default:
                    return format(typeName, isNullable);
            }
        }
        #endregion
    }
}
