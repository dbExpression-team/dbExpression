namespace HatTrick.DbEx.Sql.Assembler
{
    public class NullableValueTypePartAppender<T> : IAssemblyPartAppender<T>
    {
        public virtual void AppendPart(T value, ISqlStatementBuilder builder, AssemblyContext context)
            =>  builder.Appender.Write(builder.Parameters.Add(value, builder.FindMetadata(context.Field)).Parameter.ParameterName);
    }
}
