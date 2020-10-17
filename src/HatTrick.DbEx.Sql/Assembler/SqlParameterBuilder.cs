using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlParameterBuilder : ISqlParameterBuilder
    {
        public IList<ParameterizedExpression> Parameters { get; set; } = new List<ParameterizedExpression>();

        #region abstract methods
        public abstract DbParameter Add<T>(T value);
        public abstract ParameterizedExpression Add<T>(T value, ISqlFieldMetadata meta);
        public abstract DbParameter Add(object value, Type valueType);
        #endregion

        protected virtual ParameterizedExpression FindExistingParameter<T>(T value, Type declaredType, DbType dbType, ParameterDirection direction, int? size, byte? precision, byte? scale)
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

                if (value == null || value is DBNull)
                {
                    if (parameter.Parameter.Value == DBNull.Value)
                        return parameter; //both null/DBNull, parameters are equivalent
                    continue;
                }

                if (parameter.Parameter.Value is DBNull)
                    continue;  //parameter is null but value isn't, continue before type conversion (DBNull will fail type conversion)

                if (!Convert.ChangeType(parameter.Parameter.Value, parameter.DeclaredType).Equals(Convert.ChangeType(value, declaredType)))
                    continue;

                return parameter;
            }
            return null;
        }
    }
}
