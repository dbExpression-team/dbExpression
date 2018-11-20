using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class StringAppender : IAssemblyPartAppender<string>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as string, builder, context);

        public void AppendPart(string expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            var @fixed = builder.FormatValueType<string>(expression);
            builder.Appender.Write(builder.Parameters.Add(@fixed, @fixed.Length).ParameterName);
        }
    }
}
