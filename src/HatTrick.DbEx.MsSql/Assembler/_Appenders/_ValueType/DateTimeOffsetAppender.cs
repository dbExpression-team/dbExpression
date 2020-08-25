using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateTimeOffsetAppender : ValueTypePartAppender<DateTimeOffset>
    {
        public override void AppendPart(DateTimeOffset expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.Field is object)
            {
                builder.Appender.Write(
                        builder.Parameters.Add(
                            expression > Constants.MsSql.DateMinValue ? expression : Constants.MsSql.DateMinValue,
                            context.Field,
                            builder.FindMetadata(context.Field)
                        )
                        .Parameter.ParameterName
                    );
            }
            else
            {
                builder.Appender.Write(builder.Parameters.Add(expression > Constants.MsSql.DateMinValue ? expression : Constants.MsSql.DateMinValue).ParameterName);
            }
        }
    }
}
