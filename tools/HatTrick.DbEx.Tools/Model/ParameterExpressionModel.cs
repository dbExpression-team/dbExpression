using HatTrick.DbEx.Tools.Builder;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class ParameterExpressionModel
	{
		public StoredProcedureExpressionModel ProcedureExpression { get; }
		public string Name { get; }
		public TypeModel Type { get; }
		public ParameterDirection Direction { get; }
		public bool RequiresInput => (Direction == ParameterDirection.Input || Direction == ParameterDirection.InputOutput);

		public ParameterExpressionModel(LanguageFeatures features, StoredProcedureExpressionModel procedureExpression, MsSqlParameter parameter, string name, string? clrTypeOverride, bool isEnum, ParameterDirection direction)
		{
			ProcedureExpression = procedureExpression;
			Name = name;
			Type = TypeModelBuilder.CreateTypeModel(features, parameter.SqlType, clrTypeOverride, parameter.IsNullable, isEnum);
			Direction = direction;
		}

		public override string ToString() => $"{Name}Parameter";
	}
}
