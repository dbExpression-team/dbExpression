using DbEx.Data;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Connection;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DbEx.DataService
{
    #region runtime db
    public abstract class MsSqlDbRuntimeSqlDatabase : IRuntimeSqlDatabase
    {
        #region internals
        protected static RuntimeSqlDatabaseConfiguration config = new RuntimeSqlDatabaseConfiguration();
        protected static MsSqlQueryExpressionBuilderFactory expressionBuilderFactory = new MsSqlQueryExpressionBuilderFactory();
        #endregion

        #region interface
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabase.Configuration => config;
        #endregion

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

        public static IFromExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>, IValueContinuationExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>>> SelectOne(ByteArrayExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<byte[]>(config, field);

        public static IFromExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>, IValueContinuationExpressionBuilder<byte[], IValueContinuationExpressionBuilder<byte[]>>> SelectOne(NullableByteArrayExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<byte[]>(config, field);

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

        public static IFromExpressionBuilder<string, IValueContinuationExpressionBuilder<string>, IValueContinuationExpressionBuilder<string, IValueContinuationExpressionBuilder<string>>> SelectOne(NullableStringExpressionMediator field)
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

        public static IFromExpressionBuilder<TimeSpan, IValueContinuationExpressionBuilder<TimeSpan>, IValueContinuationExpressionBuilder<TimeSpan, IValueContinuationExpressionBuilder<TimeSpan>>> SelectOne(TimeSpanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<TimeSpan>(config, field);

        public static IFromExpressionBuilder<TimeSpan?, IValueContinuationExpressionBuilder<TimeSpan?>, IValueContinuationExpressionBuilder<TimeSpan?, IValueContinuationExpressionBuilder<TimeSpan?>>> SelectOne(NullableTimeSpanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectOneExpressionBuilder<TimeSpan?>(config, field);

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

        public static IListFromExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>, IValueListContinuationExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>>> SelectMany(ByteArrayExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<byte[]>(config, field);

        public static IListFromExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>, IValueListContinuationExpressionBuilder<byte[], IValueListContinuationExpressionBuilder<byte[]>>> SelectMany(NullableByteArrayExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<byte[]>(config, field);

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

        public static IListFromExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>, IValueListContinuationExpressionBuilder<string, IValueListContinuationExpressionBuilder<string>>> SelectMany(NullableStringExpressionMediator field)
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

        public static IListFromExpressionBuilder<TimeSpan, IValueListContinuationExpressionBuilder<TimeSpan>, IValueListContinuationExpressionBuilder<TimeSpan, IValueListContinuationExpressionBuilder<TimeSpan>>> SelectMany(TimeSpanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<TimeSpan>(config, field);

        public static IListFromExpressionBuilder<TimeSpan?, IValueListContinuationExpressionBuilder<TimeSpan?>, IValueListContinuationExpressionBuilder<TimeSpan?, IValueListContinuationExpressionBuilder<TimeSpan?>>> SelectMany(NullableTimeSpanExpressionMediator field)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder<TimeSpan?>(config, field);
            
        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectMany(ExpressionMediator field1, ExpressionMediator field2, params ExpressionMediator[] fields)
            => expressionBuilderFactory.CreateSelectManyExpressionBuilder(config, field1, field2, fields);
        #endregion

        #region update
        public static IUpdateFromExpressionBuilder Update(params AssignmentExpression[] fields)
            => expressionBuilderFactory.CreateUpdateExpressionBuilder(config, fields);
        #endregion

        #region delete
        public static IDeleteFromExpressionBuilder Delete()
            => expressionBuilderFactory.CreateDeleteExpressionBulder(config);
        #endregion

        #region insert
        public static IInsertExpressionBuilder<T> Insert<T>(T instance)
            where T : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, instance);
        #endregion

        #region insert many
        public static IInsertExpressionBuilder<T> InsertMany<T>(IList<T> instances)
            where T : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, instances);

        public static IInsertExpressionBuilder<T> InsertMany<T>(params T[] instances)
            where T : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, instances);
        #endregion

        #region get connection
        public static ISqlConnection GetConnection()
        {
            return config.ConnectionFactory.CreateSqlConnection();
        }
        #pragma warning disable IDE1006 // Naming Styles
        #pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region fx
#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable IDE1006 // Naming Styles
        public class fx : MsSqlFunctionExpressionBuilder
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1034 // Nested types should not be visible
        {
        }
        #endregion

        #region alias
#pragma warning disable IDE1006 // Naming Styles
        public static IAliasExpressionContinuationBuilder alias(string tableName, string fieldName)
#pragma warning restore IDE1006 // Naming Styles
        {
            return new AliasExpressionBuilder(new AliasExpression(tableName, fieldName));
        }
        #endregion
    }
    #endregion

    #region runtime environment db
    public class MsSqlDb : RuntimeEnvironmentSqlDatabase
    {
        public MsSqlDb() : base(new db(), new SqlDatabaseMetadataProvider(new MsSqlDbSqlDatabaseMetadata("MsSqlDb", "MsSqlDbExTest")))
        { }
    }
    #endregion

    #region db
#pragma warning disable IDE1006 // Naming Styles
    public partial class db : MsSqlDbRuntimeSqlDatabase
#pragma warning restore IDE1006 // Naming Styles
    {
    	
    }
    #endregion
}

namespace DbEx.dboDataService
{
	using DbEx.dboData;

    #region dbo schema expression
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

    #region address entity expression
    public partial class AddressEntity : EntityExpression<Address>
    {
        #region interface properties
        public Int32FieldExpression<Address> Id { get; private set; }
        public NullableEnumFieldExpression<Address, AddressType> AddressType { get; private set; }
        public StringFieldExpression<Address> Line1 { get; private set; }
        public NullableStringFieldExpression<Address> Line2 { get; private set; }
        public StringFieldExpression<Address> City { get; private set; }
        public StringFieldExpression<Address> State { get; private set; }
        public StringFieldExpression<Address> Zip { get; private set; }
        public DateTimeFieldExpression<Address> DateCreated { get; private set; }
        public DateTimeFieldExpression<Address> DateUpdated { get; private set; }
        #endregion

        #region constructors
        private AddressEntity() : base(null, null, null)
        {
        }

		public AddressEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private AddressEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Address>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.AddressType", AddressType = new NullableEnumFieldExpression<Address, AddressType>($"{identifier}.AddressType", this));
            Fields.Add($"{identifier}.Line1", Line1 = new StringFieldExpression<Address>($"{identifier}.Line1", this));
            Fields.Add($"{identifier}.Line2", Line2 = new NullableStringFieldExpression<Address>($"{identifier}.Line2", this));
            Fields.Add($"{identifier}.City", City = new StringFieldExpression<Address>($"{identifier}.City", this));
            Fields.Add($"{identifier}.State", State = new StringFieldExpression<Address>($"{identifier}.State", this));
            Fields.Add($"{identifier}.Zip", Zip = new StringFieldExpression<Address>($"{identifier}.Zip", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Address>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Address>($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public AddressEntity As(string name)
        {
            return new AddressEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                AddressType,
                Line1,
                Line2,
                City,
                State,
                Zip,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Address> GetInclusiveInsertExpression(Address address)
        {
            return new InsertExpressionSet<Address>(
				address,
                Id.Insert(address.Id),
                AddressType.Insert(address.AddressType),
                Line1.Insert(address.Line1),
                Line2.Insert(address.Line2),
                City.Insert(address.City),
                State.Insert(address.State),
                Zip.Insert(address.Zip),
                DateCreated.Insert(address.DateCreated),
                DateUpdated.Insert(address.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Address from, Address to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.AddressType != to.AddressType) { expr &= AddressType.Set(to.AddressType); }; 
			if (from.Line1 != to.Line1) { expr &= Line1.Set(to.Line1); }; 
			if (from.Line2 != to.Line2) { expr &= Line2.Set(to.Line2); }; 
			if (from.City != to.City) { expr &= City.Set(to.City); }; 
			if (from.State != to.State) { expr &= State.Set(to.State); }; 
			if (from.Zip != to.Zip) { expr &= Zip.Set(to.Zip); }; 
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }; 
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Address address, ISqlFieldReader reader)
        {
			address.Id = reader.ReadField().GetValue<int>();
			address.AddressType = reader.ReadField().GetValue<AddressType?>();
			address.Line1 = reader.ReadField().GetValue<string>();
			address.Line2 = reader.ReadField().GetValue<string>();
			address.City = reader.ReadField().GetValue<string>();
			address.State = reader.ReadField().GetValue<string>();
			address.Zip = reader.ReadField().GetValue<string>();
			address.DateCreated = reader.ReadField().GetValue<DateTime>();
			address.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region person entity expression
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region interface properties
        public Int32FieldExpression<Person> Id { get; private set; }
        public StringFieldExpression<Person> FirstName { get; private set; }
        public StringFieldExpression<Person> LastName { get; private set; }
        public NullableDateTimeFieldExpression<Person> BirthDate { get; private set; }
        public EnumFieldExpression<Person, GenderType> GenderType { get; private set; }
        public NullableInt32FieldExpression<Person> CreditLimit { get; private set; }
        public NullableInt32FieldExpression<Person> YearOfLastCreditLimitReview { get; private set; }
        public DateTimeFieldExpression<Person> DateCreated { get; private set; }
        public DateTimeFieldExpression<Person> DateUpdated { get; private set; }
        #endregion

        #region constructors
        private PersonEntity() : base(null, null, null)
        {
        }

		public PersonEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Person>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.FirstName", FirstName = new StringFieldExpression<Person>($"{identifier}.FirstName", this));
            Fields.Add($"{identifier}.LastName", LastName = new StringFieldExpression<Person>($"{identifier}.LastName", this));
            Fields.Add($"{identifier}.BirthDate", BirthDate = new NullableDateTimeFieldExpression<Person>($"{identifier}.BirthDate", this));
            Fields.Add($"{identifier}.GenderType", GenderType = new EnumFieldExpression<Person, GenderType>($"{identifier}.GenderType", this));
            Fields.Add($"{identifier}.CreditLimit", CreditLimit = new NullableInt32FieldExpression<Person>($"{identifier}.CreditLimit", this));
            Fields.Add($"{identifier}.YearOfLastCreditLimitReview", YearOfLastCreditLimitReview = new NullableInt32FieldExpression<Person>($"{identifier}.YearOfLastCreditLimitReview", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Person>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Person>($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                FirstName,
                LastName,
                BirthDate,
                GenderType,
                CreditLimit,
                YearOfLastCreditLimitReview,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(
				person,
                Id.Insert(person.Id),
                FirstName.Insert(person.FirstName),
                LastName.Insert(person.LastName),
                BirthDate.Insert(person.BirthDate),
                GenderType.Insert(person.GenderType),
                CreditLimit.Insert(person.CreditLimit),
                YearOfLastCreditLimitReview.Insert(person.YearOfLastCreditLimitReview),
                DateCreated.Insert(person.DateCreated),
                DateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.FirstName != to.FirstName) { expr &= FirstName.Set(to.FirstName); }; 
			if (from.LastName != to.LastName) { expr &= LastName.Set(to.LastName); }; 
			if (from.BirthDate != to.BirthDate) { expr &= BirthDate.Set(to.BirthDate); }; 
			if (from.GenderType != to.GenderType) { expr &= GenderType.Set(to.GenderType); }; 
			if (from.CreditLimit != to.CreditLimit) { expr &= CreditLimit.Set(to.CreditLimit); }; 
			if (from.YearOfLastCreditLimitReview != to.YearOfLastCreditLimitReview) { expr &= YearOfLastCreditLimitReview.Set(to.YearOfLastCreditLimitReview); }; 
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }; 
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader)
        {
			person.Id = reader.ReadField().GetValue<int>();
			person.FirstName = reader.ReadField().GetValue<string>();
			person.LastName = reader.ReadField().GetValue<string>();
			person.BirthDate = reader.ReadField().GetValue<DateTime?>();
			person.GenderType = reader.ReadField().GetValue<GenderType>();
			person.CreditLimit = reader.ReadField().GetValue<int?>();
			person.YearOfLastCreditLimitReview = reader.ReadField().GetValue<int?>();
			person.DateCreated = reader.ReadField().GetValue<DateTime>();
			person.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region person address entity expression
    public partial class PersonAddressEntity : EntityExpression<PersonAddress>
    {
        #region interface properties
        public Int32FieldExpression<PersonAddress> Id { get; private set; }
        public Int32FieldExpression<PersonAddress> PersonId { get; private set; }
        public Int32FieldExpression<PersonAddress> AddressId { get; private set; }
        public DateTimeFieldExpression<PersonAddress> DateCreated { get; private set; }
        #endregion

        #region constructors
        private PersonAddressEntity() : base(null, null, null)
        {
        }

		public PersonAddressEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonAddressEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<PersonAddress>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new Int32FieldExpression<PersonAddress>($"{identifier}.PersonId", this));
            Fields.Add($"{identifier}.AddressId", AddressId = new Int32FieldExpression<PersonAddress>($"{identifier}.AddressId", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<PersonAddress>($"{identifier}.DateCreated", this));
        }
        #endregion

        #region methods
        public PersonAddressEntity As(string name)
        {
            return new PersonAddressEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                PersonId,
                AddressId,
                DateCreated
            );
        }
		
        protected override InsertExpressionSet<PersonAddress> GetInclusiveInsertExpression(PersonAddress personAddress)
        {
            return new InsertExpressionSet<PersonAddress>(
				personAddress,
                Id.Insert(personAddress.Id),
                PersonId.Insert(personAddress.PersonId),
                AddressId.Insert(personAddress.AddressId),
                DateCreated.Insert(personAddress.DateCreated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonAddress from, PersonAddress to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.PersonId != to.PersonId) { expr &= PersonId.Set(to.PersonId); }; 
			if (from.AddressId != to.AddressId) { expr &= AddressId.Set(to.AddressId); }; 
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }; 
			
            return expr;
        }

        protected override void HydrateEntity(PersonAddress personAddress, ISqlFieldReader reader)
        {
			personAddress.Id = reader.ReadField().GetValue<int>();
			personAddress.PersonId = reader.ReadField().GetValue<int>();
			personAddress.AddressId = reader.ReadField().GetValue<int>();
			personAddress.DateCreated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region product entity expression
    public partial class ProductEntity : EntityExpression<Product>
    {
        #region interface properties
        public Int32FieldExpression<Product> Id { get; private set; }
        public NullableEnumFieldExpression<Product, ProductCategoryType> ProductCategoryType { get; private set; }
        public StringFieldExpression<Product> Name { get; private set; }
        public NullableStringFieldExpression<Product> Description { get; private set; }
        public DoubleFieldExpression<Product> ListPrice { get; private set; }
        public DoubleFieldExpression<Product> Price { get; private set; }
        public Int32FieldExpression<Product> Quantity { get; private set; }
        public NullableByteArrayFieldExpression<Product> Image { get; private set; }
        public NullableDecimalFieldExpression<Product> Height { get; private set; }
        public NullableDecimalFieldExpression<Product> Width { get; private set; }
        public NullableDecimalFieldExpression<Product> Depth { get; private set; }
        public NullableDecimalFieldExpression<Product> Weight { get; private set; }
        public DecimalFieldExpression<Product> ShippingWeight { get; private set; }
        public NullableTimeSpanFieldExpression<Product> ValidStartTimeOfDayForPurchase { get; private set; }
        public NullableTimeSpanFieldExpression<Product> ValidEndTimeOfDayForPurchase { get; private set; }
        public DateTimeFieldExpression<Product> DateCreated { get; private set; }
        public DateTimeFieldExpression<Product> DateUpdated { get; private set; }
        #endregion

        #region constructors
        private ProductEntity() : base(null, null, null)
        {
        }

		public ProductEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private ProductEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Product>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.ProductCategoryType", ProductCategoryType = new NullableEnumFieldExpression<Product, ProductCategoryType>($"{identifier}.ProductCategoryType", this));
            Fields.Add($"{identifier}.Name", Name = new StringFieldExpression<Product>($"{identifier}.Name", this));
            Fields.Add($"{identifier}.Description", Description = new NullableStringFieldExpression<Product>($"{identifier}.Description", this));
            Fields.Add($"{identifier}.ListPrice", ListPrice = new DoubleFieldExpression<Product>($"{identifier}.ListPrice", this));
            Fields.Add($"{identifier}.Price", Price = new DoubleFieldExpression<Product>($"{identifier}.Price", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new Int32FieldExpression<Product>($"{identifier}.Quantity", this));
            Fields.Add($"{identifier}.Image", Image = new NullableByteArrayFieldExpression<Product>($"{identifier}.Image", this));
            Fields.Add($"{identifier}.Height", Height = new NullableDecimalFieldExpression<Product>($"{identifier}.Height", this));
            Fields.Add($"{identifier}.Width", Width = new NullableDecimalFieldExpression<Product>($"{identifier}.Width", this));
            Fields.Add($"{identifier}.Depth", Depth = new NullableDecimalFieldExpression<Product>($"{identifier}.Depth", this));
            Fields.Add($"{identifier}.Weight", Weight = new NullableDecimalFieldExpression<Product>($"{identifier}.Weight", this));
            Fields.Add($"{identifier}.ShippingWeight", ShippingWeight = new DecimalFieldExpression<Product>($"{identifier}.ShippingWeight", this));
            Fields.Add($"{identifier}.ValidStartTimeOfDayForPurchase", ValidStartTimeOfDayForPurchase = new NullableTimeSpanFieldExpression<Product>($"{identifier}.ValidStartTimeOfDayForPurchase", this));
            Fields.Add($"{identifier}.ValidEndTimeOfDayForPurchase", ValidEndTimeOfDayForPurchase = new NullableTimeSpanFieldExpression<Product>($"{identifier}.ValidEndTimeOfDayForPurchase", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Product>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Product>($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
        {
            return new ProductEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                ProductCategoryType,
                Name,
                Description,
                ListPrice,
                Price,
                Quantity,
                Image,
                Height,
                Width,
                Depth,
                Weight,
                ShippingWeight,
                ValidStartTimeOfDayForPurchase,
                ValidEndTimeOfDayForPurchase,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Product> GetInclusiveInsertExpression(Product product)
        {
            return new InsertExpressionSet<Product>(
				product,
                Id.Insert(product.Id),
                ProductCategoryType.Insert(product.ProductCategoryType),
                Name.Insert(product.Name),
                Description.Insert(product.Description),
                ListPrice.Insert(product.ListPrice),
                Price.Insert(product.Price),
                Quantity.Insert(product.Quantity),
                Image.Insert(product.Image),
                Height.Insert(product.Height),
                Width.Insert(product.Width),
                Depth.Insert(product.Depth),
                Weight.Insert(product.Weight),
                ShippingWeight.Insert(product.ShippingWeight),
                ValidStartTimeOfDayForPurchase.Insert(product.ValidStartTimeOfDayForPurchase),
                ValidEndTimeOfDayForPurchase.Insert(product.ValidEndTimeOfDayForPurchase),
                DateCreated.Insert(product.DateCreated),
                DateUpdated.Insert(product.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Product from, Product to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.ProductCategoryType != to.ProductCategoryType) { expr &= ProductCategoryType.Set(to.ProductCategoryType); }; 
			if (from.Name != to.Name) { expr &= Name.Set(to.Name); }; 
			if (from.Description != to.Description) { expr &= Description.Set(to.Description); }; 
			if (from.ListPrice != to.ListPrice) { expr &= ListPrice.Set(to.ListPrice); }; 
			if (from.Price != to.Price) { expr &= Price.Set(to.Price); }; 
			if (from.Quantity != to.Quantity) { expr &= Quantity.Set(to.Quantity); }; 
			if (from.Image != to.Image) { expr &= Image.Set(to.Image); }; 
			if (from.Height != to.Height) { expr &= Height.Set(to.Height); }; 
			if (from.Width != to.Width) { expr &= Width.Set(to.Width); }; 
			if (from.Depth != to.Depth) { expr &= Depth.Set(to.Depth); }; 
			if (from.Weight != to.Weight) { expr &= Weight.Set(to.Weight); }; 
			if (from.ShippingWeight != to.ShippingWeight) { expr &= ShippingWeight.Set(to.ShippingWeight); }; 
			if (from.ValidStartTimeOfDayForPurchase != to.ValidStartTimeOfDayForPurchase) { expr &= ValidStartTimeOfDayForPurchase.Set(to.ValidStartTimeOfDayForPurchase); }; 
			if (from.ValidEndTimeOfDayForPurchase != to.ValidEndTimeOfDayForPurchase) { expr &= ValidEndTimeOfDayForPurchase.Set(to.ValidEndTimeOfDayForPurchase); }; 
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }; 
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Product product, ISqlFieldReader reader)
        {
			product.Id = reader.ReadField().GetValue<int>();
			product.ProductCategoryType = reader.ReadField().GetValue<ProductCategoryType?>();
			product.Name = reader.ReadField().GetValue<string>();
			product.Description = reader.ReadField().GetValue<string>();
			product.ListPrice = reader.ReadField().GetValue<double>();
			product.Price = reader.ReadField().GetValue<double>();
			product.Quantity = reader.ReadField().GetValue<int>();
			product.Image = reader.ReadField().GetValue<byte[]>();
			product.Height = reader.ReadField().GetValue<decimal?>();
			product.Width = reader.ReadField().GetValue<decimal?>();
			product.Depth = reader.ReadField().GetValue<decimal?>();
			product.Weight = reader.ReadField().GetValue<decimal?>();
			product.ShippingWeight = reader.ReadField().GetValue<decimal>();
			product.ValidStartTimeOfDayForPurchase = reader.ReadField().GetValue<TimeSpan?>();
			product.ValidEndTimeOfDayForPurchase = reader.ReadField().GetValue<TimeSpan?>();
			product.DateCreated = reader.ReadField().GetValue<DateTime>();
			product.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region purchase entity expression
    public partial class PurchaseEntity : EntityExpression<Purchase>
    {
        #region interface properties
        public Int32FieldExpression<Purchase> Id { get; private set; }
        public Int32FieldExpression<Purchase> PersonId { get; private set; }
        public DoubleFieldExpression<Purchase> TotalPurchaseAmount { get; private set; }
        public DateTimeFieldExpression<Purchase> PurchaseDate { get; private set; }
        public NullableDateTimeFieldExpression<Purchase> ShipDate { get; private set; }
        public NullableDateTimeFieldExpression<Purchase> ExpectedDeliveryDate { get; private set; }
        public NullableGuidFieldExpression<Purchase> TrackingIdentifier { get; private set; }
        public EnumFieldExpression<Purchase, PaymentMethodType> PaymentMethodType { get; private set; }
        public NullableEnumFieldExpression<Purchase, PaymentSourceType> PaymentSourceType { get; private set; }
        public DateTimeFieldExpression<Purchase> DateCreated { get; private set; }
        public DateTimeFieldExpression<Purchase> DateUpdated { get; private set; }
        #endregion

        #region constructors
        private PurchaseEntity() : base(null, null, null)
        {
        }

		public PurchaseEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PurchaseEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Purchase>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new Int32FieldExpression<Purchase>($"{identifier}.PersonId", this));
            Fields.Add($"{identifier}.TotalPurchaseAmount", TotalPurchaseAmount = new DoubleFieldExpression<Purchase>($"{identifier}.TotalPurchaseAmount", this));
            Fields.Add($"{identifier}.PurchaseDate", PurchaseDate = new DateTimeFieldExpression<Purchase>($"{identifier}.PurchaseDate", this));
            Fields.Add($"{identifier}.ShipDate", ShipDate = new NullableDateTimeFieldExpression<Purchase>($"{identifier}.ShipDate", this));
            Fields.Add($"{identifier}.ExpectedDeliveryDate", ExpectedDeliveryDate = new NullableDateTimeFieldExpression<Purchase>($"{identifier}.ExpectedDeliveryDate", this));
            Fields.Add($"{identifier}.TrackingIdentifier", TrackingIdentifier = new NullableGuidFieldExpression<Purchase>($"{identifier}.TrackingIdentifier", this));
            Fields.Add($"{identifier}.PaymentMethodType", PaymentMethodType = new EnumFieldExpression<Purchase, PaymentMethodType>($"{identifier}.PaymentMethodType", this));
            Fields.Add($"{identifier}.PaymentSourceType", PaymentSourceType = new NullableEnumFieldExpression<Purchase, PaymentSourceType>($"{identifier}.PaymentSourceType", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Purchase>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Purchase>($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
        {
            return new PurchaseEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                PersonId,
                TotalPurchaseAmount,
                PurchaseDate,
                ShipDate,
                ExpectedDeliveryDate,
                TrackingIdentifier,
                PaymentMethodType,
                PaymentSourceType,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Purchase> GetInclusiveInsertExpression(Purchase purchase)
        {
            return new InsertExpressionSet<Purchase>(
				purchase,
                Id.Insert(purchase.Id),
                PersonId.Insert(purchase.PersonId),
                TotalPurchaseAmount.Insert(purchase.TotalPurchaseAmount),
                PurchaseDate.Insert(purchase.PurchaseDate),
                ShipDate.Insert(purchase.ShipDate),
                ExpectedDeliveryDate.Insert(purchase.ExpectedDeliveryDate),
                TrackingIdentifier.Insert(purchase.TrackingIdentifier),
                PaymentMethodType.Insert(purchase.PaymentMethodType),
                PaymentSourceType.Insert(purchase.PaymentSourceType),
                DateCreated.Insert(purchase.DateCreated),
                DateUpdated.Insert(purchase.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Purchase from, Purchase to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.PersonId != to.PersonId) { expr &= PersonId.Set(to.PersonId); }; 
			if (from.TotalPurchaseAmount != to.TotalPurchaseAmount) { expr &= TotalPurchaseAmount.Set(to.TotalPurchaseAmount); }; 
			if (from.PurchaseDate != to.PurchaseDate) { expr &= PurchaseDate.Set(to.PurchaseDate); }; 
			if (from.ShipDate != to.ShipDate) { expr &= ShipDate.Set(to.ShipDate); }; 
			if (from.ExpectedDeliveryDate != to.ExpectedDeliveryDate) { expr &= ExpectedDeliveryDate.Set(to.ExpectedDeliveryDate); }; 
			if (from.TrackingIdentifier != to.TrackingIdentifier) { expr &= TrackingIdentifier.Set(to.TrackingIdentifier); }; 
			if (from.PaymentMethodType != to.PaymentMethodType) { expr &= PaymentMethodType.Set(to.PaymentMethodType); }; 
			if (from.PaymentSourceType != to.PaymentSourceType) { expr &= PaymentSourceType.Set(to.PaymentSourceType); }; 
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }; 
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Purchase purchase, ISqlFieldReader reader)
        {
			purchase.Id = reader.ReadField().GetValue<int>();
			purchase.PersonId = reader.ReadField().GetValue<int>();
			purchase.TotalPurchaseAmount = reader.ReadField().GetValue<double>();
			purchase.PurchaseDate = reader.ReadField().GetValue<DateTime>();
			purchase.ShipDate = reader.ReadField().GetValue<DateTime?>();
			purchase.ExpectedDeliveryDate = reader.ReadField().GetValue<DateTime?>();
			purchase.TrackingIdentifier = reader.ReadField().GetValue<Guid?>();
			purchase.PaymentMethodType = reader.ReadField().GetValue<PaymentMethodType>();
			purchase.PaymentSourceType = reader.ReadField().GetValue<PaymentSourceType?>();
			purchase.DateCreated = reader.ReadField().GetValue<DateTime>();
			purchase.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region purchase line entity expression
    public partial class PurchaseLineEntity : EntityExpression<PurchaseLine>
    {
        #region interface properties
        public Int32FieldExpression<PurchaseLine> Id { get; private set; }
        public Int32FieldExpression<PurchaseLine> PurchaseId { get; private set; }
        public Int32FieldExpression<PurchaseLine> ProductId { get; private set; }
        public DecimalFieldExpression<PurchaseLine> PurchasePrice { get; private set; }
        public Int32FieldExpression<PurchaseLine> Quantity { get; private set; }
        public DateTimeFieldExpression<PurchaseLine> DateCreated { get; private set; }
        public DateTimeFieldExpression<PurchaseLine> DateUpdated { get; private set; }
        #endregion

        #region constructors
        private PurchaseLineEntity() : base(null, null, null)
        {
        }

		public PurchaseLineEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PurchaseLineEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<PurchaseLine>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PurchaseId", PurchaseId = new Int32FieldExpression<PurchaseLine>($"{identifier}.PurchaseId", this));
            Fields.Add($"{identifier}.ProductId", ProductId = new Int32FieldExpression<PurchaseLine>($"{identifier}.ProductId", this));
            Fields.Add($"{identifier}.PurchasePrice", PurchasePrice = new DecimalFieldExpression<PurchaseLine>($"{identifier}.PurchasePrice", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new Int32FieldExpression<PurchaseLine>($"{identifier}.Quantity", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<PurchaseLine>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<PurchaseLine>($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
        {
            return new PurchaseLineEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                PurchaseId,
                ProductId,
                PurchasePrice,
                Quantity,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<PurchaseLine> GetInclusiveInsertExpression(PurchaseLine purchaseLine)
        {
            return new InsertExpressionSet<PurchaseLine>(
				purchaseLine,
                Id.Insert(purchaseLine.Id),
                PurchaseId.Insert(purchaseLine.PurchaseId),
                ProductId.Insert(purchaseLine.ProductId),
                PurchasePrice.Insert(purchaseLine.PurchasePrice),
                Quantity.Insert(purchaseLine.Quantity),
                DateCreated.Insert(purchaseLine.DateCreated),
                DateUpdated.Insert(purchaseLine.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PurchaseLine from, PurchaseLine to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.PurchaseId != to.PurchaseId) { expr &= PurchaseId.Set(to.PurchaseId); }; 
			if (from.ProductId != to.ProductId) { expr &= ProductId.Set(to.ProductId); }; 
			if (from.PurchasePrice != to.PurchasePrice) { expr &= PurchasePrice.Set(to.PurchasePrice); }; 
			if (from.Quantity != to.Quantity) { expr &= Quantity.Set(to.Quantity); }; 
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }; 
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(PurchaseLine purchaseLine, ISqlFieldReader reader)
        {
			purchaseLine.Id = reader.ReadField().GetValue<int>();
			purchaseLine.PurchaseId = reader.ReadField().GetValue<int>();
			purchaseLine.ProductId = reader.ReadField().GetValue<int>();
			purchaseLine.PurchasePrice = reader.ReadField().GetValue<decimal>();
			purchaseLine.Quantity = reader.ReadField().GetValue<int>();
			purchaseLine.DateCreated = reader.ReadField().GetValue<DateTime>();
			purchaseLine.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region person total purchases view entity expression
    public partial class PersonTotalPurchasesViewEntity : EntityExpression<PersonTotalPurchasesView>
    {
        #region interface properties
        public Int32FieldExpression<PersonTotalPurchasesView> Id { get; private set; }
        public NullableDoubleFieldExpression<PersonTotalPurchasesView> TotalAmount { get; private set; }
        public NullableInt32FieldExpression<PersonTotalPurchasesView> TotalCount { get; private set; }
        #endregion

        #region constructors
        private PersonTotalPurchasesViewEntity() : base(null, null, null)
        {
        }

		public PersonTotalPurchasesViewEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonTotalPurchasesViewEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<PersonTotalPurchasesView>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.TotalAmount", TotalAmount = new NullableDoubleFieldExpression<PersonTotalPurchasesView>($"{identifier}.TotalAmount", this));
            Fields.Add($"{identifier}.TotalCount", TotalCount = new NullableInt32FieldExpression<PersonTotalPurchasesView>($"{identifier}.TotalCount", this));
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string name)
        {
            return new PersonTotalPurchasesViewEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                TotalAmount,
                TotalCount
            );
        }
		
        protected override InsertExpressionSet<PersonTotalPurchasesView> GetInclusiveInsertExpression(PersonTotalPurchasesView personTotalPurchasesView)
        {
            return new InsertExpressionSet<PersonTotalPurchasesView>(
				personTotalPurchasesView,
                Id.Insert(personTotalPurchasesView.Id),
                TotalAmount.Insert(personTotalPurchasesView.TotalAmount),
                TotalCount.Insert(personTotalPurchasesView.TotalCount)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView from, PersonTotalPurchasesView to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.Id != to.Id) { expr &= Id.Set(to.Id); }; 
			if (from.TotalAmount != to.TotalAmount) { expr &= TotalAmount.Set(to.TotalAmount); }; 
			if (from.TotalCount != to.TotalCount) { expr &= TotalCount.Set(to.TotalCount); }; 
			
            return expr;
        }

        protected override void HydrateEntity(PersonTotalPurchasesView personTotalPurchasesView, ISqlFieldReader reader)
        {
			personTotalPurchasesView.Id = reader.ReadField().GetValue<int>();
			personTotalPurchasesView.TotalAmount = reader.ReadField().GetValue<double?>();
			personTotalPurchasesView.TotalCount = reader.ReadField().GetValue<int?>();
        }
		#endregion
    }
    #endregion

    #region dbo
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
#pragma warning disable IDE1006 // Naming Styles
    public partial class dbo
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        #region internals
        private static readonly dboSchemaExpression _schema = new dboSchemaExpression("dbo");
        #endregion

        #region interface
        public static AddressEntity Address => _schema.Address;
        public static PersonEntity Person => _schema.Person;
        public static PersonAddressEntity PersonAddress => _schema.PersonAddress;
        public static ProductEntity Product => _schema.Product;
        public static PurchaseEntity Purchase => _schema.Purchase;
        public static PurchaseLineEntity PurchaseLine => _schema.PurchaseLine;
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView => _schema.PersonTotalPurchasesView;
        #endregion

        #region constructors
        private dbo()
        { }
        #endregion
    }
    #endregion
}
namespace DbEx.secDataService
{
	using DbEx.secData;

    #region sec schema expression
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

    #region person entity expression
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region interface properties
        public Int32FieldExpression<Person> Id { get; private set; }
        public StringFieldExpression<Person> SSN { get; private set; }
        public DateTimeOffsetFieldExpression<Person> DateCreated { get; private set; }
        public DateTimeOffsetFieldExpression<Person> DateUpdated { get; private set; }
        #endregion

        #region constructors
        private PersonEntity() : base(null, null, null)
        {
        }

		public PersonEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Person>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.SSN", SSN = new StringFieldExpression<Person>($"{identifier}.SSN", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeOffsetFieldExpression<Person>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeOffsetFieldExpression<Person>($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.identifier, this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                SSN,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(
				person,
                Id.Insert(person.Id),
                SSN.Insert(person.SSN),
                DateCreated.Insert(person.DateCreated),
                DateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.SSN != to.SSN) { expr &= SSN.Set(to.SSN); }; 
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }; 
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader)
        {
			person.Id = reader.ReadField().GetValue<int>();
			person.SSN = reader.ReadField().GetValue<string>();
			person.DateCreated = reader.ReadField().GetValue<DateTimeOffset>();
			person.DateUpdated = reader.ReadField().GetValue<DateTimeOffset>();
        }
		#endregion
    }
    #endregion

    #region sec
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
#pragma warning disable IDE1006 // Naming Styles
    public partial class sec
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        #region internals
        private static readonly secSchemaExpression _schema = new secSchemaExpression("sec");
        #endregion

        #region interface
        public static PersonEntity Person => _schema.Person;
        #endregion

        #region constructors
        private sec()
        { }
        #endregion
    }
    #endregion
}
