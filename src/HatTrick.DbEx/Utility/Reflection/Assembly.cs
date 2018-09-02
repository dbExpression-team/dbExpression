using System;
using System.Runtime.InteropServices;

namespace HatTrick.DbEx.Utility.Reflection
{
    public static partial class ReflectionHelper
    {
        public static class Assembly
        {
            public static Guid GetGuid(System.Reflection.Assembly assembly)
            {
                object[] assemblyObjects = assembly.GetCustomAttributes(typeof(GuidAttribute), true);
                if (assemblyObjects.Length == 0)
                    return Guid.Empty;
                return new Guid(((GuidAttribute)assemblyObjects[0]).Value);
            }
        }
    }
}
