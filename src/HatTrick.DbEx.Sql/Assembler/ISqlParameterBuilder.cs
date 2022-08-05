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

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlParameterBuilder
    {
        IList<ParameterizedExpression> Parameters { get; }
        void AddParameter(ParameterizedExpression parameter);

        ParameterizedExpression CreateInputParameter<T>(T value, AssemblyContext context);
        ParameterizedExpression CreateInputParameter(object value, Type valueType, AssemblyContext context);
        ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context);
        ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlParameterMetadata meta, AssemblyContext context);

        ParameterizedExpression CreateInputOutputParameter<T>(T value, AssemblyContext context);
        ParameterizedExpression CreateInputOutputParameter(object value, Type valueType, AssemblyContext context);
        ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context);
        ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlParameterMetadata meta, AssemblyContext context);

        ParameterizedExpression CreateOutputParameter(Type valueType, ISqlFieldMetadata meta, AssemblyContext context);
        ParameterizedExpression CreateOutputParameter(Type valueType, ISqlParameterMetadata meta, AssemblyContext context);
    }
}
