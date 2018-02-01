using System;
using System.Collections.Generic;
using System.Reflection;

namespace HTL.DbEx.Utility.Reflection
{
    //reflects nested class members; i.e. itemExpression="User.Address.City"....JRod
    public static partial class ReflectionHelper
    {
        public static class Expression
        {
            #region reflect item
            public static object ReflectItem(object sourceObject, string itemExpression)
            {
                if (sourceObject == null) { throw new ArgumentNullException(nameof(sourceObject)); }
                if (itemExpression == null) { throw new ArgumentNullException(nameof(itemExpression)); }

                //re-usable internal object o
                object o = sourceObject;

                bool itemExists = false;
                System.Collections.IDictionary idict;
                PropertyInfo p;

                int memberAccessorIdx = itemExpression.IndexOf('.');
                string thisExpression = (memberAccessorIdx > -1) ? itemExpression.Substring(0, memberAccessorIdx) : itemExpression;

                //if the caller is reflecting data from a dictionary, attempt dictionary lookup
                if ((idict = sourceObject as System.Collections.IDictionary) != null)
                {
                    if (idict.Contains(thisExpression))
                    {
                        itemExists = true;
                        o = idict[thisExpression];
                    }
                }
                else
                {
                    Type t = o.GetType();

                    p = t.GetProperty(thisExpression);

                    if (p != null)
                    {
                        itemExists = true;
                        o = p.GetValue(o, null);
                    }
                }

                if (itemExists && o != null && memberAccessorIdx > -1)
                {
                    //recursive call...
                    o = ReflectItem(o, itemExpression.Substring(++memberAccessorIdx, itemExpression.Length - memberAccessorIdx));
                }

                //if p ends up null, a null object was encountered before reaching the expression's final object... throw exception
                //TODO: Jerrod, reconsider this, may just want to return a null value... or, override with option of break vs. return null.
                if (!itemExists)
                {
                    string msg = string.Format("Property does not exist on source object.  Property_Name:  {0}, Bound_Object_Type:  {1}", itemExpression, sourceObject.GetType().ToString());
                    throw new NoPropertyExistsException(msg);
                }
                return o;
            }
            #endregion
        }
    }

    #region no property exists exception
    public class NoPropertyExistsException : Exception
    {
        public NoPropertyExistsException(string message)
            : base(message)
        {
        }
    }
    #endregion
}
