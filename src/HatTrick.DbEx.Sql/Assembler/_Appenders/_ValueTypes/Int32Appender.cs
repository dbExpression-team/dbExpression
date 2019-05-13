using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int32Appender : IAssemblyPartAppender<int>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((int)expression, builder, context);
        public void AppendPart(int expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<int>(expression).ParameterName);
        }
    }
}
