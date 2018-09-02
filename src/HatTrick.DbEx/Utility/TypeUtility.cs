using System;

namespace HatTrick.DbEx.Utility
{
    public static class TypeUtility
    {
        #region get assembly type text
        public static string GetAssemblyTypeText(Type t) => TypeUtility.IsNullableType(t) ? $"{TypeUtility.EnsureUnderlyingType(t).FullName}?" : t.FullName;
        #endregion

        #region get assembly type shorthand text
        public static string GetAssemblyTypeShorthandText(Type t) => ResolveAssemblyTypeShorthand(GetAssemblyTypeText(t));
        #endregion

        #region get assembly type from type text
        public static Type GetAssemblyTypeFromTypeText(string typeText)
        {
            Type t = null;

            string txt = (typeText.Contains(".")) ? TypeUtility.ResolveAssemblyTypeShorthand(typeText) : typeText;
            string knownShortHand = TypeUtility.ResolveAssemblyTypeFullName(txt);

            if (knownShortHand != null)
            {
                switch (txt)
                {
                    case "string":
                        t = typeof(string);
                        break; // System.String
                    case "int":
                        t = typeof(int);
                        break; // "System.Int32";
                    case "decimal":
                        t = typeof(decimal);
                        break; // "System.Decimal";
                    case "DateTime":
                        t = typeof(DateTime);
                        break; // "System.DateTime";
                    case "bool":
                        t = typeof(bool);
                        break; // "System.Boolean";
                    case "byte":
                        t = typeof(byte);
                        break; // "System.Byte";
                    case "long":
                        t = typeof(long);
                        break; // "System.Int64";
                    case "object":
                        t = typeof(object);
                        break; // "System.Object";
                    case "double":
                        t = typeof(double);
                        break; // "System.Double";
                    case "float":
                        t = typeof(float);
                        break; // "System.Single";
                    case "short":
                        t = typeof(short);
                        break; // "System.Int16";
                    case "Guid":
                        t = typeof(Guid);
                        break; // "System.Guid";
                    case "byte[]":
                        t = typeof(byte[]);
                        break; // "System.Byte[]";
                    case "ushort":
                        t = typeof(ushort);
                        break; // "System.UInt16";
                    case "sbyte":
                        t = typeof(sbyte);
                        break; // "System.SByte";
                    case "uint":
                        t = typeof(uint);
                        break; // "System.UInt32";
                    case "int?":
                        t = typeof(int?);
                        break; // "System.Int32?";
                    case "bool?":
                        t = typeof(bool?);
                        break; // "System.Boolean?";
                    case "DateTime?":
                        t = typeof(DateTime?);
                        break; // "System.DateTime?";
                    case "decimal?":
                        t = typeof(decimal?);
                        break; // "System.Decimal?";
                    case "long?":
                        t = typeof(long?);
                        break; // "System.Int64?";
                    case "ulong?":
                        t = typeof(ulong?);
                        break; // "System.UInt64?";
                    case "double?":
                        t = typeof(double?);
                        break; // "System.Double?";
                    case "float?":
                        t = typeof(float?);
                        break; // "System.Single?";
                    case "short?":
                        t = typeof(short?);
                        break; // "System.Int16?";
                    case "byte?":
                        t = typeof(byte?);
                        break; // "System.Byte?";
                    case "sbyte?":
                        t = typeof(sbyte?);
                        break; // "System.SByte?";
                    case "uint?":
                        t = typeof(uint?);
                        break; // "System.UInt32?";
                }
            }
            return t;
        }
        #endregion

