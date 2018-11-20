using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class BooleanAppender : IAssemblyPartAppender<bool>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
           => AppendPart((bool)expression, builder, context);

        public void AppendPart(bool expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(expression).ParameterName);
        }
    }
}
