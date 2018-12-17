using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int16Appender : IAssemblyPartAppender<short>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((short)expression, builder, context);

        public void AppendPart(short expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (context.CurrentField != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.CurrentField).ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<short>(expression).ParameterName);
        }
    }
}
