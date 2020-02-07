using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class NullableDateTimeAppender : IAssemblyPartAppender<DateTime?>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart((DateTime?)expression, builder, context);

        public void AppendPart(DateTime? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(expression, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<DateTime?>(expression).ParameterName);
        }
    }
}
