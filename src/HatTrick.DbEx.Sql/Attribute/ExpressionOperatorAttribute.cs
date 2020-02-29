using System;

namespace HatTrick.DbEx.Sql.Attribute
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExpressionOperatorAttribute : System.Attribute
    {
        public string Operator { get; private set; }

        public ExpressionOperatorAttribute(string @operator)
        {
            Operator = @operator;
        }
    }
}
