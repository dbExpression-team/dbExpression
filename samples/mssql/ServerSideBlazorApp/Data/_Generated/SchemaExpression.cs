namespace ServerSideBlazorApp.DataService
{
    using HatTrick.DbEx.MsSql.Builder;
    using HatTrick.DbEx.Sql.Builder;
    using HatTrick.DbEx.Sql.Builder.Syntax;
    using HatTrick.DbEx.Sql.Configuration;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Connection;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    #region runtime
    public abstract class CRMDatabaseRuntimeSqlDatabase : IRuntimeSqlDatabase
    {
        #region internals
        protected static RuntimeSqlDatabaseConfiguration config;
        protected static MsSqlQueryExpressionBuilderFactory expressionBuilderFactory = new MsSqlQueryExpressionBuilderFactory();
        #endregion

        #region interface
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabase.Configuration { get => config; set => config = value; }
        #endregion

        #region methods
        #region select one
        public static IFromExpressionBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>, ITypeContinuationBuilder<TEntity, ITypeContinuationExpressionBuilder<TEntity>>> SelectOne<TEntity>()
            where TEntity : class, IDbEntity
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<TEntity>(config);

        public static IFromExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>, IValueContinuationExpressionBuilder<TEnum, IValueContinuationExpressionBuilder<TEnum>>> SelectOne<TEnum>(IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<TEnum>(config, field);

        public static IFromExpressionBuilder<byte, IValueContinuationExpressionBuilder<byte>, IValueContinuationExpressionBuilder<byte, IValueContinuationExpressionBuilder<byte>>> SelectOne(ByteExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<byte>(config, field);

        public static IFromExpressionBuilder<byte?, IValueContinuationExpressionBuilder<byte?>, IValueContinuationExpressionBuilder<byte?, IValueContinuationExpressionBuilder<byte?>>> SelectOne(NullableByteExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<byte?>(config, field);

        public static IFromExpressionBuilder<short, IValueContinuationExpressionBuilder<short>, IValueContinuationExpressionBuilder<short, IValueContinuationExpressionBuilder<short>>> SelectOne(Int16ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<short>(config, field);

        public static IFromExpressionBuilder<short?, IValueContinuationExpressionBuilder<short?>, IValueContinuationExpressionBuilder<short?, IValueContinuationExpressionBuilder<short?>>> SelectOne(NullableInt16ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<short?>(config, field);

        public static IFromExpressionBuilder<int, IValueContinuationExpressionBuilder<int>, IValueContinuationExpressionBuilder<int, IValueContinuationExpressionBuilder<int>>> SelectOne(Int32ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<int>(config, field);

        public static IFromExpressionBuilder<int?, IValueContinuationExpressionBuilder<int?>, IValueContinuationExpressionBuilder<int?, IValueContinuationExpressionBuilder<int?>>> SelectOne(NullableInt32ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<int?>(config, field);

        public static IFromExpressionBuilder<long, IValueContinuationExpressionBuilder<long>, IValueContinuationExpressionBuilder<long, IValueContinuationExpressionBuilder<long>>> SelectOne(Int64ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<long>(config, field);

        public static IFromExpressionBuilder<long?, IValueContinuationExpressionBuilder<long?>, IValueContinuationExpressionBuilder<long?, IValueContinuationExpressionBuilder<long?>>> SelectOne(NullableInt64ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<long?>(config, field);

        public static IFromExpressionBuilder<decimal, IValueContinuationExpressionBuilder<decimal>, IValueContinuationExpressionBuilder<decimal, IValueContinuationExpressionBuilder<decimal>>> SelectOne(DecimalExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<decimal>(config, field);

        public static IFromExpressionBuilder<decimal?, IValueContinuationExpressionBuilder<decimal?>, IValueContinuationExpressionBuilder<decimal?, IValueContinuationExpressionBuilder<decimal?>>> SelectOne(NullableDecimalExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<decimal?>(config, field);

        public static IFromExpressionBuilder<double, IValueContinuationExpressionBuilder<double>, IValueContinuationExpressionBuilder<double, IValueContinuationExpressionBuilder<double>>> SelectOne(DoubleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<double>(config, field);

        public static IFromExpressionBuilder<double?, IValueContinuationExpressionBuilder<double?>, IValueContinuationExpressionBuilder<double?, IValueContinuationExpressionBuilder<double?>>> SelectOne(NullableDoubleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<double?>(config, field);

        public static IFromExpressionBuilder<float, IValueContinuationExpressionBuilder<float>, IValueContinuationExpressionBuilder<float, IValueContinuationExpressionBuilder<float>>> SelectOne(SingleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<float>(config, field);

        public static IFromExpressionBuilder<float?, IValueContinuationExpressionBuilder<float?>, IValueContinuationExpressionBuilder<float?, IValueContinuationExpressionBuilder<float?>>> SelectOne(NullableSingleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<float?>(config, field);

        public static IFromExpressionBuilder<bool, IValueContinuationExpressionBuilder<bool>, IValueContinuationExpressionBuilder<bool, IValueContinuationExpressionBuilder<bool>>> SelectOne(BooleanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<bool>(config, field);

        public static IFromExpressionBuilder<bool?, IValueContinuationExpressionBuilder<bool?>, IValueContinuationExpressionBuilder<bool?, IValueContinuationExpressionBuilder<bool?>>> SelectOne(NullableBooleanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<bool?>(config, field);

        public static IFromExpressionBuilder<string, IValueContinuationExpressionBuilder<string>, IValueContinuationExpressionBuilder<string, IValueContinuationExpressionBuilder<string>>> SelectOne(StringExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<string>(config, field);

        public static IFromExpressionBuilder<DateTime, IValueContinuationExpressionBuilder<DateTime>, IValueContinuationExpressionBuilder<DateTime, IValueContinuationExpressionBuilder<DateTime>>> SelectOne(DateTimeExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<DateTime>(config, field);

        public static IFromExpressionBuilder<DateTime?, IValueContinuationExpressionBuilder<DateTime?>, IValueContinuationExpressionBuilder<DateTime?, IValueContinuationExpressionBuilder<DateTime?>>> SelectOne(NullableDateTimeExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<DateTime?>(config, field);

        public static IFromExpressionBuilder<DateTimeOffset, IValueContinuationExpressionBuilder<DateTimeOffset>, IValueContinuationExpressionBuilder<DateTimeOffset, IValueContinuationExpressionBuilder<DateTimeOffset>>> SelectOne(DateTimeOffsetExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<DateTimeOffset>(config, field);

        public static IFromExpressionBuilder<DateTimeOffset?, IValueContinuationExpressionBuilder<DateTimeOffset?>, IValueContinuationExpressionBuilder<DateTimeOffset?, IValueContinuationExpressionBuilder<DateTimeOffset?>>> SelectOne(NullableDateTimeOffsetExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<DateTimeOffset?>(config, field);

        public static IFromExpressionBuilder<Guid, IValueContinuationExpressionBuilder<Guid>, IValueContinuationExpressionBuilder<Guid, IValueContinuationExpressionBuilder<Guid>>> SelectOne(GuidExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<Guid>(config, field);

        public static IFromExpressionBuilder<Guid?, IValueContinuationExpressionBuilder<Guid?>, IValueContinuationExpressionBuilder<Guid?, IValueContinuationExpressionBuilder<Guid?>>> SelectOne(NullableGuidExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<Guid?>(config, field);

        public static IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> SelectOne(ExpressionMediator field1, ExpressionMediator field2, params ExpressionMediator[] fields)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field1, field2, fields);
        #endregion

        #region select many
        public static IListFromExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>> SelectMany<TEntity>()
            where TEntity : IDbEntity
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<TEntity>(config);

        public static IListFromExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>> SelectMany<TEnum>(IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<TEnum>(config, field);

        public static IListFromExpressionBuilder<byte, IValueListContinuationExpressionBuilder<byte>, IValueListContinuationExpressionBuilder<byte, IValueListContinuationExpressionBuilder<byte>>> SelectMany(ByteExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<byte>(config, field);

        public static IListFromExpressionBuilder<byte?, IValueListContinuationExpressionBuilder<byte?>, IValueListContinuationExpressionBuilder<byte?, IValueListContinuationExpressionBuilder<byte?>>> SelectMany(NullableByteExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<byte?>(config, field);

        public static IListFromExpressionBuilder<short, IValueListContinuationExpressionBuilder<short>, IValueListContinuationExpressionBuilder<short, IValueListContinuationExpressionBuilder<short>>> SelectMany(Int16ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<short>(config, field);

        public static IListFromExpressionBuilder<short?, IValueListContinuationExpressionBuilder<short?>, IValueListContinuationExpressionBuilder<short?, IValueListContinuationExpressionBuilder<short?>>> SelectMany(NullableInt16ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<short?>(config, field);

        public static IListFromExpressionBuilder<int, IValueListContinuationExpressionBuilder<int>, IValueListContinuationExpressionBuilder<int, IValueListContinuationExpressionBuilder<int>>> SelectMany(Int32ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<int>(config, field);

        public static IListFromExpressionBuilder<int?, IValueListContinuationExpressionBuilder<int?>, IValueListContinuationExpressionBuilder<int?, IValueListContinuationExpressionBuilder<int?>>> SelectMany(NullableInt32ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<int?>(config, field);

        public static IListFromExpressionBuilder<long, IValueListContinuationExpressionBuilder<long>, IValueListContinuationExpressionBuilder<long, IValueListContinuationExpressionBuilder<long>>> SelectMany(Int64ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<long>(config, field);

        public static IListFromExpressionBuilder<long?, IValueListContinuationExpressionBuilder<long?>, IValueListContinuationExpressionBuilder<long?, IValueListContinuationExpressionBuilder<long?>>> SelectMany(NullableInt64ExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<long?>(config, field);

        public static IListFromExpressionBuilder<decimal, IValueListContinuationExpressionBuilder<decimal>, IValueListContinuationExpressionBuilder<decimal, IValueListContinuationExpressionBuilder<decimal>>> SelectMany(DecimalExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<decimal>(config, field);

        public static IListFromExpressionBuilder<decimal?, IValueListContinuationExpressionBuilder<decimal?>, IValueListContinuationExpressionBuilder<decimal?, IValueListContinuationExpressionBuilder<decimal?>>> SelectMany(NullableDecimalExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<decimal?>(config, field);

        public static IListFromExpressionBuilder<double, IValueListContinuationExpressionBuilder<double>, IValueListContinuationExpressionBuilder<double, IValueListContinuationExpressionBuilder<double>>> SelectMany(DoubleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<double>(config, field);

        public static IListFromExpressionBuilder<double?, IValueListContinuationExpressionBuilder<double?>, IValueListContinuationExpressionBuilder<double?, IValueListContinuationExpressionBuilder<double?>>> SelectMany(NullableDoubleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<double?>(config, field);

        public static IListFromExpressionBuilder<float, IValueListContinuationExpressionBuilder<float>, IValueListContinuationExpressionBuilder<float, IValueListContinuationExpressionBuilder<float>>> SelectMany(SingleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<float>(config, field);

        public static IListFromExpressionBuilder<float?, IValueListContinuationExpressionBuilder<float?>, IValueListContinuationExpressionBuilder<float?, IValueListContinuationExpressionBuilder<float?>>> SelectMany(NullableSingleExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<float?>(config, field);

        public static IListFromExpressionBuilder<bool, IValueListContinuationExpressionBuilder<bool>, IValueListContinuationExpressionBuilder<bool, IValueListContinuationExpressionBuilder<bool>>> SelectMany(BooleanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<bool>(config, field);

        public static IListFromExpressionBuilder<bool?, IValueListContinuationExpressionBuilder<bool?>, IValueListContinuationExpressionBuilder<bool?, IValueListContinuationExpressionBuilder<bool?>>> SelectMany(NullableBooleanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<bool?>(config, field);

        public static IListFromExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>, IValueListContinuationExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>>> SelectMany(StringExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<string>(config, field);

        public static IListFromExpressionBuilder<DateTime, IValueListContinuationExpressionBuilder<DateTime>, IValueListContinuationExpressionBuilder<DateTime, IValueListContinuationExpressionBuilder<DateTime>>> SelectMany(DateTimeExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<DateTime>(config, field);

        public static IListFromExpressionBuilder<DateTime?, IValueListContinuationExpressionBuilder<DateTime?>, IValueListContinuationExpressionBuilder<DateTime?, IValueListContinuationExpressionBuilder<DateTime?>>> SelectMany(NullableDateTimeExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<DateTime?>(config, field);

        public static IListFromExpressionBuilder<DateTimeOffset, IValueListContinuationExpressionBuilder<DateTimeOffset>, IValueListContinuationExpressionBuilder<DateTimeOffset, IValueListContinuationExpressionBuilder<DateTimeOffset>>> SelectMany(DateTimeOffsetExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<DateTimeOffset>(config, field);

        public static IListFromExpressionBuilder<DateTimeOffset?, IValueListContinuationExpressionBuilder<DateTimeOffset?>, IValueListContinuationExpressionBuilder<DateTimeOffset?, IValueListContinuationExpressionBuilder<DateTimeOffset?>>> SelectMany(NullableDateTimeOffsetExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<DateTimeOffset?>(config, field);

        public static IListFromExpressionBuilder<Guid, IValueListContinuationExpressionBuilder<Guid>, IValueListContinuationExpressionBuilder<Guid, IValueListContinuationExpressionBuilder<Guid>>> SelectMany(GuidExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<Guid>(config, field);

        public static IListFromExpressionBuilder<Guid?, IValueListContinuationExpressionBuilder<Guid?>, IValueListContinuationExpressionBuilder<Guid?, IValueListContinuationExpressionBuilder<Guid?>>> SelectMany(NullableGuidExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<Guid?>(config, field);


        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectMany(ExpressionMediator field1, ExpressionMediator field2, params ExpressionMediator[] fields)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field1, field2, fields);
        #endregion

        public static IUpdateFromExpressionBuilder Update(params AssignmentExpression[] fields)
            => expressionBuilderFactory.CreateUpdateExpressionBuilder(config, fields);

        public static IDeleteFromExpressionBuilder Delete()
            => expressionBuilderFactory.CreateDeleteExpressionBulder(config);

        public static IInsertExpressionBuilder<T> Insert<T>(T instance)
            where T : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, instance);

        public static IInsertExpressionBuilder<T> InsertMany<T>(IList<T> instances)
            where T : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, instances);

        public static IInsertExpressionBuilder<T> InsertMany<T>(params T[] instances)
            where T : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, instances);

        public static ISqlConnection GetConnection()
        {
            return config.ConnectionFactory.CreateSqlConnection();
        }

        #pragma warning disable CA1034 // Nested types should not be visible
        #pragma warning disable IDE1006 // Naming Styles
        public class fx : MsSqlFunctionExpressionBuilder
        #pragma warning restore IDE1006 // Naming Styles
        #pragma warning restore CA1034 // Nested types should not be visible
        {

        }

        public static IAliasExpressionContinuationBuilder alias(string tableName, string fieldName)
        {
            return new AliasExpressionBuilder(new AliasExpression(tableName, fieldName));
        }
        #endregion
    }
    #endregion

    #region db
    #pragma warning disable IDE1006 // Naming Styles
    public partial class db : CRMDatabaseRuntimeSqlDatabase
    #pragma warning restore IDE1006 // Naming Styles
    {
    	
    }
    #endregion
}

namespace ServerSideBlazorApp.dboDataService
{
    using HatTrick.DbEx.Sql.Expression;
    using System;

    #region dbo
#pragma warning disable IDE1006 // Naming Styles
    public class dboSchemaExpression : SchemaExpression
#pragma warning restore IDE1006 // Naming Styles
    {
        #region interface
        public AddressEntity Address { get; private set; }
        public PersonEntity Person { get; private set; }
        public PersonAddressEntity PersonAddress { get; private set; }
        public ProductEntity Product { get; private set; }
        public PurchaseEntity Purchase { get; private set; }
        public PurchaseLineEntity PurchaseLine { get; private set; }
        public PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get; private set; }
        #endregion

        #region constructors
        public dboSchemaExpression(string identifier) : base(identifier, null)
        {
            Entities.Add($"{identifier}.Address", Address = new AddressEntity($"{identifier}.Address", this));
            Entities.Add($"{identifier}.Person", Person = new PersonEntity($"{identifier}.Person", this));
            Entities.Add($"{identifier}.Person_Address", PersonAddress = new PersonAddressEntity($"{identifier}.Person_Address", this));
            Entities.Add($"{identifier}.Product", Product = new ProductEntity($"{identifier}.Product", this));
            Entities.Add($"{identifier}.Purchase", Purchase = new PurchaseEntity($"{identifier}.Purchase", this));
            Entities.Add($"{identifier}.PurchaseLine", PurchaseLine = new PurchaseLineEntity($"{identifier}.PurchaseLine", this));
            Entities.Add($"{identifier}.PersonTotalPurchasesView", PersonTotalPurchasesView = new PersonTotalPurchasesViewEntity($"{identifier}.PersonTotalPurchasesView", this));
        }
        #endregion
    }
    #endregion
}
namespace ServerSideBlazorApp.secDataService
{
    using HatTrick.DbEx.Sql.Expression;
    using System;

    #region sec
#pragma warning disable IDE1006 // Naming Styles
    public class secSchemaExpression : SchemaExpression
#pragma warning restore IDE1006 // Naming Styles
    {
        #region interface
        public PersonEntity Person { get; private set; }
        #endregion

        #region constructors
        public secSchemaExpression(string identifier) : base(identifier, null)
        {
            Entities.Add($"{identifier}.Person", Person = new PersonEntity($"{identifier}.Person", this));
        }
        #endregion
    }
    #endregion
}