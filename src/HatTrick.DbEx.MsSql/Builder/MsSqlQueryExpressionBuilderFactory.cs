using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Syntax;
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
        public IFromExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>> CreateSelectOneExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : class, IDbEntity
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Top(1);
            return builder;
        }

        public IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field1, IExpressionElement field2, params IExpressionElement[] fields)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            var expressions = new List<SelectExpression>(fields.Length + 2)
            {
                new SelectExpression(field1),
                new SelectExpression(field2)
            };
            expressions.AddRange(fields.Select(field => new SelectExpression(field)));
            builder.Expression.Select = new SelectExpressionSet(expressions);
            builder.Expression.Select.Top(1);
            return builder;
        }

        public IFromExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>> CreateSelectOneExpressionBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select = new SelectExpressionSet(new SelectExpression<TEnum>(new EnumExpressionMediator<TEnum>(field)));
            builder.Expression.Select.Top(1);
            return builder;
        }

        public IFromExpressionBuilder<TEnum?, IValueContinuationExpressionBuilder<TEnum?>, IValueContinuationExpressionBuilder<TEnum?, IValueContinuationExpressionBuilder<TEnum?>>> CreateSelectOneExpressionBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, NullEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum?, IValueContinuationExpressionBuilder<TEnum?>, IValueContinuationExpressionBuilder<TEnum?, IValueContinuationExpressionBuilder<TEnum?>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select = new SelectExpressionSet(new SelectExpression<TEnum?>(new EnumExpressionMediator<TEnum>(field)));
            builder.Expression.Select.Top(1);
            return builder;
        }

        public IFromExpressionBuilder<bool, IValueContinuationExpressionBuilder<bool>, IValueContinuationExpressionBuilder<bool, IValueContinuationExpressionBuilder<bool>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, BooleanElement field)
            => CreateSelectOneExpressionBuilder<bool>(configuration, field);

        public IFromExpressionBuilder<bool?, IValueContinuationExpressionBuilder<bool?>, IValueContinuationExpressionBuilder<bool?, IValueContinuationExpressionBuilder<bool?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullBooleanElement field)
            => CreateSelectOneExpressionBuilder<bool?>(configuration, field);

        public IFromExpressionBuilder<byte, IValueContinuationExpressionBuilder<byte>, IValueContinuationExpressionBuilder<byte, IValueContinuationExpressionBuilder<byte>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteElement field)
            => CreateSelectOneExpressionBuilder<byte>(configuration, field);

        public IFromExpressionBuilder<byte?, IValueContinuationExpressionBuilder<byte?>, IValueContinuationExpressionBuilder<byte?, IValueContinuationExpressionBuilder<byte?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullByteElement field)
            => CreateSelectOneExpressionBuilder<byte?>(configuration, field);

        public IFromExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>, IValueContinuationExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteArrayElement field)
            => CreateSelectOneExpressionBuilder<byte[]>(configuration, field);

        public IFromExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>, IValueContinuationExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullByteArrayElement field)
            => CreateSelectOneExpressionBuilder<byte[]>(configuration, field);

        public IFromExpressionBuilder<DateTime, IValueContinuationExpressionBuilder<DateTime>, IValueContinuationExpressionBuilder<DateTime, IValueContinuationExpressionBuilder<DateTime>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeElement field)
            => CreateSelectOneExpressionBuilder<DateTime>(configuration, field);

        public IFromExpressionBuilder<DateTime?, IValueContinuationExpressionBuilder<DateTime?>, IValueContinuationExpressionBuilder<DateTime?, IValueContinuationExpressionBuilder<DateTime?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDateTimeElement field)
            => CreateSelectOneExpressionBuilder<DateTime?>(configuration, field);

        public IFromExpressionBuilder<DateTimeOffset, IValueContinuationExpressionBuilder<DateTimeOffset>, IValueContinuationExpressionBuilder<DateTimeOffset, IValueContinuationExpressionBuilder<DateTimeOffset>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeOffsetElement field)
            => CreateSelectOneExpressionBuilder<DateTimeOffset>(configuration, field);

        public IFromExpressionBuilder<DateTimeOffset?, IValueContinuationExpressionBuilder<DateTimeOffset?>, IValueContinuationExpressionBuilder<DateTimeOffset?, IValueContinuationExpressionBuilder<DateTimeOffset?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDateTimeOffsetElement field)
            => CreateSelectOneExpressionBuilder<DateTimeOffset?>(configuration, field);

        public IFromExpressionBuilder<decimal, IValueContinuationExpressionBuilder<decimal>, IValueContinuationExpressionBuilder<decimal, IValueContinuationExpressionBuilder<decimal>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DecimalElement field)
            => CreateSelectOneExpressionBuilder<decimal>(configuration, field);

        public IFromExpressionBuilder<decimal?, IValueContinuationExpressionBuilder<decimal?>, IValueContinuationExpressionBuilder<decimal?, IValueContinuationExpressionBuilder<decimal?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDecimalElement field)
            => CreateSelectOneExpressionBuilder<decimal?>(configuration, field);

        public IFromExpressionBuilder<double, IValueContinuationExpressionBuilder<double>, IValueContinuationExpressionBuilder<double, IValueContinuationExpressionBuilder<double>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DoubleElement field)
            => CreateSelectOneExpressionBuilder<double>(configuration, field);

        public IFromExpressionBuilder<double?, IValueContinuationExpressionBuilder<double?>, IValueContinuationExpressionBuilder<double?, IValueContinuationExpressionBuilder<double?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDoubleElement field)
            => CreateSelectOneExpressionBuilder<double?>(configuration, field);

        public IFromExpressionBuilder<Guid, IValueContinuationExpressionBuilder<Guid>, IValueContinuationExpressionBuilder<Guid, IValueContinuationExpressionBuilder<Guid>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, GuidElement field)
            => CreateSelectOneExpressionBuilder<Guid>(configuration, field);

        public IFromExpressionBuilder<Guid?, IValueContinuationExpressionBuilder<Guid?>, IValueContinuationExpressionBuilder<Guid?, IValueContinuationExpressionBuilder<Guid?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullGuidElement field)
            => CreateSelectOneExpressionBuilder<Guid?>(configuration, field);

        public IFromExpressionBuilder<short, IValueContinuationExpressionBuilder<short>, IValueContinuationExpressionBuilder<short, IValueContinuationExpressionBuilder<short>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, Int16Element field)
            => CreateSelectOneExpressionBuilder<short>(configuration, field);

        public IFromExpressionBuilder<short?, IValueContinuationExpressionBuilder<short?>, IValueContinuationExpressionBuilder<short?, IValueContinuationExpressionBuilder<short?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullInt16Element field)
            => CreateSelectOneExpressionBuilder<short?>(configuration, field);

        public IFromExpressionBuilder<int, IValueContinuationExpressionBuilder<int>, IValueContinuationExpressionBuilder<int, IValueContinuationExpressionBuilder<int>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, Int32Element field)
            => CreateSelectOneExpressionBuilder<int>(configuration, field);

        public IFromExpressionBuilder<int?, IValueContinuationExpressionBuilder<int?>, IValueContinuationExpressionBuilder<int?, IValueContinuationExpressionBuilder<int?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullInt32Element field)
            => CreateSelectOneExpressionBuilder<int?>(configuration, field);

        public IFromExpressionBuilder<long, IValueContinuationExpressionBuilder<long>, IValueContinuationExpressionBuilder<long, IValueContinuationExpressionBuilder<long>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, Int64Element field)
            => CreateSelectOneExpressionBuilder<long>(configuration, field);

        public IFromExpressionBuilder<long?, IValueContinuationExpressionBuilder<long?>, IValueContinuationExpressionBuilder<long?, IValueContinuationExpressionBuilder<long?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullInt64Element field)
            => CreateSelectOneExpressionBuilder<long?>(configuration, field);

        public IFromExpressionBuilder<float, IValueContinuationExpressionBuilder<float>, IValueContinuationExpressionBuilder<float, IValueContinuationExpressionBuilder<float>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, SingleElement field)
            => CreateSelectOneExpressionBuilder<float>(configuration, field);

        public IFromExpressionBuilder<float?, IValueContinuationExpressionBuilder<float?>, IValueContinuationExpressionBuilder<float?, IValueContinuationExpressionBuilder<float?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullSingleElement field)
            => CreateSelectOneExpressionBuilder<float?>(configuration, field);

        public IFromExpressionBuilder<string, IValueContinuationExpressionBuilder<string>, IValueContinuationExpressionBuilder<string, IValueContinuationExpressionBuilder<string>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, StringElement field)
            => CreateSelectOneExpressionBuilder<string>(configuration, field);

        public IFromExpressionBuilder<string, IValueContinuationExpressionBuilder<string>, IValueContinuationExpressionBuilder<string, IValueContinuationExpressionBuilder<string>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullStringElement field)
            => CreateSelectOneExpressionBuilder<string>(configuration, field);

        public IFromExpressionBuilder<TimeSpan, IValueContinuationExpressionBuilder<TimeSpan>, IValueContinuationExpressionBuilder<TimeSpan, IValueContinuationExpressionBuilder<TimeSpan>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, TimeSpanElement field)
            => CreateSelectOneExpressionBuilder<TimeSpan>(configuration, field);

        public IFromExpressionBuilder<TimeSpan?, IValueContinuationExpressionBuilder<TimeSpan?>, IValueContinuationExpressionBuilder<TimeSpan?, IValueContinuationExpressionBuilder<TimeSpan?>>> CreateSelectOneExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullTimeSpanElement field)
            => CreateSelectOneExpressionBuilder<TimeSpan?>(configuration, field);

        private IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>> CreateSelectOneExpressionBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select = new SelectExpressionSet(new SelectExpression<TValue>(field));
            builder.Expression.Select.Top(1);
            return builder;
        }
        #endregion

        #region select many
        public IListFromExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>> CreateSelectManyExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration)
            where TEntity : IDbEntity
            => new MsSqlSelectQueryExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());

        public IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field1, IExpressionElement field2, params IExpressionElement[] fields)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            var expressions = new List<SelectExpression>(fields.Length + 2)
            {
                new SelectExpression(field1),
                new SelectExpression(field2)
            };
            expressions.AddRange(fields.Select(field => new SelectExpression(field)));
            builder.Expression.Select = new SelectExpressionSet(expressions);
            return builder;
        }

        public IListFromExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>> CreateSelectManyExpressionBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select = new SelectExpressionSet(new SelectExpression<TEnum>(new EnumExpressionMediator<TEnum>(field)));
            return builder;
        }

        public IListFromExpressionBuilder<TEnum?, IValueListContinuationExpressionBuilder<TEnum?>, IValueListContinuationExpressionBuilder<TEnum?, IValueListContinuationExpressionBuilder<TEnum?>>> CreateSelectManyExpressionBuilder<TEnum>(RuntimeSqlDatabaseConfiguration configuration, NullEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TEnum?, IValueListContinuationExpressionBuilder<TEnum?>, IValueListContinuationExpressionBuilder<TEnum?, IValueListContinuationExpressionBuilder<TEnum?>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select = new SelectExpressionSet(new SelectExpression<TEnum?>(new NullableEnumExpressionMediator<TEnum>(field)));
            return builder;
        }

        public IListFromExpressionBuilder<bool, IValueListContinuationExpressionBuilder<bool>, IValueListContinuationExpressionBuilder<bool, IValueListContinuationExpressionBuilder<bool>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, BooleanElement field)
            => CreateSelectManyExpressionBuilder<bool>(configuration, field);

        public IListFromExpressionBuilder<bool?, IValueListContinuationExpressionBuilder<bool?>, IValueListContinuationExpressionBuilder<bool?, IValueListContinuationExpressionBuilder<bool?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullBooleanElement field)
            => CreateSelectManyExpressionBuilder<bool?>(configuration, field);

        public IListFromExpressionBuilder<byte, IValueListContinuationExpressionBuilder<byte>, IValueListContinuationExpressionBuilder<byte, IValueListContinuationExpressionBuilder<byte>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteElement field)
            => CreateSelectManyExpressionBuilder<byte>(configuration, field);

        public IListFromExpressionBuilder<byte?, IValueListContinuationExpressionBuilder<byte?>, IValueListContinuationExpressionBuilder<byte?, IValueListContinuationExpressionBuilder<byte?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullByteElement field)
            => CreateSelectManyExpressionBuilder<byte?>(configuration, field);

        public IListFromExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>, IValueListContinuationExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, ByteArrayElement field)
            => CreateSelectManyExpressionBuilder<byte[]>(configuration, field);

        public IListFromExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>, IValueListContinuationExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullByteArrayElement field)
            => CreateSelectManyExpressionBuilder<byte[]>(configuration, field);

        public IListFromExpressionBuilder<DateTime, IValueListContinuationExpressionBuilder<DateTime>, IValueListContinuationExpressionBuilder<DateTime, IValueListContinuationExpressionBuilder<DateTime>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeElement field)
            => CreateSelectManyExpressionBuilder<DateTime>(configuration, field);

        public IListFromExpressionBuilder<DateTime?, IValueListContinuationExpressionBuilder<DateTime?>, IValueListContinuationExpressionBuilder<DateTime?, IValueListContinuationExpressionBuilder<DateTime?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDateTimeElement field)
            => CreateSelectManyExpressionBuilder<DateTime?>(configuration, field);

        public IListFromExpressionBuilder<DateTimeOffset, IValueListContinuationExpressionBuilder<DateTimeOffset>, IValueListContinuationExpressionBuilder<DateTimeOffset, IValueListContinuationExpressionBuilder<DateTimeOffset>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DateTimeOffsetElement field)
            => CreateSelectManyExpressionBuilder<DateTimeOffset>(configuration, field);

        public IListFromExpressionBuilder<DateTimeOffset?, IValueListContinuationExpressionBuilder<DateTimeOffset?>, IValueListContinuationExpressionBuilder<DateTimeOffset?, IValueListContinuationExpressionBuilder<DateTimeOffset?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDateTimeOffsetElement field)
            => CreateSelectManyExpressionBuilder<DateTimeOffset?>(configuration, field);

        public IListFromExpressionBuilder<decimal, IValueListContinuationExpressionBuilder<decimal>, IValueListContinuationExpressionBuilder<decimal, IValueListContinuationExpressionBuilder<decimal>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DecimalElement field)
            => CreateSelectManyExpressionBuilder<decimal>(configuration, field);

        public IListFromExpressionBuilder<decimal?, IValueListContinuationExpressionBuilder<decimal?>, IValueListContinuationExpressionBuilder<decimal?, IValueListContinuationExpressionBuilder<decimal?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDecimalElement field)
            => CreateSelectManyExpressionBuilder<decimal?>(configuration, field);

        public IListFromExpressionBuilder<double, IValueListContinuationExpressionBuilder<double>, IValueListContinuationExpressionBuilder<double, IValueListContinuationExpressionBuilder<double>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DoubleElement field)
            => CreateSelectManyExpressionBuilder<double>(configuration, field);

        public IListFromExpressionBuilder<double?, IValueListContinuationExpressionBuilder<double?>, IValueListContinuationExpressionBuilder<double?, IValueListContinuationExpressionBuilder<double?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullDoubleElement field)
            => CreateSelectManyExpressionBuilder<double?>(configuration, field);

        public IListFromExpressionBuilder<Guid, IValueListContinuationExpressionBuilder<Guid>, IValueListContinuationExpressionBuilder<Guid, IValueListContinuationExpressionBuilder<Guid>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, GuidElement field)
            => CreateSelectManyExpressionBuilder<Guid>(configuration, field);

        public IListFromExpressionBuilder<Guid?, IValueListContinuationExpressionBuilder<Guid?>, IValueListContinuationExpressionBuilder<Guid?, IValueListContinuationExpressionBuilder<Guid?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullGuidElement field)
            => CreateSelectManyExpressionBuilder<Guid?>(configuration, field);

        public IListFromExpressionBuilder<short, IValueListContinuationExpressionBuilder<short>, IValueListContinuationExpressionBuilder<short, IValueListContinuationExpressionBuilder<short>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, Int16Element field)
            => CreateSelectManyExpressionBuilder<short>(configuration, field);

        public IListFromExpressionBuilder<short?, IValueListContinuationExpressionBuilder<short?>, IValueListContinuationExpressionBuilder<short?, IValueListContinuationExpressionBuilder<short?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullInt16Element field)
            => CreateSelectManyExpressionBuilder<short?>(configuration, field);

        public IListFromExpressionBuilder<int, IValueListContinuationExpressionBuilder<int>, IValueListContinuationExpressionBuilder<int, IValueListContinuationExpressionBuilder<int>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, Int32Element field)
            => CreateSelectManyExpressionBuilder<int>(configuration, field);

        public IListFromExpressionBuilder<int?, IValueListContinuationExpressionBuilder<int?>, IValueListContinuationExpressionBuilder<int?, IValueListContinuationExpressionBuilder<int?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullInt32Element field)
            => CreateSelectManyExpressionBuilder<int?>(configuration, field);

        public IListFromExpressionBuilder<long, IValueListContinuationExpressionBuilder<long>, IValueListContinuationExpressionBuilder<long, IValueListContinuationExpressionBuilder<long>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, Int64Element field)
            => CreateSelectManyExpressionBuilder<long>(configuration, field);

        public IListFromExpressionBuilder<long?, IValueListContinuationExpressionBuilder<long?>, IValueListContinuationExpressionBuilder<long?, IValueListContinuationExpressionBuilder<long?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullInt64Element field)
            => CreateSelectManyExpressionBuilder<long?>(configuration, field);

        public IListFromExpressionBuilder<float, IValueListContinuationExpressionBuilder<float>, IValueListContinuationExpressionBuilder<float, IValueListContinuationExpressionBuilder<float>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, SingleElement field)
            => CreateSelectManyExpressionBuilder<float>(configuration, field);

        public IListFromExpressionBuilder<float?, IValueListContinuationExpressionBuilder<float?>, IValueListContinuationExpressionBuilder<float?, IValueListContinuationExpressionBuilder<float?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullSingleElement field)
            => CreateSelectManyExpressionBuilder<float?>(configuration, field); 
        
        public IListFromExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>, IValueListContinuationExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, StringElement field)
            => CreateSelectManyExpressionBuilder<string>(configuration, field);

        public IListFromExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>, IValueListContinuationExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullStringElement field)
            => CreateSelectManyExpressionBuilder<string>(configuration, field);

        public IListFromExpressionBuilder<TimeSpan, IValueListContinuationExpressionBuilder<TimeSpan>, IValueListContinuationExpressionBuilder<TimeSpan, IValueListContinuationExpressionBuilder<TimeSpan>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, TimeSpanElement field)
            => CreateSelectManyExpressionBuilder<TimeSpan>(configuration, field);

        public IListFromExpressionBuilder<TimeSpan?, IValueListContinuationExpressionBuilder<TimeSpan?>, IValueListContinuationExpressionBuilder<TimeSpan?, IValueListContinuationExpressionBuilder<TimeSpan?>>> CreateSelectManyExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, NullTimeSpanElement field)
            => CreateSelectManyExpressionBuilder<TimeSpan?>(configuration, field);

        private IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>> CreateSelectManyExpressionBuilder<TValue>(RuntimeSqlDatabaseConfiguration configuration, IExpressionElement field)
        {
            var builder = new MsSqlSelectQueryExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>());
            builder.Expression.Select.Top(1);
            builder.Expression.Select = new SelectExpressionSet(new SelectExpression<TValue>(field));
            return builder;
        }
        #endregion
        public IUpdateFromExpressionBuilder CreateUpdateExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, params AssignmentExpression[] fields)
        {
            var builder = new MsSqlUpdateQueryExpressionBuilder(configuration);
            builder.Expression.Assign = new AssignmentExpressionSet(builder.Expression.Assign.Expressions.Concat(fields));
            return builder;
        }

        public IUpdateFromExpressionBuilder<TEntity> CreateUpdateExpressionBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, TEntity target, TEntity source)
            where TEntity : class, IDbEntity
            => new MsSqlUpdateQueryExpressionBuilder<TEntity>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<UpdateQueryExpression>(), target, source);

        public IDeleteFromExpressionBuilder CreateDeleteExpressionBulder(RuntimeSqlDatabaseConfiguration configuration)
            =>  new MsSqlDeleteQueryExpressionBuilder(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<DeleteQueryExpression>());

        public IInsertExpressionBuilder<T> CreateInsertExpressionBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, T instance)
            where T : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<T>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>(), new List<T> { instance });

        public IInsertExpressionBuilder<T> CreateInsertExpressionBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, IList<T> instances)
            where T : class, IDbEntity
            => new MsSqlInsertQueryExpressionBuilder<T>(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<InsertQueryExpression>(), instances);
    }
}
