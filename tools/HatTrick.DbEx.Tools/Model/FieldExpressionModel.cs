﻿using HatTrick.DbEx.Tools.Builder;
using HatTrick.Model.MsSql;

namespace HatTrick.DbEx.Tools.Model
{
    public class FieldExpressionModel
    {
        public EntityExpressionModel EntityExpression { get; }
        public string Name { get; }
        public TypeModel Type { get; }
        public bool IsIgnored { get; }        
        public (string,string) CrefTypeName
        {
            get
            {
                if (Type.IsArray)
                    return (Type.Alias.Substring(0, Type.Alias.Length - 2), "[]");
                if (Type.IsNullable)
                    return (Type.Alias, "?");

                return (Type.Alias, null);
            }
        }

        public FieldExpressionModel(EntityExpressionModel entity, MsSqlColumn column, bool isIgnored, string name, string clrTypeOverride, bool isEnum)
        {
            EntityExpression = entity;
            Name = name;
            Type = TypeModelBuilder.CreateTypeModel(column.SqlType, clrTypeOverride, column.IsNullable, isEnum);
            IsIgnored = isIgnored;
        }
    }
}
