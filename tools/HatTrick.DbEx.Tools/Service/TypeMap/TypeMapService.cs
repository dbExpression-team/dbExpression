using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HatTrick.DbEx.Tools.Service
{
    public class TypeMapService
    {
        #region is nullable type
        //TODO: JRod, what will happen here when Ms rolls out the new nullable reference types ???
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
            Type t = null;
            switch (sqlDbType)
            {
                case SqlDbType.BigInt:
                    t = typeof(long);
                    break;
                case SqlDbType.Binary:
                    t = typeof(byte[]);
                    break;
                case SqlDbType.Bit:
                    t = typeof(bool);
                    break;
                case SqlDbType.Char:
                    t = typeof(char);
                    break;
                case SqlDbType.Date:
                    t = typeof(DateTime);
                    break;
                case SqlDbType.DateTime:
                    t = typeof(DateTime);
                    break;
                case SqlDbType.DateTime2:
                    t = typeof(DateTime);
                    break;
                case SqlDbType.DateTimeOffset:
                    t = typeof(DateTimeOffset);
                    break;
                case SqlDbType.Decimal:
                    t = typeof(decimal);
                    break;
                case SqlDbType.Float:
                    t = typeof(double);
                    break;
                case SqlDbType.Image:
                    t = typeof(byte[]);
                    break;
                case SqlDbType.Int:
                    t = typeof(int);
                    break;
                case SqlDbType.Money:
                    t = typeof(decimal);
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
                    t = typeof(Single);
                    break;
                case SqlDbType.SmallDateTime:
                    t = typeof(DateTime);
                    break;
                case SqlDbType.SmallInt:
                    t = typeof(Int16);
                    break;
                case SqlDbType.SmallMoney:
                    t = typeof(decimal);
                    break;
                case SqlDbType.Structured:
                    t = typeof(object);
                    break;
                case SqlDbType.Text:
                    t = typeof(string);
                    break;
                case SqlDbType.Time:
                    t = typeof(TimeSpan);
                    break;
                case SqlDbType.Timestamp:
                    t = typeof(byte[]);
                    break;
                case SqlDbType.TinyInt:
                    t = typeof(byte);
                    break;
                case SqlDbType.Udt:
                    t = typeof(object);
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
                    t = typeof(object);
                    break;
                default:
                    t = typeof(object);
                    break;
            }

            return t;
        }
        #endregion

        #region get assembly type
        public string GetAssemblyTypeShortName(SqlDbType sqlDbType, bool isNullable)
        {
            string nm = null;
            switch (sqlDbType)
            {
                case SqlDbType.BigInt:
                    nm = isNullable ? "long?" : "long";
                    break;
                case SqlDbType.Binary:
                    nm = "byte[]";
                    break;
                case SqlDbType.Bit:
                    nm = isNullable ? "bool?" : "bool";
                    break;
                case SqlDbType.Char:
                    //nm = isNullable ? "char?" : "char";
                    nm = "string";
                    break;
                case SqlDbType.Date:
                    nm = isNullable ? "DateTime?" : "DateTime";
                    break;
                case SqlDbType.DateTime:
                    nm = isNullable ? "DateTime?" : "DateTime";
                    break;
                case SqlDbType.DateTime2:
                    nm = isNullable ? "DateTime?" : "DateTime";
                    break;
                case SqlDbType.DateTimeOffset:
                    nm = isNullable ? "DateTimeOffset?" : "DateTimeOffset";
                    break;
                case SqlDbType.Decimal:
                    nm = isNullable ? "decimal?" : "decimal";
                    break;
                case SqlDbType.Float:
                    nm = isNullable ? "double?" : "double";
                    break;
                case SqlDbType.Image:
                    nm = "byte[]";
                    break;
                case SqlDbType.Int:
                    nm = isNullable ? "int?" : "int";
                    break;
                case SqlDbType.Money:
                    nm = isNullable ? "decimal?" : "decimal";
                    break;
                case SqlDbType.NChar:
                    nm = "string";
                    break;
                case SqlDbType.NText:
                    nm = "string";
                    break;
                case SqlDbType.NVarChar:
                    nm = "string";
                    break;
                case SqlDbType.Real:
                    nm = isNullable ? "Single?" : "Single";
                    break;
                case SqlDbType.SmallDateTime:
                    nm = isNullable ? "DateTime?" : "DateTime";
                    break;
                case SqlDbType.SmallInt:
                    nm = isNullable ? "Int16?" : "Int16";
                    break;
                case SqlDbType.SmallMoney:
                    nm = isNullable ? "decimal?" : "decimal";
                    break;
                case SqlDbType.Structured:
                    nm = "object";
                    break;
                case SqlDbType.Text:
                    nm = "string";
                    break;
                case SqlDbType.Time:
                    nm = isNullable ? "Timespan?" : "TimeSpan";
                    break;
                case SqlDbType.Timestamp:
                    nm = "byte[]";
                    break;
                case SqlDbType.TinyInt:
                    nm = isNullable ? "byte?" : "byte";
                    break;
                case SqlDbType.Udt:
                    nm = "object";
                    break;
                case SqlDbType.UniqueIdentifier:
                    nm = isNullable ? "Guid?" : "Guid";
                    break;
                case SqlDbType.VarBinary:
                    nm = "byte[]";
                    break;
                case SqlDbType.VarChar:
                    nm = "string";
                    break;
                case SqlDbType.Variant:
                    nm = "object";
                    break;
                case SqlDbType.Xml:
                    nm = "object";
                    break;
                default:
                    nm = "object";
                    break;
            }

            return nm;
        }
        #endregion

        #region resolve field expression name
        public string GetFieldExpressionTypeName(SqlDbType sqlDbType, bool isNullable)
        {
            string nm = null;
            switch (sqlDbType)
            {
                case SqlDbType.BigInt:
                    nm = isNullable ? "NullableInt64FieldExpression?" : "Int64FieldExpression";
                    break;
                case SqlDbType.Binary:
                    nm = "ByteArrayFieldExpression";
                    break;
                case SqlDbType.Bit:
                    nm = isNullable ? "NullableBooleanFieldExpression" : "BooleanFieldExpression";
                    break;
                case SqlDbType.Char:
                    nm = "StringFieldExpression";
                    break;
                case SqlDbType.Date:
                    nm = isNullable ? "NullableDateTimeFieldExpression" : "DateTimeFieldExpression";
                    break;
                case SqlDbType.DateTime:
                    nm = isNullable ? "NullableDateTimeFieldExpression" : "DateTimeFieldExpression";
                    break;
                case SqlDbType.DateTime2:
                    nm = isNullable ? "NullableDateTimeFieldExpression" : "DateTimeFieldExpression";
                    break;
                case SqlDbType.DateTimeOffset:
                    //nm = isNullable ? "DateTimeOffset?" : "DateTimeOffset";
                    throw new NotImplementedException();
                case SqlDbType.Decimal:
                    nm = isNullable ? "NullableDecimalFieldExpression" : "DecimalFieldExpression";
                    break;
                case SqlDbType.Float:
                    nm = isNullable ? "NullableDoubleFieldExpression" : "DoubleFieldExpression";
                    break;
                case SqlDbType.Image:
                    nm = "ByteArrayFieldExpression";
                    break;
                case SqlDbType.Int:
                    nm = isNullable ? "NullableInt32FieldExpression" : "Int32FieldExpression";
                    break;
                case SqlDbType.Money:
                    nm = isNullable ? "NullableDecimalFieldExpression" : "DecimalFieldExpression";
                    break;
                case SqlDbType.NChar:
                    nm = "StringFieldExpression";
                    break;
                case SqlDbType.NText:
                    nm = "StringFieldExpression";
                    break;
                case SqlDbType.NVarChar:
                    nm = "StringFieldExpression";
                    break;
                case SqlDbType.Real:
                    //nm = isNullable ? "Single?" : "Single";
                    throw new NotImplementedException();
                case SqlDbType.SmallDateTime:
                    nm = isNullable ? "NullableDateTimeFieldExpression" : "DateTimeFieldExpression";
                    break;
                case SqlDbType.SmallInt:
                    nm = isNullable ? "NullableInt16FieldExpression" : "Int16FieldExpression";
                    break;
                case SqlDbType.SmallMoney:
                    nm = isNullable ? "NullableDecimalFieldExpression" : "DecimalFieldExpression";
                    break;
                case SqlDbType.Structured:
                    //nm = "object";
                    throw new NotImplementedException();
                case SqlDbType.Text:
                    nm = "StringFieldExpression";
                    break;
                case SqlDbType.Time:
                    //nm = isNullable ? "Timespan?" : "TimeSpan";
                    throw new NotImplementedException();
                case SqlDbType.Timestamp:
                    //nm = "byte[]";
                    throw new NotImplementedException();
                case SqlDbType.TinyInt:
                    nm = isNullable ? "NullableByteFieldExpression" : "ByteFieldExpression";
                    break;
                case SqlDbType.Udt:
                    //nm = "object";
                    throw new NotImplementedException();
                case SqlDbType.UniqueIdentifier:
                    nm = isNullable ? "NullableGuidFieldExpression" : "GuidFieldExpression";
                    break;
                case SqlDbType.VarBinary:
                    nm = "ByteArrayFieldExpression";
                    break;
                case SqlDbType.VarChar:
                    nm = "StringFieldExpression";
                    break;
                case SqlDbType.Variant:
                    //nm = "object";
                    throw new NotImplementedException();
                case SqlDbType.Xml:
                    //nm = "object";
                    throw new NotImplementedException();
                default:
                    //nm = "object";
                    throw new NotImplementedException();
            }

            return nm;
        }
        #endregion
    }
}
