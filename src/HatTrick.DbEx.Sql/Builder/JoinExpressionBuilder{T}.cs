﻿using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class JoinExpressionBuilder<T> : IJoinExpressionBuilder<T>
        where T : IExpressionBuilder
    {
        private ExpressionSet Expression { get; set; }
        private IDbExpression JoinOn { get; set; }
        private JoinOperationExpressionOperator JoinType { get; set; }
        private T Caller { get; set; }
        protected string Alias { get; set; }

        public JoinExpressionBuilder(ExpressionSet expression, EntityExpression joinOn, JoinOperationExpressionOperator joinType, T caller)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
            JoinOn = joinOn ?? throw new ArgumentNullException($"{nameof(joinOn)} is required.");
            JoinType = joinType;
            Caller = caller is object ? caller : throw new ArgumentNullException($"{nameof(caller)} is required.");
        }

        public JoinExpressionBuilder(ExpressionSet expression, ExpressionSet subquery, JoinOperationExpressionOperator joinType, T caller)
        {
            Expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
            JoinOn = subquery ?? throw new ArgumentNullException($"{nameof(subquery)} is required.");
            JoinType = joinType;
            Caller = caller is object ? caller : throw new ArgumentNullException($"{nameof(caller)} is required.");
        }

        T IJoinExpressionBuilder<T>.On(JoinOnExpression expression)
        {
            if (Expression.Joins is null)
                Expression.Joins = new JoinExpressionSet(new JoinExpression(JoinOn, JoinType, expression, Alias));
            else
                Expression.Joins.Expressions.Add(new JoinExpression(JoinOn, JoinType, expression, Alias));
            return Caller;
        }
    }
}
