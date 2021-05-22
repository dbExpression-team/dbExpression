using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class ParameterModel
	{
		public ProcedureModel Procedure { get; }
		public string Name { get; }
		public int ParameterId { get; }
		public string SqlTypeName { get; }
		public SqlDbType SqlType { get; }
		public byte Scale { get; }
		public byte Precision { get; }
		public short MaxLength { get; }
		public bool IsOutput { get; }
		public bool IsReadOnly { get; }
		public bool IsNullable { get; }

		public ParameterModel(ProcedureModel procedure, MsSqlParameter parameter)
		{
			Procedure = procedure;
			Name = parameter.Name;
			ParameterId = parameter.ParameterId;
			SqlTypeName = parameter.SqlTypeName;
			SqlType = parameter.SqlType;
			Scale = parameter.Scale;
			Precision = parameter.Precision;
			MaxLength = parameter.MaxLength;
			IsOutput = parameter.IsOutput;
			IsReadOnly = parameter.IsReadOnly;
			IsNullable = parameter.IsNullable;
		}

		public override string ToString() => $"[{Procedure.Schema.Name}].[{Procedure.Name}].[{Name}]";
	}
}
