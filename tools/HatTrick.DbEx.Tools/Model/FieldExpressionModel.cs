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

﻿using HatTrick.DbEx.Tools.Builder;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public class FieldExpressionAssignmentMethodParameters
    { 
        public string Left { get; }
        public string Right { get; }

        public FieldExpressionAssignmentMethodParameters(string left, string right)
        {
            Left = left;
            Right = right;
        }
    }
    public class FieldExpressionModel
    {
        private string? _typeName;
        private string? _elementName;
        private string? _selectName;
        private IList<FieldExpressionAssignmentMethodParameters>? _assignmentParameters;

        public LanguageFeatures LanguageFeatures { get; }
        public EntityExpressionModel EntityExpression { get; }
        public string Name { get; }
        public TypeModel Type { get; }
        public bool AllowInsert { get; }
        public bool AllowUpdate { get; }
        public string FieldExpressionTypeName => _typeName ??= BuildFieldExpressionTypeName();
        public string ExpressionElementTypeName => _elementName ??= BuildExpressionElementTypeName();
        public string SelectExpressionTypeName => _selectName ??= BuildSelectExpressionTypeName();
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

        public FieldExpressionModel(LanguageFeatures features, EntityExpressionModel entity, MsSqlColumn column, string name, string? clrTypeOverride, bool isEnum, bool allowInsert, bool allowUpdate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            EntityExpression = entity ?? throw new ArgumentNullException(nameof(entity));
            LanguageFeatures = features ?? throw new ArgumentNullException(nameof(features));
            Name = name;
            Type = TypeModelBuilder.CreateTypeModel(features, column.SqlType, clrTypeOverride, column.IsNullable, isEnum ? TypeSpecialCase.Enum : null);
            AllowInsert = allowInsert;
            AllowUpdate = allowUpdate;
        }

        public IList<FieldExpressionAssignmentMethodParameters> BuildFieldExpressionAssignmentMethodParameters()
        {
            List<FieldExpressionAssignmentMethodParameters> parameters = new();

            if (Type.IsNullable)
            {
                parameters.Add(new("DBNull", $"new LiteralExpression<{Type.NullableAlias}>(value, this)"));
            }

            if (Type.IsEnum)
            {
                parameters.Add(new(Type.Alias, $"new LiteralExpression<{Type.Alias}>(value, this)"));
                parameters.Add(new(ExpressionElementTypeName.Replace("?",""), "value"));
                if (Type.IsNullable)
                {
                    parameters.Add(new(Type.NullableAlias, $"new LiteralExpression<{Type.NullableAlias}>(value, this)"));
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
                parameters.Add(new(Type.IsNullable ? Type.NullableAlias : Type.Alias, $"new LiteralExpression<{(Type.IsNullable ? Type.NullableAlias : Type.Alias)}>(value, this)"));
                parameters.Add(new(ExpressionElementTypeName, "value"));
                if (Type.IsNullable)
                {
                    parameters.Add(new(Type.Alias, $"new LiteralExpression<{Type.Alias}>(value, this)"));
                    parameters.Add(new(ExpressionElementTypeName.Replace("?", ""), "value"));
                }
                return parameters;
            }

            return parameters;
        }

        private string BuildFieldExpressionTypeName()
        {
            var name = "";
            if (Type.IsUserDefinedType && !Type.IsEnum)
                return $"{(Type.IsNullable ? "Nullable" : "")}ObjectFieldExpression<{EntityExpression.Name},{Type.TypeName}>";

            if (Type.IsNullable)
                name += "Nullable";

            name += Type.IsEnum ? "Enum" : Type.TypeName;
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
            fieldExpressionTypeName += Type.NullableAlias;
            fieldExpressionTypeName += ">";
            return fieldExpressionTypeName;
        }

        public string BuildSelectExpressionTypeName()
        {
            var fieldExpressionTypeName = "SelectExpression<";
            fieldExpressionTypeName += Type.NullableAlias;
            fieldExpressionTypeName += ">";
            return fieldExpressionTypeName;
        }

        public override string ToString()
                => $"{Name}Field";
    }
}
