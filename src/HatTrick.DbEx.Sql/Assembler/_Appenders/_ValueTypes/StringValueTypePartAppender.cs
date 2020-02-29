namespace HatTrick.DbEx.Sql.Assembler
{
    public class StringValueTypePartAppender : ValueTypePartAppender<string>
    {
        public override void AppendPart(string expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var @fixed = string.IsNullOrWhiteSpace(expression) ? null : expression;
            if (context?.Field != null)
                builder.Appender.Write(builder.Parameters.Add(@fixed, context.Field).Parameter.ParameterName);
            else
                builder.Appender.Write(builder.Parameters.Add<string>(@fixed).ParameterName);
        }
    }
}
