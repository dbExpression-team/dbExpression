using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace HTL.DbEx.ObjectMap.Assembly
{
    public class AssemblyEntity : Entity
    {
        #region internals
        private Type _type;
        private object[] _customAttributes;
        #endregion

        #region interface
        public Type AssemblyType
        {   get
            {
                return _type;
            }
        }
        #endregion

        #region constructors
        public AssemblyEntity(Type t)
        {
            _type = t;
            _customAttributes = t.GetCustomAttributes(true);
            this.ExtractEntity();
        }
        #endregion

        #region methods
        private void ExtractEntity()
        {
            base.Name = _type.Name;

            if (this.HasAttribute(typeof(GenIgnoreAttribute))) { this.IsIgnored = true; }
            //Get properties
            PropertyInfo[] props = _type.GetProperties();

            //Build Fields...
            Type t = null;
            foreach (PropertyInfo prop in props)
            {
                t = prop.PropertyType;
                AssemblyField af = new AssemblyField(prop);
                base.AddField(af);
            }
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
