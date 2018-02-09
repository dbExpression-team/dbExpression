using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HTL.DbEx.Reflection
{
    public static partial class ReflectionHelper
    {
        public static class Class
        {
            #region resolve property values
            public static Dictionary<string, object> ResolvePropertyValues(object obj)
            {
                if (obj == null) { return null; }

                var propCache = new Dictionary<string, object>();

                PropertyInfo[] pi = obj.GetType().GetProperties();
                string propName;
                object value;
                foreach (var p in pi)
                {
                    propName = p.Name;
                    value = p.GetValue(obj, null);
                    if (value != null)
                    {
                        Type t = value.GetType();
                        if (t.IsClass && (t != typeof(byte[]) && (t != typeof(string))))
                        {
                            value = ResolvePropertyValues(value);

                        }
                    }
                    propCache.Add(propName, value);
                }
                return propCache;
            }
            #endregion

            #region resolve field values
            public static Dictionary<string, object> ResolveFieldValues(object obj)
            {
                if (obj == null) { return null; }

                var fieldCache = new Dictionary<string, object>();

                var fi = obj.GetType().GetFields();
                string fieldName;
                object value;
                foreach (var f in fi)
                {
                    fieldName = f.Name;
                    value = f.GetValue(obj);
                    if (value != null)
                    {
                        Type t = value.GetType();
                        if (t.IsClass && (t != typeof(byte[]) && (t != typeof(string))))
                        {
                            value = ResolvePropertyValues(value);
                        }
                    }
                    fieldCache.Add(fieldName, value);
                }
                return fieldCache;
            }
            #endregion
        }
    }
}
