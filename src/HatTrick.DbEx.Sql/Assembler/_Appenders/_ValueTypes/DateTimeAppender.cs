using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DateTimeAppender : IAssemblyPartAppender<DateTime>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((DateTime)expression, builder, context);

        public void AppendPart(DateTime expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (context.CurrentField != null)
                builder.Appender.Write(builder.Parameters.Add(expression != DateTime.MinValue ? expression : (DateTime?)null, context.CurrentField.Metadata).ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<DateTime>(expression != DateTime.MinValue ? expression : (DateTime?)null).ParameterName);
        }
    }
}
