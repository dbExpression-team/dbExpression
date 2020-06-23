namespace HatTrick.DbEx.Sql.Assembler
{
    public class StringValueTypePartAppender : ValueTypePartAppender<string>
    {
        public override void AppendPart(string expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.Appender.Write(builder.Parameters.Add<string>(expression).ParameterName);
    }
}
