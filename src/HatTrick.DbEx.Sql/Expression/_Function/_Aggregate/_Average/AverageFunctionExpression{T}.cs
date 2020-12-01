﻿using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class AverageFunctionExpression<TValue> : AverageFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected AverageFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
