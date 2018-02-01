using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace HTL.DbEx.ObjectMap.Assembly
{
    public class AssemblyField : Field
    {
        #region internals
        private PropertyInfo _propertyInfo;
        private object[] _customAttributes;
        #endregion

        #region interface
        public PropertyInfo PropertyInfo
        {
            get
            {
                return _propertyInfo;
            }
        }
        #endregion

        #region constructors
        public AssemblyField(PropertyInfo propInfo)
        {
            _propertyInfo = propInfo;
            _customAttributes = _propertyInfo.GetCustomAttributes(true);

            //Extract base interface...
            this.ExtractField();
        }
        #endregion

        #region methods
        private void ExtractField()
        {
            base.Name = _propertyInfo.Name;
            base.AssemblyType = _propertyInfo.PropertyType;
            if (this.HasAttribute(typeof(GenIgnoreAttribute))) { this.IsIgnored = true; }
        }

        public bool HasAttribute(Type attributeType)
        {
            foreach (var att in _customAttributes)
            {
                if (attributeType.IsInstanceOfType(att))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasAttribute(Type attributeType, out object foundAttribute)
        {
            foreach (var att in _customAttributes)
            {
                if (attributeType.IsInstanceOfType(att))
                {
                    foundAttribute = att;
                    return true;
                }
            }
            foundAttribute = null;
            return false;
        }

        public bool HasAttributes(Type attributeType, out List<object> foundAttributeList)
        {
            bool found = false;
            foundAttributeList = new List<object>();

            foreach (var att in _customAttributes)
            {
                if (attributeType.IsInstanceOfType(att))
                {
                    found = true;
                    foundAttributeList.Add(att);
                }
            }
            return found;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
