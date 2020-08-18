using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class NullableDateTimeOffsetAppender : NullableValueTypePartAppender<DateTimeOffset?>
    {
        public override void AppendPart(DateTimeOffset? expression, ISqlStatementBuilder builder, AssemblyContext context)
            =>  builder.Appender.Write(builder.Parameters.Add(expression is null ? expression : expression > Constants.MsSql.DateMinValue? expression : Constants.MsSql.DateMinValue).ParameterName);
    }
}
