#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using HatTrick.Model.MsSql;
using HatTrick.Model.Sql;
using System.Collections.Generic;
using System.Data;

namespace DbExpression.Tools.Service
{
    public interface ITemplateModelService
    {
        string ResolveRootNamespace();

        string ResolveDatabaseAccessor();

        string ResolveName(INamedMeta namedMeta);

        string[] ResolveAppliedInterfaces(INamedMeta namedMeta);

        ParameterDirection ResolveParameterDirection(MsSqlParameter parameter);

        string? GetClrTypeOverride(INamedMeta namedMeta);

        bool HasClrTypeOverride(INamedMeta namedMeta, out string? dataTypeOverride);

        bool IsEnum(INamedMeta namedMeta);

        bool IsIgnored(INamedMeta namedMeta);

        bool AllowInsert(MsSqlColumn column);

        bool AllowUpdate(MsSqlColumn column);

        IList<string> GetDeclaredEnumerationTypes();

        bool NullableEnabled();
    }
}
