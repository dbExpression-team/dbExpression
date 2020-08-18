using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateTimeAppender : ValueTypePartAppender<DateTime>
    {
        public override void AppendPart(DateTime expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.Appender.Write(builder.Parameters.Add(expression > Constants.MsSql.DateMinValue ? expression : Constants.MsSql.DateMinValue, context.Field).Parameter.ParameterName);
    }
}
