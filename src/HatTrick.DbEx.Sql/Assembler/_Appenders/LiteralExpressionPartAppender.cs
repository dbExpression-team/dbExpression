using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class LiteralExpressionPartAppender : PartAppender<LiteralExpression>
    {
        public override void AppendPart(LiteralExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //if the expression value is enumerable, need to add each one individually.  String data type is enumerable, treat it like any other single valued primitive type
            if (expression.Expression is IEnumerable list && !(expression.Expression is string))
            {
                AddParametersFromList(builder, context.Field, list);
            }
            else if (context.Field is object)
            {
                AddParameterWithField(builder, context.Field, expression.Expression);
            }
            else
            {
                AddParameterWithoutField(builder, expression.Expression);
            }
        }

        private void AddParametersFromList(ISqlStatementBuilder builder, FieldExpression field, IEnumerable expression)
        {
            var meta = builder.FindMetadata(field);
            var enumerator = expression.GetEnumerator();
            var firstElement = true;
            while (enumerator.MoveNext())
            {
                if (!firstElement)
                {
                    builder.Appender.Write(',');
                }
                else
                { 
                    firstElement = false;                
                }

                var value = enumerator.Current;

                if (field is object)
                {
                    builder.Appender.Write(
                        builder.Parameters.Add(
                            value is null || value is DBNull ? DBNull.Value : value,
                            field,
                            meta
                        )
                        .Parameter.ParameterName
                    );
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(value, value.GetType()).ParameterName);
                }
            }
        }

        private void AddParameterWithField(ISqlStatementBuilder builder, FieldExpression field, object expression)
        {
            builder.Appender.Write(
                builder.Parameters.Add(
                    expression is null || expression is DBNull ? DBNull.Value : expression,
                    field,
                    builder.FindMetadata(field)
                )
                .Parameter.ParameterName
            );
        }

        private void AddParameterWithoutField(ISqlStatementBuilder builder, object expression)
        {
            if (expression is null || expression is DBNull)
            {
                builder.Appender.Write("NULL");
            }
            else
            {
                builder.Appender.Write(builder.Parameters.Add(expression, expression.GetType()).ParameterName);
            }
        }
    }
}
