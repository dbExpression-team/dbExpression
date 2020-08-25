using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ValueTypePartAppender<T> : IAssemblyPartAppender<T>
        where T : IComparable
    {
        public virtual void AppendPart(T value, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.Appender.Write(builder.Parameters.Add(value, context.Field, builder.FindMetadata(context.Field)).Parameter.ParameterName);
    }
}
