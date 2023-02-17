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
using System.Text;

namespace HatTrick.DbEx.Tools.Model
{
	public class ParameterPairModel
	{
        public int Identifier { get; }
        public PlatformModel Platform { get; set; }
        public ParameterModel Parameter { get; }
        public ParameterExpressionModel ParameterExpression { get; }

        public ParameterPairModel(int identifier, PlatformModel platform, ParameterModel parameter, ParameterExpressionModel parameterExpression)
        {
            Identifier = identifier;
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
            ParameterExpression = parameterExpression ?? throw new ArgumentNullException(nameof(parameterExpression));
        }

        public override string ToString() => $"({Parameter}, {ParameterExpression})";
    }
}
