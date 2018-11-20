using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DateTimeAppender : IAssemblyPartAppender<DateTime>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart((DateTime)expression, builder, context);

        public void AppendPart(DateTime expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(builder.Parameters.Add(expression).ParameterName);
        }
    }
}