        #region is nullable type
        public static bool IsNullableType(Type t) => (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        #endregion

        #region ensure underlying type
        public static Type EnsureUnderlyingType(Type t) => TypeUtility.IsNullableType(t) ? Nullable.GetUnderlyingType(t) : t;
        #endregion

        #region get underlying enum type
        public static Type GetUnderlyingEnumType(Type t)
        {
            //ensure underlying to ensure we dont have a nullable..
            Type underlying = TypeUtility.EnsureUnderlyingType(t);

            if (!underlying.IsEnum) { return null; }

            //return the integral base of this enum...
            return Enum.GetUnderlyingType(underlying);
        }
        #endregion

        #region is rangable type
        public static bool IsRangeableType(Type t)
        {
            Type underlying = TypeUtility.EnsureUnderlyingType(t);
            return
                (
                       underlying == typeof(decimal)
                    || underlying == typeof(DateTime)
                    || underlying == typeof(char)
                    || underlying == typeof(long)
                    || underlying == typeof(ulong)
                    || underlying == typeof(double)
                    || underlying == typeof(float)
                    || underlying == typeof(short)
                    || underlying == typeof(ushort)
                    || underlying == typeof(sbyte)
                    || underlying == typeof(byte)
                    || underlying == typeof(int)
                    || underlying == typeof(uint)
                );
        }
        #endregion

        #region is size constrictable type
        public static bool IsSizeConstrictableType(Type t)
        {   
            //HACK: JRod, any array, dictionary, collection, queue, etc could be constrictable... needs enhancement...
            Type underlying = TypeUtility.EnsureUnderlyingType(t);
            return (underlying == typeof(string) || underlying == typeof(byte[]));
        }
        #endregion

        #region is floating point type
        public static bool IsFloatingPointType(Type t)
        {
            Type underlying = TypeUtility.EnsureUnderlyingType(t);
            return (underlying == typeof(double) || underlying == typeof(float) || underlying == typeof(Single));
        }
        #endregion

        #region is decimal type
        public static bool IsDecimalType(Type t)
        {
            Type underlying = TypeUtility.EnsureUnderlyingType(t);
            return (underlying == typeof(decimal));
        }
        #endregion

        #region is integral type
        public static bool IsIntegralType(Type t)
        {
            Type underlying = TypeUtility.EnsureUnderlyingType(t);
            return
                (
                       underlying == typeof(char)
                    || underlying == typeof(long)
                    || underlying == typeof(ulong)
                    || underlying == typeof(short)
                    || underlying == typeof(ushort)
                    || underlying == typeof(sbyte)
                    || underlying == typeof(byte)
                    || underlying == typeof(int)
                    || underlying == typeof(uint)
                );
        }
        #endregion

        #region get underlying enum integral
        public static object GetUnderlyingEnumIntegral(Type t, object o)
        {
            if (!t.IsEnum) { return null; }
            Type underlying = Enum.GetUnderlyingType(t);

            if (underlying == typeof(char)) { return (char)o; } //HACK: JRod, cannot really be char ...
            if (underlying == typeof(long)) { return (long)o; }
            if (underlying == typeof(ulong)) { return (ulong)o; }
            if (underlying == typeof(short)) { return (short)o; }
            if (underlying == typeof(ushort)) { return (ushort)o; }
            if (underlying == typeof(sbyte)) { return (sbyte)o; }
            if (underlying == typeof(byte)) { return (byte)o; }
            if (underlying == typeof(int)) { return (int)o; }
            if (underlying == typeof(uint)) { return (uint)o; }

            return null;
        }
        #endregion

        #region is allowed nullable declaration
        public static bool IsAllowedNullableDeclaration(Type t)
        {
            Type underlying = TypeUtility.EnsureUnderlyingType(t);
            return
                (
                       underlying == typeof(int)
                    || underlying == typeof(DateTime)
                    || underlying == typeof(decimal)
                    || underlying == typeof(double)
                    || underlying == typeof(float)
                    || underlying == typeof(bool)
                    || underlying == typeof(long)
                    || underlying == typeof(ulong)
                    || underlying == typeof(short)
                    || underlying == typeof(ushort)
                    || underlying == typeof(sbyte)
                    || underlying == typeof(byte)
                    || underlying == typeof(uint)
                    || underlying == typeof(char)
                );
        }
        #endregion

        #region resolve assembly type full name
        public static string ResolveAssemblyTypeFullName(string shorthand)
        {
            switch (shorthand)
            {
                case "string":
                    return "System.String";
                case "String":
                    return "System.String";
                case "int":
                    return "System.Int32";
                case "decimal":
                    return "System.Decimal";
                case "DateTime":
                    return "System.DateTime";
                case "bool":
                    return "System.Boolean";
                case "byte":
                    return "System.Byte";
                case "long":
                    return "System.Int64";
                case "object":
                    return "System.Object";
                case "double":
                    return "System.Double";
                case "float":
                    return "System.Single";
                case "short":
                    return "System.Int16";
                case "Guid":
                    return "System.Guid";
                case "byte[]":
                    return "System.Byte[]";
                case "ushort":
                    return "System.UInt16";
                case "sbyte":
                    return "System.SByte";
                case "uint":
                    return "System.UInt32";
                case "int?":
                    return "System.Int32?";
                case "bool?":
                    return "System.Boolean?";
                case "DateTime?":
                    return "System.DateTime?";
                case "decimal?":
                    return "System.Decimal?";
                case "long?":
                    return "System.Int64?";
                case "ulong?":
                    return "System.UInt64?";
                case "double?":
                    return "System.Double?";
                case "float?":
                    return "System.Single?";
                case "short?":
                    return "System.Int16?";
                case "byte?":
                    return "System.Byte?";
                case "sbyte?":
                    return "System.SByte?";
                case "uint?":
                    return "System.UInt32?";
                default:
                    return null; //(TODO:  throw exception??? ? ?) JROD
            }
        }
        #endregion

        #region resolve assembly type shorthand
        public static string ResolveAssemblyTypeShorthand(string fullName)
        {
            switch (fullName)
            {
                case "System.String":
                    return "string";
                case "System.Int32":
                    return "int";
                case "System.Decimal":
                    return "decimal";
                case "System.DateTime":
                    return "DateTime";
                case "System.Boolean":
                    return "bool";
                case "System.Byte":
                    return "byte";
                case "System.Int64":
                    return "long";
                case "System.Object":
                    return "object";
                case "System.Double":
                    return "double";
                case "System.Single":
                    return "float";
                case "System.Int16":
                    return "short";
                case "System.Guid":
                    return "Guid";
                case "System.Byte[]":
                    return "byte[]";
                case "System.UInt16":
                    return "ushort";
                case "System.SByte":
                    return "sbyte";
                case "System.UInt32":
                    return "uint";
                case "System.Int32?":
                    return "int?";
                case "System.Boolean?":
                    return "bool?";
                case "System.DateTime?":
                    return "DateTime?";
                case "System.Decimal?":
                    return "decimal?";
                case "System.Int64?":
                    return "long?";
                case "System.UInt64?":
                    return "ulong?";
                case "System.Double?":
                    return "double?";
                case "System.Single?":
                    return "float?";
                case "System.Int16?":
                    return "short?";
                case "System.Byte?":
                    return "byte?";
                case "System.SByte?":
                    return "sbyte?";
                case "System.UInt32?":
                    return "uint?";
                default:
                    return null; // TODO: throw exception???? JROD

            }
        }
        #endregion
    }
}
