using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class BooleanAppender : IAssemblyPartAppender<bool>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
           => AppendPart((bool)expression, builder, context);

        public void AppendPart(bool expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (context.CurrentField != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.CurrentField.Metadata).ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<bool>(expression).ParameterName);
        }
    }
}
