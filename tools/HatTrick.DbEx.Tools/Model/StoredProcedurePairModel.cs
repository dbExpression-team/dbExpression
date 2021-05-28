using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
	public class StoredProcedurePairModel
	{
        public StoredProcedureModel StoredProcedure { get; }
        public StoredProcedureExpressionModel StoredProcedureExpression { get; }
        public IList<ParameterPairModel> Parameters { get; } = new List<ParameterPairModel>();
        public IList<ParameterPairModel> InputParameters => GetInputParameters();
        public IList<ParameterPairModel> OutputParameters => GetOutputParameters();
        public IList<ParameterPairModel> InputOutputParameters => GetInputOutputParameters();
        public bool HasOutputParameters => OutputParameters.Any() || InputOutputParameters.Any();
        public bool HasInputParameters => InputParameters.Any() || InputOutputParameters.Any();

        public StoredProcedurePairModel(StoredProcedureModel procedure, StoredProcedureExpressionModel procedureExpression)
        {
            StoredProcedure = procedure ?? throw new ArgumentNullException(nameof(procedure));
            StoredProcedureExpression = procedureExpression ?? throw new ArgumentNullException(nameof(procedureExpression));
        }

        private List<ParameterPairModel> GetInputParameters()
            => Parameters.Where(p => p.ParameterExpression.Direction == ParameterDirection.Input).ToList();

        private List<ParameterPairModel> GetOutputParameters()
            => Parameters.Where(p => p.ParameterExpression.Direction == ParameterDirection.Output).ToList();

        private List<ParameterPairModel> GetInputOutputParameters()
            => Parameters.Where(p => p.ParameterExpression.Direction == ParameterDirection.InputOutput).ToList();

        public override string ToString() => $"({StoredProcedure}, {StoredProcedureExpression})";
    }
}
