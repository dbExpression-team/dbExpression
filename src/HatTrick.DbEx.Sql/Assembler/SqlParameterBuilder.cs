using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlParameterBuilder : ISqlParameterBuilder
    {
        public IList<ParameterizedFieldExpression> Parameters { get; set; } = new List<ParameterizedFieldExpression>();

        #region abstract methods
        public abstract DbParameter Add<T>(T value);
        public abstract ParameterizedFieldExpression Add<T>(T value, FieldExpression expression, ISqlFieldMetadata meta);
        public abstract DbParameter Add(object value, Type valueType);
        public abstract ParameterizedFieldExpression AddOutput(FieldExpression expression, ISqlFieldMetadata meta);
        #endregion

        protected virtual ParameterizedFieldExpression FindExistingParameter<T>(T value, Type declaredType, DbType dbType, ParameterDirection direction, int? size, byte? precision, byte? scale)
        {
            foreach (var parameter in Parameters)
            {
                if (parameter.Parameter.Direction != direction)
                    continue;

                if (size.HasValue && !(parameter.Parameter.Size == size.Value))
                    continue;
                if (precision.HasValue && !(parameter.Parameter.Precision == precision.Value))
                    continue;
                if (scale.HasValue && !(parameter.Parameter.Scale == scale.Value))
                    continue;

                if (parameter.DeclaredType != declaredType)
                    continue;

                if (parameter.Parameter.DbType != dbType)
                    continue;                
                
                if (!Convert.ChangeType(parameter.Parameter.Value, parameter.DeclaredType).Equals(Convert.ChangeType(value, declaredType)))
                    continue;

                return parameter;
            }
            return null;
        }
    }
}
