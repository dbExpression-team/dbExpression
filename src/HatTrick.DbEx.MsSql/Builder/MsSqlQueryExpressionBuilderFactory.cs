using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlQueryExpressionBuilderFactory
    {
        #region select one
        public SelectEntity<TEntity> CreateSelectEntityBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : class, IDbEntity
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            expression.Select = new SelectExpressionSet();
            return new MsSqlSelectEntityQueryExpressionBuilder<TEntity>(configuration, expression);
        }

        public SelectValue<ExpandoObject> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field1, IExpressionElement field2, params IExpressionElement[] fields)
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            var expressions = new List<SelectExpression>(fields.Length + 2)
            {
                new SelectExpression(field1),
                new SelectExpression(field2)
            };
            expressions.AddRange(fields.Select(field => new SelectExpression(field)));
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(expressions);
            return new MsSqlSelectValueSelectQueryExpressionBuilder<ExpandoObject>(configuration, expression);
        }

        public SelectValue<TEnum> CreateSelectValueBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(new SelectExpression<TEnum>(new EnumExpressionMediator<TEnum>(field)));
            return new MsSqlSelectValueSelectQueryExpressionBuilder<TEnum>(configuration, expression);
        }

        public SelectValue<TEnum?> CreateSelectValueBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, NullableEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(new SelectExpression<TEnum?>(new EnumExpressionMediator<TEnum>(field)));
            return new MsSqlSelectValueSelectQueryExpressionBuilder<TEnum?>(configuration, expression);
        }

        public SelectValue<bool> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, BooleanElement field)
            => CreateSelectValueBuilder<bool>(configuration, field);

        public SelectValue<bool?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableBooleanElement field)
            => CreateSelectValueBuilder<bool?>(configuration, field);

        public SelectValue<byte> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteElement field)
            => CreateSelectValueBuilder<byte>(configuration, field);

        public SelectValue<byte?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableByteElement field)
            => CreateSelectValueBuilder<byte?>(configuration, field);

        public SelectValue<byte[]> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteArrayElement field)
            => CreateSelectValueBuilder<byte[]>(configuration, field);

        public SelectValue<byte[]> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableByteArrayElement field)
            => CreateSelectValueBuilder<byte[]>(configuration, field);

        public SelectValue<DateTime> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeElement field)
            => CreateSelectValueBuilder<DateTime>(configuration, field);

        public SelectValue<DateTime?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDateTimeElement field)
            => CreateSelectValueBuilder<DateTime?>(configuration, field);

        public SelectValue<DateTimeOffset> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeOffsetElement field)
            => CreateSelectValueBuilder<DateTimeOffset>(configuration, field);

        public SelectValue<DateTimeOffset?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDateTimeOffsetElement field)
            => CreateSelectValueBuilder<DateTimeOffset?>(configuration, field);

        public SelectValue<decimal> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, DecimalElement field)
            => CreateSelectValueBuilder<decimal>(configuration, field);

        public SelectValue<decimal?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDecimalElement field)
            => CreateSelectValueBuilder<decimal?>(configuration, field);

        public SelectValue<double> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, DoubleElement field)
            => CreateSelectValueBuilder<double>(configuration, field);

        public SelectValue<double?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDoubleElement field)
            => CreateSelectValueBuilder<double?>(configuration, field);

        public SelectValue<Guid> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, GuidElement field)
            => CreateSelectValueBuilder<Guid>(configuration, field);

        public SelectValue<Guid?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableGuidElement field)
            => CreateSelectValueBuilder<Guid?>(configuration, field);

        public SelectValue<short> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, Int16Element field)
            => CreateSelectValueBuilder<short>(configuration, field);

        public SelectValue<short?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableInt16Element field)
            => CreateSelectValueBuilder<short?>(configuration, field);

        public SelectValue<int> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, Int32Element field)
            => CreateSelectValueBuilder<int>(configuration, field);

        public SelectValue<int?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableInt32Element field)
            => CreateSelectValueBuilder<int?>(configuration, field);

        public SelectValue<long> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, Int64Element field)
            => CreateSelectValueBuilder<long>(configuration, field);

        public SelectValue<long?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableInt64Element field)
            => CreateSelectValueBuilder<long?>(configuration, field);

        public SelectValue<float> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, SingleElement field)
            => CreateSelectValueBuilder<float>(configuration, field);

        public SelectValue<float?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableSingleElement field)
            => CreateSelectValueBuilder<float?>(configuration, field);

        public SelectValue<string> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, StringElement field)
            => CreateSelectValueBuilder<string>(configuration, field);

        public SelectValue<string> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableStringElement field)
            => CreateSelectValueBuilder<string>(configuration, field);

        public SelectValue<TimeSpan> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, TimeSpanElement field)
            => CreateSelectValueBuilder<TimeSpan>(configuration, field);

        public SelectValue<TimeSpan?> CreateSelectValueBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableTimeSpanElement field)
            => CreateSelectValueBuilder<TimeSpan?>(configuration, field);

        private SelectValue<TValue> CreateSelectValueBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field)
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Top = 1;
            expression.Select = new SelectExpressionSet(new SelectExpression<TValue>(field));
            return new MsSqlSelectValueSelectQueryExpressionBuilder<TValue>(configuration, expression);
        }
        #endregion

        #region select many
        public SelectEntities<TEntity> CreateSelectEntitiesBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : class, IDbEntity
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet();
            return new MsSqlSelectEntitiesSelectQueryExpressionBuilder<TEntity>(configuration, expression);
        }

        public SelectValues<ExpandoObject> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field1, IExpressionElement field2, params IExpressionElement[] fields)
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            var expressions = new List<SelectExpression>(fields.Length + 2)
            {
                new SelectExpression(field1),
                new SelectExpression(field2)
            };
            expressions.AddRange(fields.Select(field => new SelectExpression(field)));
            expression.Select = new SelectExpressionSet(expressions);
            return new MsSqlSelectValuesSelectQueryExpressionBuilder<ExpandoObject>(configuration, expression);
        }

        public SelectValues<TEnum> CreateSelectValuesBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(new SelectExpression<TEnum>(new EnumExpressionMediator<TEnum>(field)));
            return new MsSqlSelectValuesSelectQueryExpressionBuilder<TEnum>(configuration, expression);
        }

        public SelectValues<TEnum?> CreateSelectValuesBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, NullableEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(new SelectExpression<TEnum?>(new NullableEnumExpressionMediator<TEnum>(field)));
            return new MsSqlSelectValuesSelectQueryExpressionBuilder<TEnum?>(configuration, expression);
        }

        public SelectValues<bool> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, BooleanElement field)
            => CreateSelectValuesBuilder<bool>(configuration, field);

        public SelectValues<bool?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableBooleanElement field)
            => CreateSelectValuesBuilder<bool?>(configuration, field);

        public SelectValues<byte> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteElement field)
            => CreateSelectValuesBuilder<byte>(configuration, field);

        public SelectValues<byte?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableByteElement field)
            => CreateSelectValuesBuilder<byte?>(configuration, field);

        public SelectValues<byte[]> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteArrayElement field)
            => CreateSelectValuesBuilder<byte[]>(configuration, field);

        public SelectValues<byte[]> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableByteArrayElement field)
            => CreateSelectValuesBuilder<byte[]>(configuration, field);

        public SelectValues<DateTime> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeElement field)
            => CreateSelectValuesBuilder<DateTime>(configuration, field);

        public SelectValues<DateTime?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDateTimeElement field)
            => CreateSelectValuesBuilder<DateTime?>(configuration, field);

        public SelectValues<DateTimeOffset> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeOffsetElement field)
            => CreateSelectValuesBuilder<DateTimeOffset>(configuration, field);

        public SelectValues<DateTimeOffset?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDateTimeOffsetElement field)
            => CreateSelectValuesBuilder<DateTimeOffset?>(configuration, field);

        public SelectValues<decimal> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, DecimalElement field)
            => CreateSelectValuesBuilder<decimal>(configuration, field);

        public SelectValues<decimal?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDecimalElement field)
            => CreateSelectValuesBuilder<decimal?>(configuration, field);

        public SelectValues<double> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, DoubleElement field)
            => CreateSelectValuesBuilder<double>(configuration, field);

        public SelectValues<double?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableDoubleElement field)
            => CreateSelectValuesBuilder<double?>(configuration, field);

        public SelectValues<Guid> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, GuidElement field)
            => CreateSelectValuesBuilder<Guid>(configuration, field);

        public SelectValues<Guid?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableGuidElement field)
            => CreateSelectValuesBuilder<Guid?>(configuration, field);

        public SelectValues<short> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, Int16Element field)
            => CreateSelectValuesBuilder<short>(configuration, field);

        public SelectValues<short?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableInt16Element field)
            => CreateSelectValuesBuilder<short?>(configuration, field);

        public SelectValues<int> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, Int32Element field)
            => CreateSelectValuesBuilder<int>(configuration, field);

        public SelectValues<int?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableInt32Element field)
            => CreateSelectValuesBuilder<int?>(configuration, field);

        public SelectValues<long> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, Int64Element field)
            => CreateSelectValuesBuilder<long>(configuration, field);

        public SelectValues<long?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableInt64Element field)
            => CreateSelectValuesBuilder<long?>(configuration, field);

        public SelectValues<float> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, SingleElement field)
            => CreateSelectValuesBuilder<float>(configuration, field);

        public SelectValues<float?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableSingleElement field)
            => CreateSelectValuesBuilder<float?>(configuration, field);

        public SelectValues<string> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, StringElement field)
            => CreateSelectValuesBuilder<string>(configuration, field);

        public SelectValues<string> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableStringElement field)
            => CreateSelectValuesBuilder<string>(configuration, field);

        public SelectValues<TimeSpan> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, TimeSpanElement field)
            => CreateSelectValuesBuilder<TimeSpan>(configuration, field);

        public SelectValues<TimeSpan?> CreateSelectValuesBuilder(RuntimeSqlDatabaseConfiguration configuration, NullableTimeSpanElement field)
            => CreateSelectValuesBuilder<TimeSpan?>(configuration, field);

        private SelectValues<TValue> CreateSelectValuesBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field)
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Select = new SelectExpressionSet(new SelectExpression<TValue>(field));
            return new MsSqlSelectValuesSelectQueryExpressionBuilder<TValue>(configuration, expression);
        }
        #endregion

        public UpdateEntities CreateUpdateExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IList<EntityFieldAssignment> fields)
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<UpdateQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            expression.Assign = new AssignmentExpressionSet(expression.Assign.Expressions.Concat(fields?.Select(x => x as AssignmentExpression ?? throw new DbExpressionException($"Expected all {nameof(fields)} to be assignable to {typeof(AssignmentExpression)}."))));
            return new MsSqlUpdateQueryExpressionBuilder(configuration, expression);
        }

        public UpdateEntities<TEntity> CreateUpdateExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, TEntity target, TEntity source)
            where TEntity : class, IDbEntity
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<UpdateQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            return new UpdateEntitiesUpdateQueryExpressionBuilder<TEntity>(configuration, expression, target, source);
        }

        public DeleteEntities CreateDeleteExpressionBulder(RuntimeSqlDatabaseConfiguration configuration)
        {
            var expression = (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<DeleteQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression.");
            return new MsSqlDeleteEntitiesBuilder(configuration, expression);
        }

        public InsertEntity<TEntity> CreateInsertExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, TEntity instance)
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TEntity>(configuration, (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression."), new List<TEntity> { instance });

        public InsertEntities<TEntity> CreateInsertExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, IList<TEntity> instances)
            where TEntity : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<TEntity>(configuration, (configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.")).QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>() ?? throw new DbExpressionConfigurationException($"Expected query expression factory to return a query expression."), instances);
    }
}
