using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class InExpressionPartAppender : PartAppender<InExpression>
    {
        public override void AppendPart(InExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("IN (");
            AddParametersFromList(builder, context.Field, expression.Expression);
            builder.Appender.Write(")");
        }

        private void AddParametersFromList(ISqlStatementBuilder builder, FieldExpression field, IEnumerable expression)
        {
            var meta = field is object ? builder.FindMetadata(field) : null;
            var enumerator = expression.GetEnumerator();
            var firstElement = true;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is null)
                    continue;

                if (!firstElement)
                {
                    builder.Appender.Write(',');
                }
                else
                {
                    firstElement = false;
                }
                AddParameter(builder, field, meta, enumerator.Current);
            }
        }

        private void AddParameter(ISqlStatementBuilder builder, FieldExpression field, ISqlFieldMetadata meta, object expression)
        {
            if (field is object)
            {
                builder.Appender.Write(
                   builder.Parameters.Add(
                       expression is null || expression is DBNull ? DBNull.Value : expression,
                       field,
                       meta
                   )
                   .Parameter.ParameterName
               );
            }
            else
            {
                if (expression is null || expression is DBNull)
                {
                    return;
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression, expression.GetType()).ParameterName);
                }
            }
        }
    }
}
