using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class ParameterPairModel
	{
        public int Identifier { get; }
        public ParameterModel Parameter { get; }
        public ParameterExpressionModel ParameterExpression { get; }

        public ParameterPairModel(int identifier, ParameterModel parameter, ParameterExpressionModel parameterExpression)
        {
            Identifier = identifier;
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
            ParameterExpression = parameterExpression ?? throw new ArgumentNullException(nameof(parameterExpression));
        }

        public override string ToString() => $"({Parameter}, {ParameterExpression})";
    }
}
