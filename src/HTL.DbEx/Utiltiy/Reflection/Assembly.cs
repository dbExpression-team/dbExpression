using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HTL.DbEx.Utility.Reflection
{
    public static partial class ReflectionHelper
    {
        public static class Assembly
        {
            public static Guid GetGuid(System.Reflection.Assembly assembly)
            {
                object[] assemblyObjects = assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true);
                if (assemblyObjects.Length == 0) return Guid.Empty;
                return new Guid(((System.Runtime.InteropServices.GuidAttribute)assemblyObjects[0]).Value);
            }
        }
    }
}
