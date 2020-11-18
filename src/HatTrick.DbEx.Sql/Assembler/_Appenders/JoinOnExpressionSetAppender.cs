using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnExpressionSetAppender : ExpressionElementAppender<JoinOnExpressionSet>
    {
        #region internals
        private static IDictionary<ConditionalExpressionOperator, string> _conditionalOperatorMap;
        private static IDictionary<ConditionalExpressionOperator, string> ConditionalOperatorMap => _conditionalOperatorMap ?? (_conditionalOperatorMap = typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators()); // x => string.IsNullOrWhiteSpace(x) ? " " : $" {x} "));
        #endregion

        #region methods
        public override void AppendElement(JoinOnExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is null || (expression.LeftArg is null && expression.RightArg is null))
                return;

            //helper action used to conditionally append text to the appender
            void ifAppend(bool condition, Action<IAppender> trueAction, Action<IAppender> falseAction = null) { if (condition) trueAction(builder.Appender); else if (falseAction is object) falseAction(builder.Appender); }

            var thisIsTheRoot = context.GetState<JoinOnExpressionSetContext>() is null;
            if (thisIsTheRoot)
            {
                context.SetState<JoinOnExpressionSetContext>();
            }


            try
            {
                //implicit conversion will create a FilterExpressionSet for a single filter, evaluate whether each arg is "simple" or "complex" for the current
                var leftIsAComplexExpression = !(expression.LeftArg is JoinOnExpression || expression.LeftArg is JoinOnExpressionSet leftSet && leftSet.IsSingleFilter);
                var rightIsAComplexExpression = !(expression.RightArg is JoinOnExpression || expression.RightArg is JoinOnExpressionSet rightSet && rightSet.IsSingleFilter);

                //if the expression set is negated, render "NOT"
                ifAppend(expression.Negate, AppendNegateStart);

                if (expression.LeftArg is object)
                {
                    ifAppend(leftIsAComplexExpression, AppendParensStart);

                    builder.AppendElement(expression.LeftArg, context);

                    ifAppend(leftIsAComplexExpression, AppendParensEnd);
                }
                if (expression.RightArg is object)
                {
                    if (thisIsTheRoot)
                    {
                        builder.Appender.Indentation++;
                        context.GetState<JoinOnExpressionSetContext>().ExtraIndentionApplied = true;
                    }

                    AppendConditionalOperator(builder.Appender, expression.ConditionalOperator);

                    ifAppend(rightIsAComplexExpression, AppendParensStart);

                    builder.AppendElement(expression.RightArg, context);

                    ifAppend(rightIsAComplexExpression, AppendParensEnd);
                }

                ifAppend(expression.Negate, AppendNegateEnd);
            }
            finally
            {
                if (thisIsTheRoot)
                {
                    if (context.GetState<JoinOnExpressionSetContext>().ExtraIndentionApplied)
                        builder.Appender.Indentation--;

                    context.RemoveState<JoinOnExpressionSetContext>();
                }
            }
        }

        private static void AppendNegateStart(IAppender appender)
            => appender
                    .Write("NOT")
                    .LineBreak()
                    .Indent()
                    .Write('(')
                    .LineBreak()
                    .Indentation++
                    .Indent();

        private static void AppendNegateEnd(IAppender appender)
            => appender
                    .LineBreak()
                    .Indentation--
                    .Indent()
                    .Write(')');

        private static void AppendParensStart(IAppender appender)
            => appender
                    .Write('(')
                    .LineBreak()
                    .Indentation++
                    .Indent();

        private static void AppendParensEnd(IAppender appender)
            => appender
                    .LineBreak()
                    .Indentation--
                    .Indent()
                    .Write(')');

        private static void AppendConditionalOperator(IAppender appender, ConditionalExpressionOperator condition)
            => appender
                    .LineBreak()
                    .Indent()
                    .Write(ConditionalOperatorMap[condition])
                    .LineBreak()
                    .Indent();
        #endregion

        private class JoinOnExpressionSetContext 
        { 
            public bool ExtraIndentionApplied { get; set; }
        }
    }
}
