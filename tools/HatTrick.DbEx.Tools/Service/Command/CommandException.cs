using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Service
{
    public class CommandException : Exception
    {
        public CommandException(string message) : base(message)
        {
        }
    }
}
