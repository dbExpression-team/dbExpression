using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.ObjectMap
{
    public abstract class EnumerationItem
    {
        #region internals
        private object _value;
        private string _key;
        private string _friendlyName;
        private string _description;
        private Type _integralType;
        #endregion

        #region interface properties
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string FriendlyName
        {
            get { return _friendlyName; }
            set { _friendlyName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public Type AssemblyIntegralType
        {
            get { return _integralType; }
            set { _integralType = value; }
        }
        #endregion

        #region constructors
        #endregion

        #region methods
        public override string ToString()
        {
            return _value.ToString();
        }

        private object CastToIntegralType(object value)
        {
            if (_integralType == typeof(byte))
                return (byte)value;
            else if (_integralType == typeof(sbyte))
                return (sbyte)value;
            else if (_integralType == typeof(short))
                return (short)value;
            else if (_integralType == typeof(ushort))
                return (ushort)value;
            else if (_integralType == typeof(int))
                return (int)value;
            else if (_integralType == typeof(uint))
                return (uint)value;
            else if (_integralType == typeof(long))
                return (long)value;
            else if (_integralType == typeof(ulong))
                return (ulong)value;
            else
                return value;
        }
        #endregion
    }
}
