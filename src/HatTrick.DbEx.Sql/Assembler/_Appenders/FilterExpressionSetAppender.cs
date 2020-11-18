using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FilterExpressionSetAppender : ExpressionElementAppender<FilterExpressionSet>
    {
        #region internals
        private static IDictionary<ConditionalExpressionOperator, string> _conditionalOperatorMap;
        private static IDictionary<ConditionalExpressionOperator, string> ConditionalOperatorMap => _conditionalOperatorMap ?? (_conditionalOperatorMap = typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators());
        #endregion

        #region methods
        public override void AppendElement(FilterExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is null || (expression.LeftArg is null && expression.RightArg is null))
                return;

            //helper action used to conditionally append text to the appender
            void ifAppend(bool condition, Action<IAppender> trueAction, Action<IAppender> falseAction = null) { if (condition) trueAction(builder.Appender); else if (falseAction is object) falseAction(builder.Appender); }

            //set assembly state to use in recursive calls to this appender
            var thisIsTheRoot = context.GetState<FilterExpressionSetContext>() is null;
            if (thisIsTheRoot)
            {
                context.SetState<FilterExpressionSetContext>();
                builder.Appender.LineBreak().Indent();
            }

            try
            {
                //implicit conversion will create a FilterExpressionSet for a single filter, evaluate whether each arg is "simple" or "complex" for the current
                var leftIsAComplexExpression = !(expression.LeftArg is FilterExpression || expression.LeftArg is FilterExpressionSet leftSet && leftSet.IsSingleFilter);
                var rightIsAComplexExpression = !(expression.RightArg is FilterExpression || expression.RightArg is FilterExpressionSet rightSet && rightSet.IsSingleFilter);

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
                    context.RemoveState<FilterExpressionSetContext>();
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

        private class FilterExpressionSetContext { }
    }
}
