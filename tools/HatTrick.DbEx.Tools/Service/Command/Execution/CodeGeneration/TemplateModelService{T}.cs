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

using HatTrick.DbEx.Tools;
using HatTrick.DbEx.Tools.Configuration;
using HatTrick.DbEx.Tools.Model;
using HatTrick.Model.MsSql;
using HatTrick.Model.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HatTrick.DbEx.Tools.Service
{
    public abstract class TemplateModelService<T> : TemplateModelService, ITemplateModelService<T>
        where T : class, ISqlModel
    {
        #region constructors
        protected TemplateModelService(DbExConfig config) : base(config)
        {
        }
        #endregion

        #region methods
        public abstract DatabasePairModel<T> CreateDatabaseModel(T database);

        public virtual string ResolveRootNamespace()
        {
            return Config.RootNamespace?.TrimEnd('.') + '.';
        }

        public virtual string ResolveDatabaseAccessor()
        {
            return Config.DatabaseAccessor.TrimEnd('.');
        }

        public virtual string ResolveName(INamedMeta namedMeta)
        {
            return namedMeta.TryResolveMeta<string>(a => a.Name, out string? nameOverride) ? nameOverride! : namedMeta.Name;
        }

        public virtual string? ResolveBaseType(INamedMeta namedMeta)
        {
            return namedMeta.TryResolveMeta<string>(a => a.BaseType, out string? baseType) ? baseType : null;
        }

        public virtual string[] ResolveAppliedInterfaces(INamedMeta namedMeta)
        {
            return namedMeta.TryResolveMeta<string>(a => a.Interfaces, out IEnumerable<string>? result) ? result!.ToArray() : Array.Empty<string>();
        }

        public virtual ParameterDirection ResolveParameterDirection(MsSqlParameter parameter)
        {
            if (parameter.TryResolveMeta<string?>(a => a.Direction, out string? direction))
            {
                if (Enum.TryParse<ParameterDirection>(direction, out ParameterDirection converted))
                    return converted;
            }

            return parameter.IsOutput ? ParameterDirection.Output : ParameterDirection.Input;
        }

        public virtual string? GetClrTypeOverride(INamedMeta namedMeta)
        {
            return namedMeta.TryResolveMeta<string?>(a => a.ClrType, out string? dataTypeOverride) ? dataTypeOverride : null;
        }

        public virtual bool HasClrTypeOverride(INamedMeta namedMeta, out string? dataTypeOverride)
        {
            return namedMeta.TryResolveMeta<string?>(a => a.ClrType, out dataTypeOverride);
        }

        public virtual bool IsEnum(INamedMeta namedMeta)
        {
            bool isEnum = false;
            if (this.HasClrTypeOverride(namedMeta, out string? dataTypeOverride))
            {
                var trimmed = dataTypeOverride!.TrimEnd('?');
                isEnum = Config.Enums.Contains(trimmed);
            }
            return isEnum;
        }

        public virtual bool IsIgnored(INamedMeta namedMeta)
        {
            return namedMeta.TryResolveMeta<bool?>(a => a.Ignore, out bool? isIgnored) ? isIgnored!.Value : false;
        }

        public virtual bool AllowInsert(MsSqlColumn column)
        {
            return column.TryResolveMeta<bool?>(a => a.AllowInsert, out bool? allowInsert) ? allowInsert!.Value : true;
        }

        public virtual bool AllowUpdate(MsSqlColumn column)
        {
            return column.TryResolveMeta<bool?>(a => a.AllowUpdate, out bool? allowUpdate) ? allowUpdate!.Value : true;
        }

        public virtual IList<string> GetDeclaredEnumerationTypes()
            => Config.Enums;

        public virtual bool NullableEnabled()
            => Config.LanguageFeatures.Nullable == NullableFeatureTypeCode.Enable;

        protected virtual void AlterArgPsuedonym(SchemaPairModel schema)
            => AlterArgPsuedonym(schema.Entities.Select(x => x.EntityExpression.Name).ToList(), schema.SchemaExpression.ArgNamePsuedonyms);

        protected virtual void AlterArgPsuedonym(EntityPairModel entity)
            => AlterArgPsuedonym(entity.Columns.Select(x => x.FieldExpression.Name).ToList(), entity.EntityExpression.ArgNamePsuedonyms);

        protected virtual void AlterArgPsuedonym(ColumnPairModel column)
            => AlterArgPsuedonym(new() { column.FieldExpression.Name }, column.FieldExpression.ArgNamePsuedonyms);

        protected virtual void AlterArgPsuedonym(List<string> names, Dictionary<string, string> psuedonyms)
        {
            var candidates = names.Intersect(psuedonyms.Keys).ToList();
            if (candidates.Any())
            {
                foreach (var conflict in candidates)
                    AlterArgPsuedonym(
                        conflict,
                        names.Where(x => x.EndsWith(conflict)).OrderByDescending(x => x).ToList(),
                        psuedonyms
                    );
            }
        }

        protected virtual void AlterArgPsuedonym(string conflict, List<string> suspects, Dictionary<string, string> currentPseudonyms)
        {
            var suspect = currentPseudonyms.FirstOrDefault(x => suspects.Contains(x.Value));
            if (suspect.Equals(default(KeyValuePair<string, string>)))
                return;

            var @new = $"_{suspect.Value}";
            currentPseudonyms[conflict] = @new;
            AlterArgPsuedonym(conflict, suspects.Where(x => x.EndsWith(@new)).ToList(), currentPseudonyms);
        }
        #endregion
    }
}
