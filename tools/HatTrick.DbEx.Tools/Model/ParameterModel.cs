using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class ParameterModel
	{
		public StoredProcedureModel Procedure { get; }
		public string Name { get; }
		public string Identifier { get; }
		public string SqlTypeName { get; }
		public SqlDbType SqlType { get; }
		public long? Size { get; }
		public byte? Precision { get; }
		public byte? Scale { get; }
		public bool IsOutput { get; }
		public bool IsReadOnly { get; }
		public bool IsNullable { get; }
		public IDictionary<string, string> Properties { get; }

		public ParameterModel(StoredProcedureModel procedure, MsSqlParameter parameter)
		{
			Procedure = procedure ?? throw new ArgumentNullException(nameof(procedure));
			Properties = BuildColumnDocumentationMetadata(parameter ?? throw new ArgumentNullException(nameof(parameter)));
			Name = parameter.Name;
            Identifier = parameter.Identifier;
			SqlTypeName = parameter.SqlTypeName;
			IsOutput = parameter.IsOutput;
			IsReadOnly = parameter.IsReadOnly;
			IsNullable = parameter.IsNullable;
			Size = parameter.SqlType.SupportsSize() ? parameter.MaxLength == 0 ? null : parameter.MaxLength : null;
			Precision = parameter.SqlType.SupportsPrecision() ? parameter.Precision == 0 ? (byte?)null : parameter.Precision : null;
			Scale = parameter.SqlType.SupportsPrecision() ? parameter.Scale == 0 ? (byte?)null : parameter.Scale : null;
			SqlType = parameter.SqlType;
		}

		public override string ToString() => $"[{Procedure.Schema.Name}].[{Procedure.Name}].[{Name}]";

		private IDictionary<string, string> BuildColumnDocumentationMetadata(MsSqlParameter parameter)
		{
			var attributes = new Dictionary<string, string>();

			attributes.Add("name", parameter.Name);
			attributes.Add("sql type", parameter.SqlType.ToFriendlyName(parameter.MaxLength, parameter.Precision, parameter.Scale));
			attributes.Add("allow null", parameter.IsNullable ? "yes" : "no");

			return attributes;
		}
	}
}
