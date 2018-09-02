using System;

namespace HatTrick.DbEx.ObjectMap
{
    public abstract class EnumerationItem
    {
        #region interface properties
        public string Key { get; set; }

        public object Value { get; set; }

        public string FriendlyName { get; set; }

        public string Description { get; set; }

        public Type AssemblyIntegralType { get; set; }
        #endregion

        #region constructors
        #endregion

        #region methods
        public override string ToString() => Value.ToString();

        private object CastToIntegralType(object value)
        {
            if (AssemblyIntegralType == typeof(byte))
                return (byte)value;
            else if (AssemblyIntegralType == typeof(sbyte))
                return (sbyte)value;
            else if (AssemblyIntegralType == typeof(short))
                return (short)value;
            else if (AssemblyIntegralType == typeof(ushort))
                return (ushort)value;
            else if (AssemblyIntegralType == typeof(int))
                return (int)value;
            else if (AssemblyIntegralType == typeof(uint))
                return (uint)value;
            else if (AssemblyIntegralType == typeof(long))
                return (long)value;
            else if (AssemblyIntegralType == typeof(ulong))
                return (ulong)value;
            else
                return value;
        }
        #endregion
    }
}
