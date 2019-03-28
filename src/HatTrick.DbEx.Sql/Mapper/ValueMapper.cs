using System;
using System.Linq.Expressions;
using System.Reflection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class ValueMapper : IValueMapper
    {
        public IMapperFactory Factory { get; set; }

        public ValueMapper(IMapperFactory factory)
        {
            Factory = factory;
        }

        public T Map<T>(FieldExpression fieldExpression, ISqlField sqlField)
            => Factory.CreateValueMapper<T>().Map(sqlField.Value);
    }
}
