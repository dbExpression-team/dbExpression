using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class StringAppender : IAssemblyPartAppender<string>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as string, builder, context);

        public void AppendPart(string expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var @fixed = string.IsNullOrWhiteSpace(expression) ? null : builder.FormatValueType<string>(expression);
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(@fixed, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<string>(@fixed).ParameterName);
        }
    }
}
