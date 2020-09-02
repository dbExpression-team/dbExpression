using System;

namespace HatTrick.DbEx.Sql
{
    public static class TypeExtensions
    { 
        public static bool IsNullableType(this Type t) => (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        public static Type EnsureUnderlyingType(this Type t) => t.IsNullableType() ? Nullable.GetUnderlyingType(t) : t;        
        public static Type GetUnderlyingEnumType(this Type t)
        {
            //ensure underlying to ensure we dont have a nullable..
            Type underlying = t.EnsureUnderlyingType();

            if (!underlying.IsEnum) { return null; }

            //return the integral base of this enum...
            return Enum.GetUnderlyingType(underlying);
        }
    }
}
