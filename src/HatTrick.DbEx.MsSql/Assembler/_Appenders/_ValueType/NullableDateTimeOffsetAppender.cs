using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class NullableDateTimeOffsetAppender : NullableValueTypePartAppender<DateTimeOffset?>
    {
        public override void AppendPart(DateTimeOffset? expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context?.Field is null)
                builder.Appender.Write(builder.Parameters.Add(expression is null ? expression : expression > Constants.MsSql.DateMinValue ? expression : Constants.MsSql.DateMinValue, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<DateTimeOffset?>(expression is null ? expression : expression > Constants.MsSql.DateMinValue ? expression : Constants.MsSql.DateMinValue).ParameterName);
        }
    }
}
