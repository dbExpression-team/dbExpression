namespace DbEx.DataService
{
    using HatTrick.DbEx.MsSql.Builder;
    using HatTrick.DbEx.Sql.Builder.Syntax;
    using HatTrick.DbEx.Sql.Configuration;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Connection;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    #region runtime
    public abstract class MsSqlDbExTestRuntimeSqlDatabase : IRuntimeSqlDatabase
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
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<byte, IValueContinuationExpressionBuilder<byte>, IValueContinuationExpressionBuilder<byte, IValueContinuationExpressionBuilder<byte>>> SelectOne(SelectExpression<byte> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<byte?, IValueContinuationExpressionBuilder<byte?>, IValueContinuationExpressionBuilder<byte?, IValueContinuationExpressionBuilder<byte?>>> SelectOne(SelectExpression<byte?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<short, IValueContinuationExpressionBuilder<short>, IValueContinuationExpressionBuilder<short, IValueContinuationExpressionBuilder<short>>> SelectOne(SelectExpression<short> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<short?, IValueContinuationExpressionBuilder<short?>, IValueContinuationExpressionBuilder<short?, IValueContinuationExpressionBuilder<short?>>> SelectOne(SelectExpression<short?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<int, IValueContinuationExpressionBuilder<int>, IValueContinuationExpressionBuilder<int, IValueContinuationExpressionBuilder<int>>> SelectOne(SelectExpression<int> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<int?, IValueContinuationExpressionBuilder<int?>, IValueContinuationExpressionBuilder<int?, IValueContinuationExpressionBuilder<int?>>> SelectOne(SelectExpression<int?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<long, IValueContinuationExpressionBuilder<long>, IValueContinuationExpressionBuilder<long, IValueContinuationExpressionBuilder<long>>> SelectOne(SelectExpression<long> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<long?, IValueContinuationExpressionBuilder<long?>, IValueContinuationExpressionBuilder<long?, IValueContinuationExpressionBuilder<long?>>> SelectOne(SelectExpression<long?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<decimal, IValueContinuationExpressionBuilder<decimal>, IValueContinuationExpressionBuilder<decimal, IValueContinuationExpressionBuilder<decimal>>> SelectOne(SelectExpression<decimal> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<decimal?, IValueContinuationExpressionBuilder<decimal?>, IValueContinuationExpressionBuilder<decimal?, IValueContinuationExpressionBuilder<decimal?>>> SelectOne(SelectExpression<decimal?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<double, IValueContinuationExpressionBuilder<double>, IValueContinuationExpressionBuilder<double, IValueContinuationExpressionBuilder<double>>> SelectOne(SelectExpression<double> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<double?, IValueContinuationExpressionBuilder<double?>, IValueContinuationExpressionBuilder<double?, IValueContinuationExpressionBuilder<double?>>> SelectOne(SelectExpression<double?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<float, IValueContinuationExpressionBuilder<float>, IValueContinuationExpressionBuilder<float, IValueContinuationExpressionBuilder<float>>> SelectOne(SelectExpression<float> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<float?, IValueContinuationExpressionBuilder<float?>, IValueContinuationExpressionBuilder<float?, IValueContinuationExpressionBuilder<float?>>> SelectOne(SelectExpression<float?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<bool, IValueContinuationExpressionBuilder<bool>, IValueContinuationExpressionBuilder<bool, IValueContinuationExpressionBuilder<bool>>> SelectOne(SelectExpression<bool> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<bool?, IValueContinuationExpressionBuilder<bool?>, IValueContinuationExpressionBuilder<bool?, IValueContinuationExpressionBuilder<bool?>>> SelectOne(SelectExpression<bool?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<string, IValueContinuationExpressionBuilder<string>, IValueContinuationExpressionBuilder<string, IValueContinuationExpressionBuilder<string>>> SelectOne(SelectExpression<string> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<DateTime, IValueContinuationExpressionBuilder<DateTime>, IValueContinuationExpressionBuilder<DateTime, IValueContinuationExpressionBuilder<DateTime>>> SelectOne(SelectExpression<DateTime> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<DateTime?, IValueContinuationExpressionBuilder<DateTime?>, IValueContinuationExpressionBuilder<DateTime?, IValueContinuationExpressionBuilder<DateTime?>>> SelectOne(SelectExpression<DateTime?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<DateTimeOffset, IValueContinuationExpressionBuilder<DateTimeOffset>, IValueContinuationExpressionBuilder<DateTimeOffset, IValueContinuationExpressionBuilder<DateTimeOffset>>> SelectOne(SelectExpression<DateTimeOffset> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<DateTimeOffset?, IValueContinuationExpressionBuilder<DateTimeOffset?>, IValueContinuationExpressionBuilder<DateTimeOffset?, IValueContinuationExpressionBuilder<DateTimeOffset?>>> SelectOne(SelectExpression<DateTimeOffset?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<Guid, IValueContinuationExpressionBuilder<Guid>, IValueContinuationExpressionBuilder<Guid, IValueContinuationExpressionBuilder<Guid>>> SelectOne(SelectExpression<Guid> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<Guid?, IValueContinuationExpressionBuilder<Guid?>, IValueContinuationExpressionBuilder<Guid?, IValueContinuationExpressionBuilder<Guid?>>> SelectOne(SelectExpression<Guid?> field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field);

        public static IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> SelectOne(SelectExpression field1, SelectExpression field2, params SelectExpression[] fields)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder(config, field1, field2, fields);
        #endregion

        #region select many
        public static IListFromExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>, ITypeListContinuationExpressionBuilder<TEntity, ITypeListContinuationExpressionBuilder<TEntity>>> SelectMany<TEntity>()
            where TEntity : IDbEntity
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<TEntity>(config);

        public static IListFromExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>, IValueListContinuationExpressionBuilder<TEnum, IValueListContinuationExpressionBuilder<TEnum>>> SelectMany<TEnum>(IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<byte, IValueListContinuationExpressionBuilder<byte>, IValueListContinuationExpressionBuilder<byte, IValueListContinuationExpressionBuilder<byte>>> SelectMany(SelectExpression<byte> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<byte?, IValueListContinuationExpressionBuilder<byte?>, IValueListContinuationExpressionBuilder<byte?, IValueListContinuationExpressionBuilder<byte?>>> SelectMany(SelectExpression<byte?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<short, IValueListContinuationExpressionBuilder<short>, IValueListContinuationExpressionBuilder<short, IValueListContinuationExpressionBuilder<short>>> SelectMany(SelectExpression<short> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<short?, IValueListContinuationExpressionBuilder<short?>, IValueListContinuationExpressionBuilder<short?, IValueListContinuationExpressionBuilder<short?>>> SelectMany(SelectExpression<short?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<int, IValueListContinuationExpressionBuilder<int>, IValueListContinuationExpressionBuilder<int, IValueListContinuationExpressionBuilder<int>>> SelectMany(SelectExpression<int> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<int?, IValueListContinuationExpressionBuilder<int?>, IValueListContinuationExpressionBuilder<int?, IValueListContinuationExpressionBuilder<int?>>> SelectMany(SelectExpression<int?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<long, IValueListContinuationExpressionBuilder<long>, IValueListContinuationExpressionBuilder<long, IValueListContinuationExpressionBuilder<long>>> SelectMany(SelectExpression<long> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<long?, IValueListContinuationExpressionBuilder<long?>, IValueListContinuationExpressionBuilder<long?, IValueListContinuationExpressionBuilder<long?>>> SelectMany(SelectExpression<long?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<decimal, IValueListContinuationExpressionBuilder<decimal>, IValueListContinuationExpressionBuilder<decimal, IValueListContinuationExpressionBuilder<decimal>>> SelectMany(SelectExpression<decimal> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<decimal?, IValueListContinuationExpressionBuilder<decimal?>, IValueListContinuationExpressionBuilder<decimal?, IValueListContinuationExpressionBuilder<decimal?>>> SelectMany(SelectExpression<decimal?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<double, IValueListContinuationExpressionBuilder<double>, IValueListContinuationExpressionBuilder<double, IValueListContinuationExpressionBuilder<double>>> SelectMany(SelectExpression<double> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<double?, IValueListContinuationExpressionBuilder<double?>, IValueListContinuationExpressionBuilder<double?, IValueListContinuationExpressionBuilder<double?>>> SelectMany(SelectExpression<double?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<float, IValueListContinuationExpressionBuilder<float>, IValueListContinuationExpressionBuilder<float, IValueListContinuationExpressionBuilder<float>>> SelectMany(SelectExpression<float> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<float?, IValueListContinuationExpressionBuilder<float?>, IValueListContinuationExpressionBuilder<float?, IValueListContinuationExpressionBuilder<float?>>> SelectMany(SelectExpression<float?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<bool, IValueListContinuationExpressionBuilder<bool>, IValueListContinuationExpressionBuilder<bool, IValueListContinuationExpressionBuilder<bool>>> SelectMany(SelectExpression<bool> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<bool?, IValueListContinuationExpressionBuilder<bool?>, IValueListContinuationExpressionBuilder<bool?, IValueListContinuationExpressionBuilder<bool?>>> SelectMany(SelectExpression<bool?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>, IValueListContinuationExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>>> SelectMany(SelectExpression<string> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<DateTime, IValueListContinuationExpressionBuilder<DateTime>, IValueListContinuationExpressionBuilder<DateTime, IValueListContinuationExpressionBuilder<DateTime>>> SelectMany(SelectExpression<DateTime> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<DateTime?, IValueListContinuationExpressionBuilder<DateTime?>, IValueListContinuationExpressionBuilder<DateTime?, IValueListContinuationExpressionBuilder<DateTime?>>> SelectMany(SelectExpression<DateTime?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<DateTimeOffset, IValueListContinuationExpressionBuilder<DateTimeOffset>, IValueListContinuationExpressionBuilder<DateTimeOffset, IValueListContinuationExpressionBuilder<DateTimeOffset>>> SelectMany(SelectExpression<DateTimeOffset> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<DateTimeOffset?, IValueListContinuationExpressionBuilder<DateTimeOffset?>, IValueListContinuationExpressionBuilder<DateTimeOffset?, IValueListContinuationExpressionBuilder<DateTimeOffset?>>> SelectMany(SelectExpression<DateTimeOffset?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<Guid, IValueListContinuationExpressionBuilder<Guid>, IValueListContinuationExpressionBuilder<Guid, IValueListContinuationExpressionBuilder<Guid>>> SelectMany(SelectExpression<Guid> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);

        public static IListFromExpressionBuilder<Guid?, IValueListContinuationExpressionBuilder<Guid?>, IValueListContinuationExpressionBuilder<Guid?, IValueListContinuationExpressionBuilder<Guid?>>> SelectMany(SelectExpression<Guid?> field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field);


        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectMany(SelectExpression field1, SelectExpression field2, params SelectExpression[] fields)
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

        //JROD/GWG: need this in template
        #pragma warning disable IDE1006 // Naming Styles
        public static AliasExpression alias(string tableName, string fieldName)
        #pragma warning restore IDE1006 // Naming Styles
            => new AliasExpression(tableName, fieldName);
        #endregion
    }
    #endregion

    #region db
    #pragma warning disable IDE1006 // Naming Styles
    public partial class db : MsSqlDbExTestRuntimeSqlDatabase
    #pragma warning restore IDE1006 // Naming Styles
    {
    	
    }
    #endregion
}

namespace DbEx.dboDataService
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
namespace DbEx.secDataService
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