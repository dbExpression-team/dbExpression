using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DateTimeAppender : IAssemblyPartAppender<DateTime>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((DateTime)expression, builder, context);

        public void AppendPart(DateTime expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression != DateTime.MinValue ? expression : (DateTime?)null, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<DateTime>(expression != DateTime.MinValue ? expression : (DateTime?)null).ParameterName);
        }
    }
}
