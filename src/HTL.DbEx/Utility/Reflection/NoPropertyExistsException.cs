using System;

namespace HTL.DbEx.Utility.Reflection
{
    public class NoPropertyExistsException : Exception
    {
        public NoPropertyExistsException(string message)
            : base(message)
        {
        }
    }
}
