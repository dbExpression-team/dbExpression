using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class ParameterPairModel
	{
        public ParameterModel Parameter { get; }
        public ParameterExpressionModel ParameterExpression { get; }

        public ParameterPairModel(ParameterModel parameter, ParameterExpressionModel parameterExpression)
        {
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
            ParameterExpression = parameterExpression ?? throw new ArgumentNullException(nameof(parameterExpression));
        }

        public override string ToString() => $"({Parameter}, {ParameterExpression})";
    }
}
