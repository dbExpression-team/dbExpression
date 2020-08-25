using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateTimeAppender : ValueTypePartAppender<DateTime>
    {
        public override void AppendPart(DateTime expression, ISqlStatementBuilder builder, AssemblyContext context)
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
