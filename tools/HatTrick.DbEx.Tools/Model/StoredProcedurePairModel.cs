#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

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
        public int Identifier { get; }
        public PlatformModel Platform { get; set; }
        public StoredProcedureModel StoredProcedure { get; }
        public StoredProcedureExpressionModel StoredProcedureExpression { get; }
        public IList<ParameterPairModel> Parameters { get; } = new List<ParameterPairModel>();
        public IList<ParameterPairModel> InputParameters => GetInputParameters();
        public IList<ParameterPairModel> OutputParameters => GetOutputParameters();
        public IList<ParameterPairModel> InputOutputParameters => GetInputOutputParameters();
        public bool HasOutputParameters => OutputParameters.Any() || InputOutputParameters.Any();
        public bool HasInputParameters => InputParameters.Any() || InputOutputParameters.Any();

        public StoredProcedurePairModel(int identifier, PlatformModel platform, StoredProcedureModel procedure, StoredProcedureExpressionModel procedureExpression)
        {
            Identifier = identifier;
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
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
