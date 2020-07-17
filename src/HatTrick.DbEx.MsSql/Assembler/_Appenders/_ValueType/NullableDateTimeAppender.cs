using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class NullableDateTimeAppender : NullableValueTypePartAppender<DateTime?>
    {
        public override void AppendPart(DateTime? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field is null)
                builder.Appender.Write(builder.Parameters.Add(expression is null ? expression : expression > Constants.MsSql.DateMinValue ? expression : Constants.MsSql.DateMinValue, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<DateTime?>(expression is null ? expression : expression > Constants.MsSql.DateMinValue ? expression : Constants.MsSql.DateMinValue).ParameterName);
        }
    }
}
