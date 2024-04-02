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

using DbExpression.Tools.Builder;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Tools.Model
{
    public class FieldExpressionModel
    {
        private string? _typeName;
        private string? _expressionTypeName;
        private string? _elementName;
        private string? _selectName;
        private string? _insertName;
        private IList<FieldExpressionAssignmentMethodParameters>? _assignmentParameters;

        internal TypeModel Type { get; }

        public LanguageFeaturesModel LanguageFeatures { get; }
        public EntityExpressionModel EntityExpression { get; }
        public string Name { get; }
        public bool AllowInsert { get; }
        public bool AllowUpdate { get; }
        public string TypeName => _typeName ??= ResolveTypeName();
        public string FieldExpressionTypeName => _expressionTypeName ??= BuildFieldExpressionTypeName();
        public string ExpressionElementTypeName => _elementName ??= BuildExpressionElementTypeName();
        public string SelectExpressionTypeName => _selectName ??= BuildSelectExpressionTypeName();
        public string InsertExpressionTypeName => _insertName ??= BuildInsertExpressionTypeName();
        public IList<FieldExpressionAssignmentMethodParameters> AssignmentMethodParameters => _assignmentParameters ??= BuildFieldExpressionAssignmentMethodParameters();
        public (string, string?) CrefTypeName
        {
            get
            {
                if (Type.IsArray)
                    return (Type.Alias[0..^2], "[]");
                if (Type.IsNullable)
                    return (Type.Alias, "?");

                return (Type.Alias, null);
            }
        }        

        public string ValueInitializer => Type.Initializer is not null ? $" = {Type.Initializer};" : string.Empty;

        public FieldExpressionModel(LanguageFeaturesModel features, EntityExpressionModel entity, MsSqlColumn column, string name, string? clrTypeOverride, bool isEnum, bool allowInsert, bool allowUpdate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            EntityExpression = entity ?? throw new ArgumentNullException(nameof(entity));
            LanguageFeatures = features ?? throw new ArgumentNullException(nameof(features));
            Name = name;
            Type = TypeModelBuilder.CreateTypeModel(features, column.SqlType, clrTypeOverride, column.IsNullable, isEnum);
            AllowInsert = allowInsert;
            AllowUpdate = allowUpdate;
        }

        public IList<FieldExpressionAssignmentMethodParameters> BuildFieldExpressionAssignmentMethodParameters()
        {
            List<FieldExpressionAssignmentMethodParameters> parameters = new();

            parameters.Add(new("(string TableName, string FieldName)", $"new AliasExpression<{ResolveTypeName()}>(value)"));
            if (Type.IsNullable)
            {
                parameters.Add(new("NullElement", $"new LiteralExpression<{ResolveTypeName()}>(value, this)"));
            }

            if (Type.IsEnum)
            {
                parameters.Add(new(Type.Alias, $"new LiteralExpression<{Type.Alias}>(value, this)"));
                parameters.Add(new(ExpressionElementTypeName.Replace("?",""), "value"));
                if (Type.IsNullable)
                {
                    parameters.Add(new(Type.NullableAlias, $"new LiteralExpression<{Type.NullableAlias}>(value, this)"));
                    if (LanguageFeatures.Nullable.IsFeatureEnabled)
                        parameters.Add(new(ExpressionElementTypeName, "value"));
                }
                return parameters;
            }

            if (Type.IsString)
            {
                if (LanguageFeatures.Nullable.IsFeatureEnabled && Type.IsNullable)
                {
                    parameters.Add(new(Type.NullableAlias, $"new LiteralExpression<{Type.NullableAlias}>(value, this)"));
                }
                else
                {
                    parameters.Add(new(Type.Alias, $"new LiteralExpression<{Type.Alias}>(value, this)"));
                }
                parameters.Add(new(ExpressionElementTypeName, "value"));
                return parameters;
            }

            if (Type.IsUserDefinedType)
            {
                if (LanguageFeatures.Nullable.IsFeatureEnabled && Type.IsNullable)
                {
                    parameters.Add(new(Type.NullableAlias, $"new LiteralExpression<{Type.NullableAlias}>(value, this)"));
                }
                else
                {
                    parameters.Add(new(Type.Alias, $"new LiteralExpression<{Type.Alias}>(value, this)"));
                }
                parameters.Add(new(ExpressionElementTypeName, "value"));
                return parameters;
            }

            if (Type.IsArray)
            {
                if (LanguageFeatures.Nullable.IsFeatureEnabled && Type.IsNullable)
                {
                    parameters.Add(new(Type.NullableAlias, $"new LiteralExpression<{Type.NullableAlias}>(value, this)"));
                }
                else
                {
                    parameters.Add(new(Type.Alias, $"new LiteralExpression<{Type.Alias}>(value, this)"));
                }
                parameters.Add(new(ExpressionElementTypeName, "value"));
                return parameters;
            }

            if (Type.IsSystemType)
            {
                if (Type.IsNullable)
                {
                    parameters.Add(new(Type.NullableAlias, $"new LiteralExpression<{Type.NullableAlias}>(value, this)"));
                    parameters.Add(new(ExpressionElementTypeName, "value"));
                }
                parameters.Add(new(Type.Alias, $"new LiteralExpression<{Type.Alias}>(value, this)"));
                parameters.Add(new(ExpressionElementTypeName.Replace("?", ""), "value"));
                return parameters;
            }

            return parameters;
        }

        private string BuildFieldExpressionTypeName()
        {
            var name = "";
            if (Type.IsUserDefinedType && !Type.IsEnum)
                return $"ObjectFieldExpression<{EntityExpression.Name},{Type.TypeName}{(LanguageFeatures.Nullable.IsFeatureEnabled && Type.IsNullable ? "?" : "")}>";

            if (Type.IsNullable)
                name += "Nullable";

            name += Type.IsEnum ? "Enum" : Type.IsArray ? $"{Type.TypeName[0..^2]}Array" : Type.TypeName;
            name += "FieldExpression<";
            name += EntityExpression.Name;

            if (Type.IsEnum)
            {
                name += ",";
                name += Type.TypeName;
            }
            name += ">";

            return name;
        }

        public string BuildExpressionElementTypeName()
        {
            if (Type.IsString)
            {
                return Type.IsNullable ? "AnyStringElement" : "StringElement";
            }
            var fieldExpressionTypeName = "AnyElement<";
            fieldExpressionTypeName += ResolveTypeName();
            fieldExpressionTypeName += ">";
            return fieldExpressionTypeName;
        }

        public string BuildSelectExpressionTypeName()
        {
            var fieldExpressionTypeName = "SelectExpression<";
            fieldExpressionTypeName += ResolveTypeName();
            fieldExpressionTypeName += ">";
            return fieldExpressionTypeName;
        }

        public string BuildInsertExpressionTypeName()
        {
            var fieldExpressionTypeName = "InsertExpression<";
            fieldExpressionTypeName += ResolveTypeName();
            fieldExpressionTypeName += ">";
            return fieldExpressionTypeName;
        }

        private string ResolveTypeName()
        {
            if (Type.IsNullable)
            {
                if (Type.IsEnum)
                {
                    return Type.NullableAlias;
                }
                if (!Type.IsSystemType || Type.IsArray)
                {
                    return LanguageFeatures.Nullable.IsFeatureEnabled ? Type.NullableAlias : Type.Alias;
                }
                return Type.NullableAlias;
            }
            return Type.Alias;
        }

        public override string ToString()
                => $"{Name}Field";
    }
}
