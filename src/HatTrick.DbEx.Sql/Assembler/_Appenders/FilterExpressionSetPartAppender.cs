using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FilterExpressionSetPartAppender : PartAppender<FilterExpressionSet>
    {
        #region internals
        private static IDictionary<ConditionalExpressionOperator, string> _conditionalOperatorMap;
        private static IDictionary<ConditionalExpressionOperator, string> ConditionalOperatorMap => _conditionalOperatorMap ?? (_conditionalOperatorMap = typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators());
        #endregion

        #region methods
        public override void AppendPart(FilterExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is null || (expression.LeftArg is null && expression.RightArg is null))
                return;

            var thisIsTheRootFilterExpressionSet = context.GetState<ThisIsTheRootFilterExpressionSet>() is null;
            if (thisIsTheRootFilterExpressionSet)
            {
                context.SetState(new ThisIsTheRootFilterExpressionSet());
            }

            try
            {
                var hasSet = expression.LeftArg is FilterExpressionSet || expression.RightArg is FilterExpressionSet;
                void conditionallyAppend(bool condition, Action<IAppender> appendAction) { if (condition) appendAction(builder.Appender); }

                conditionallyAppend(thisIsTheRootFilterExpressionSet, a => a.Indent());

                conditionallyAppend(expression.Negate, a => a.Write("NOT "));
                builder.Appender.Write('(');

                if (expression.LeftArg is object)
                {
                    conditionallyAppend(hasSet, a => a.LineBreak().Indentation++.Indent());
                    builder.AppendPart(expression.LeftArg, context);
                    conditionallyAppend(hasSet, a => a.LineBreak());
                }
                if (expression.RightArg is object)
                {
                    conditionallyAppend(hasSet, a => a.Indent());
                    conditionallyAppend(!hasSet, a => a.Write(' '));
                    builder.Appender.Write(ConditionalOperatorMap[expression.ConditionalOperator]);
                    conditionallyAppend(!hasSet, a => a.Write(' '));
                    conditionallyAppend(hasSet, a => a.LineBreak().Indent());
                    builder.AppendPart(expression.RightArg, context);
                    conditionallyAppend(hasSet, a => a.Indentation--);
                }

                conditionallyAppend(hasSet, a => a.LineBreak().Indent());
                builder.Appender.Write(')');
            }
            finally
            {
                if (thisIsTheRootFilterExpressionSet)
                    context.RemoveState<ThisIsTheRootFilterExpressionSet>();
            }
        }
        #endregion

        private class ThisIsTheRootFilterExpressionSet { }
    }
}
