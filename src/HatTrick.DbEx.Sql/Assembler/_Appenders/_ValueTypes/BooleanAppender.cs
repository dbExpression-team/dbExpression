using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class BooleanAppender : IAssemblyPartAppender<bool>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
           => AppendPart((bool)expression, builder, context);

        public void AppendPart(bool expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<bool>(expression).ParameterName);
        }
    }
}
