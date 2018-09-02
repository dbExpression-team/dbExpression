using System;

namespace HatTrick.DbEx.Utility.Reflection
{
    public class NoPropertyExistsException : Exception
    {
        public NoPropertyExistsException(string message)
            : base(message)
        {
        }
    }
}
