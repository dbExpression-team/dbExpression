using System;
using System.Collections;
using System.Reflection;

namespace HatTrick.DbEx.Utility.Reflection
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

                var itemExists = false;
                IDictionary idict;
                PropertyInfo p;

                int memberAccessorIdx = itemExpression.IndexOf('.');
                string thisExpression = (memberAccessorIdx > -1) ? itemExpression.Substring(0, memberAccessorIdx) : itemExpression;

                //if the caller is reflecting data from a dictionary, attempt dictionary lookup
                if ((idict = sourceObject as IDictionary) != null)
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
                    throw new NoPropertyExistsException($"Property does not exist on source object.  Property_Name: {itemExpression}, Bound_Object_Type:  {sourceObject.GetType()}");
                }
                return o;
            }
            #endregion
        }
    }
}
