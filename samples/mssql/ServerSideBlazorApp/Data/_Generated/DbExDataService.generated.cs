using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ServerSideBlazorApp.DataService
{
    #region runtime db
    public abstract class CRMDatabaseRuntimeSqlDatabase : IRuntimeSqlDatabase
    {
        #region internals
        protected static RuntimeSqlDatabaseConfiguration config = new RuntimeSqlDatabaseConfiguration();
        protected static MsSqlQueryExpressionBuilderFactory expressionBuilderFactory = new MsSqlQueryExpressionBuilderFactory();
        #endregion

        #region interface
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabase.Configuration => config;
        #endregion

        #region methods
        #region select one
        public static SelectEntity<TEntity> SelectOne<TEntity>()
            where TEntity : class, IDbEntity
            => expressionBuilderFactory.CreateSelectEntityBuilder<TEntity>(config);

        public static SelectValue<TEnum> SelectOne<TEnum>(EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectValueBuilder<TEnum>(config, field);

        public static SelectValue<TEnum?> SelectOne<TEnum>(NullableEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectValueBuilder<TEnum>(config, field);

        public static SelectValue<object> SelectOne(AnyObjectElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<bool> SelectOne(BooleanElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<bool?> SelectOne(NullableBooleanElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<byte> SelectOne(ByteElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<byte?> SelectOne(NullableByteElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<byte[]> SelectOne(ByteArrayElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<byte[]> SelectOne(NullableByteArrayElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<DateTime> SelectOne(DateTimeElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<DateTime?> SelectOne(NullableDateTimeElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<DateTimeOffset> SelectOne(DateTimeOffsetElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<DateTimeOffset?> SelectOne(NullableDateTimeOffsetElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<decimal> SelectOne(DecimalElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<decimal?> SelectOne(NullableDecimalElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<double> SelectOne(DoubleElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<double?> SelectOne(NullableDoubleElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<Guid> SelectOne(GuidElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<Guid?> SelectOne(NullableGuidElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<short> SelectOne(Int16Element field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<short?> SelectOne(NullableInt16Element field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<int> SelectOne(Int32Element field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<int?> SelectOne(NullableInt32Element field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<long> SelectOne(Int64Element field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<long?> SelectOne(NullableInt64Element field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<float> SelectOne(SingleElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<float?> SelectOne(NullableSingleElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<string> SelectOne(StringElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<string> SelectOne(NullableStringElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<TimeSpan> SelectOne(TimeSpanElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<TimeSpan?> SelectOne(NullableTimeSpanElement field)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field);

        public static SelectValue<ExpandoObject> SelectOne(IExpressionElement field1, IExpressionElement field2, params IExpressionElement[] fields)
            => expressionBuilderFactory.CreateSelectValueBuilder(config, field1, field2, fields);
        #endregion

        #region select many
        public static SelectEntities<TEntity> SelectMany<TEntity>()
           where TEntity : class, IDbEntity
           => expressionBuilderFactory.CreateSelectEntitiesBuilder<TEntity>(config);

        public static SelectValues<TEnum> SelectMany<TEnum>(EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectValuesBuilder<TEnum>(config, field);

        public static SelectValues<TEnum?> SelectMany<TEnum>(NullableEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectValuesBuilder<TEnum>(config, field);

        public static SelectValues<object> SelectMany(AnyObjectElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<bool> SelectMany(BooleanElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<bool?> SelectMany(NullableBooleanElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<byte> SelectMany(ByteElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<byte?> SelectMany(NullableByteElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<byte[]> SelectMany(ByteArrayElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<byte[]> SelectMany(NullableByteArrayElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<DateTime> SelectMany(DateTimeElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<DateTime?> SelectMany(NullableDateTimeElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<DateTimeOffset> SelectMany(DateTimeOffsetElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<DateTimeOffset?> SelectMany(NullableDateTimeOffsetElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<decimal> SelectMany(DecimalElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<decimal?> SelectMany(NullableDecimalElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<double> SelectMany(DoubleElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<double?> SelectMany(NullableDoubleElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<Guid> SelectMany(GuidElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<Guid?> SelectMany(NullableGuidElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<short> SelectMany(Int16Element field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<short?> SelectMany(NullableInt16Element field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<int> SelectMany(Int32Element field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<int?> SelectMany(NullableInt32Element field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<long> SelectMany(Int64Element field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<long?> SelectMany(NullableInt64Element field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<float> SelectMany(SingleElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<float?> SelectMany(NullableSingleElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<string> SelectMany(StringElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<string> SelectMany(NullableStringElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<TimeSpan> SelectMany(TimeSpanElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<TimeSpan?> SelectMany(NullableTimeSpanElement field)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field);

        public static SelectValues<ExpandoObject> SelectMany(AnyElement field1, AnyElement field2, params AnyElement[] fields)
            => expressionBuilderFactory.CreateSelectValuesBuilder(config, field1, field2, fields);
        #endregion

        #region update
        public static UpdateEntities Update(params EntityFieldAssignment[] fields)
            => expressionBuilderFactory.CreateUpdateExpressionBuilder(config, fields);

        public static UpdateEntities Update(IList<EntityFieldAssignment> fields)
            => expressionBuilderFactory.CreateUpdateExpressionBuilder(config, fields);

        public static UpdateEntities<TEntity> Update<TEntity>(TEntity updateValuesInThisEntity, TEntity fromValuesInThisEntity)
            where TEntity : class, IDbEntity
            => expressionBuilderFactory.CreateUpdateExpressionBuilder<TEntity>(config, updateValuesInThisEntity, fromValuesInThisEntity);     
        #endregion

        #region delete
        public static DeleteEntities Delete()
            => expressionBuilderFactory.CreateDeleteExpressionBulder(config);
        #endregion

        #region insert
        public static InsertEntity<TEntity> Insert<TEntity>(TEntity entity)
            where TEntity : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, entity);

        public static InsertEntities<TEntity> InsertMany<TEntity>(params TEntity[] entities)
            where TEntity : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, entities);

        public static InsertEntities<TEntity> InsertMany<TEntity>(IList<TEntity> entities)
            where TEntity : class, IDbEntity
            => expressionBuilderFactory.CreateInsertExpressionBuilder(config, entities);
        #endregion

        #region get connection
        public static ISqlConnection GetConnection()
            => new SqlConnector(config.ConnectionFactory);
        #pragma warning disable IDE1006 // Naming Styles
        #pragma warning restore IDE1006 // Naming Styles
        #endregion
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
        public static AliasExpression alias(string tableName, string fieldName)
            => new AliasExpression(tableName, fieldName);
        #endregion
    }
    #endregion

    #region runtime environment db
    public class CRMDatabase : RuntimeEnvironmentSqlDatabase
    {
        public CRMDatabase() : base(new db(), new SqlDatabaseMetadataProvider(new CRMDatabaseSqlDatabaseMetadata("CRMDatabase", "MsSqlDbExTest")))
        { }
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
	using ServerSideBlazorApp.dboData;

    #region dbo schema expression
#pragma warning disable IDE1006 // Naming Styles
    public class dboSchemaExpression : SchemaExpression
#pragma warning restore IDE1006 // Naming Styles
    {
        #region interface
        public AddressEntity Address { get; private set; }
        public CustomerEntity Customer { get; private set; }
        public CustomerAddressEntity CustomerAddress { get; private set; }
        public ProductEntity Product { get; private set; }
        public PurchaseEntity Purchase { get; private set; }
        public PurchaseLineEntity PurchaseLine { get; private set; }
        public PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get; private set; }
        #endregion

        #region constructors
        public dboSchemaExpression(string identifier) : base(identifier, null)
        {
            Entities.Add($"{identifier}.Address", Address = new AddressEntity($"{identifier}.Address", this));
            Entities.Add($"{identifier}.Person", Customer = new CustomerEntity($"{identifier}.Person", this));
            Entities.Add($"{identifier}.Person_Address", CustomerAddress = new CustomerAddressEntity($"{identifier}.Person_Address", this));
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
        public IdField Id { get; private set; }
        public AddressTypeField AddressType { get; private set; }
        public Line1Field Line1 { get; private set; }
        public Line2Field Line2 { get; private set; }
        public CityField City { get; private set; }
        public StateField State { get; private set; }
        public ZipField Zip { get; private set; }
        public DateCreatedField DateCreated { get; private set; }
        public DateUpdatedField DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.AddressType", AddressType = new AddressTypeField($"{identifier}.AddressType", this));
            Fields.Add($"{identifier}.Line1", Line1 = new Line1Field($"{identifier}.Line1", this));
            Fields.Add($"{identifier}.Line2", Line2 = new Line2Field($"{identifier}.Line2", this));
            Fields.Add($"{identifier}.City", City = new CityField($"{identifier}.City", this));
            Fields.Add($"{identifier}.State", State = new StateField($"{identifier}.State", this));
            Fields.Add($"{identifier}.Zip", Zip = new ZipField($"{identifier}.Zip", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", this));
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
            return new InsertExpressionSet<Address>(address, 
                new InsertExpression<int>(Id, address.Id),
                new InsertExpression<ServerSideBlazorApp.Data.AddressType?>(AddressType, address.AddressType),
                new InsertExpression<string>(Line1, address.Line1),
                new InsertExpression<string>(Line2, address.Line2),
                new InsertExpression<string>(City, address.City),
                new InsertExpression<string>(State, address.State),
                new InsertExpression<string>(Zip, address.Zip),
                new InsertExpression<DateTime>(DateCreated, address.DateCreated),
                new InsertExpression<DateTime>(DateUpdated, address.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Address target, Address source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.AddressType != source.AddressType) { expr &= AddressType.Set(source.AddressType); }
            if (target.Line1 != source.Line1) { expr &= Line1.Set(source.Line1); }
            if (target.Line2 != source.Line2) { expr &= Line2.Set(source.Line2); }
            if (target.City != source.City) { expr &= City.Set(source.City); }
            if (target.State != source.State) { expr &= State.Set(source.State); }
            if (target.Zip != source.Zip) { expr &= Zip.Set(source.Zip); }
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }

            return expr;
        }

        protected override void HydrateEntity(Address address, ISqlFieldReader reader)
        {
			address.Id = reader.ReadField().GetValue<int>();
			address.AddressType = reader.ReadField().GetValue<ServerSideBlazorApp.Data.AddressType?>();
			address.Line1 = reader.ReadField().GetValue<string>();
			address.Line2 = reader.ReadField().GetValue<string>();
			address.City = reader.ReadField().GetValue<string>();
			address.State = reader.ReadField().GetValue<string>();
			address.Zip = reader.ReadField().GetValue<string>();
			address.DateCreated = reader.ReadField().GetValue<DateTime>();
			address.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Address>
        {
            #region constructors
            public IdField(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region address type field expression
        public partial class AddressTypeField : NullableEnumFieldExpression<Address, ServerSideBlazorApp.Data.AddressType>
        {
            #region constructors
            public AddressTypeField(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private AddressTypeField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableEnumElement<ServerSideBlazorApp.Data.AddressType> As(string alias)
                => new AddressTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(ServerSideBlazorApp.Data.AddressType value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.AddressType>(value));
            public AssignmentExpression Set(EnumElement<ServerSideBlazorApp.Data.AddressType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(ServerSideBlazorApp.Data.AddressType? value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.AddressType?>(value));
            public AssignmentExpression Set(NullableEnumElement<ServerSideBlazorApp.Data.AddressType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region line1 field expression
        public partial class Line1Field : StringFieldExpression<Address>
        {
            #region constructors
            public Line1Field(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private Line1Field(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new Line1Field(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region line2 field expression
        public partial class Line2Field : NullableStringFieldExpression<Address>
        {
            #region constructors
            public Line2Field(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private Line2Field(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableStringElement As(string alias)
                => new Line2Field(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(NullableStringElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region city field expression
        public partial class CityField : StringFieldExpression<Address>
        {
            #region constructors
            public CityField(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private CityField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new CityField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region state field expression
        public partial class StateField : StringFieldExpression<Address>
        {
            #region constructors
            public StateField(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private StateField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new StateField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region zip field expression
        public partial class ZipField : StringFieldExpression<Address>
        {
            #region constructors
            public ZipField(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private ZipField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new ZipField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Address>
        {
            #region constructors
            public DateCreatedField(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private DateCreatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Address>
        {
            #region constructors
            public DateUpdatedField(string identifier, AddressEntity entity) : base(identifier, entity)
            {

            }

            private DateUpdatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateUpdatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #endregion
    }
    #endregion

    #region customer entity expression

    public partial class CustomerEntity : EntityExpression<Customer>
    {
        #region interface properties
        public IdField Id { get; private set; }
        public FirstNameField FirstName { get; private set; }
        public LastNameField LastName { get; private set; }
        public BirthDateField BirthDate { get; private set; }
        public GenderTypeField GenderType { get; private set; }
        public CreditLimitField CreditLimit { get; private set; }
        public YearOfLastCreditLimitReviewField YearOfLastCreditLimitReview { get; private set; }
        public DateCreatedField DateCreated { get; private set; }
        public DateUpdatedField DateUpdated { get; private set; }
        #endregion

        #region constructors
        private CustomerEntity() : base(null, null, null)
        {
        }

		public CustomerEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private CustomerEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.FirstName", FirstName = new FirstNameField($"{identifier}.FirstName", this));
            Fields.Add($"{identifier}.LastName", LastName = new LastNameField($"{identifier}.LastName", this));
            Fields.Add($"{identifier}.BirthDate", BirthDate = new BirthDateField($"{identifier}.BirthDate", this));
            Fields.Add($"{identifier}.GenderType", GenderType = new GenderTypeField($"{identifier}.GenderType", this));
            Fields.Add($"{identifier}.CreditLimit", CreditLimit = new CreditLimitField($"{identifier}.CreditLimit", this));
            Fields.Add($"{identifier}.YearOfLastCreditLimitReview", YearOfLastCreditLimitReview = new YearOfLastCreditLimitReviewField($"{identifier}.YearOfLastCreditLimitReview", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public CustomerEntity As(string name)
        {
            return new CustomerEntity(this.identifier, this.schema, name);
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
		
        protected override InsertExpressionSet<Customer> GetInclusiveInsertExpression(Customer customer)
        {
            return new InsertExpressionSet<Customer>(customer, 
                new InsertExpression<int>(Id, customer.Id),
                new InsertExpression<string>(FirstName, customer.FirstName),
                new InsertExpression<string>(LastName, customer.LastName),
                new InsertExpression<DateTime?>(BirthDate, customer.BirthDate),
                new InsertExpression<ServerSideBlazorApp.Data.GenderType>(GenderType, customer.GenderType),
                new InsertExpression<int?>(CreditLimit, customer.CreditLimit),
                new InsertExpression<int?>(YearOfLastCreditLimitReview, customer.YearOfLastCreditLimitReview),
                new InsertExpression<DateTime>(DateCreated, customer.DateCreated),
                new InsertExpression<DateTime>(DateUpdated, customer.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Customer target, Customer source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.FirstName != source.FirstName) { expr &= FirstName.Set(source.FirstName); }
            if (target.LastName != source.LastName) { expr &= LastName.Set(source.LastName); }
            if (target.BirthDate != source.BirthDate) { expr &= BirthDate.Set(source.BirthDate); }
            if (target.GenderType != source.GenderType) { expr &= GenderType.Set(source.GenderType); }
            if (target.CreditLimit != source.CreditLimit) { expr &= CreditLimit.Set(source.CreditLimit); }
            if (target.YearOfLastCreditLimitReview != source.YearOfLastCreditLimitReview) { expr &= YearOfLastCreditLimitReview.Set(source.YearOfLastCreditLimitReview); }
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }

            return expr;
        }

        protected override void HydrateEntity(Customer customer, ISqlFieldReader reader)
        {
			customer.Id = reader.ReadField().GetValue<int>();
			customer.FirstName = reader.ReadField().GetValue<string>();
			customer.LastName = reader.ReadField().GetValue<string>();
			customer.BirthDate = reader.ReadField().GetValue<DateTime?>();
			customer.GenderType = reader.ReadField().GetValue<ServerSideBlazorApp.Data.GenderType>();
			customer.CreditLimit = reader.ReadField().GetValue<int?>();
			customer.YearOfLastCreditLimitReview = reader.ReadField().GetValue<int?>();
			customer.DateCreated = reader.ReadField().GetValue<DateTime>();
			customer.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Customer>
        {
            #region constructors
            public IdField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region first name field expression
        public partial class FirstNameField : StringFieldExpression<Customer>
        {
            #region constructors
            public FirstNameField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private FirstNameField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new FirstNameField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region last name field expression
        public partial class LastNameField : StringFieldExpression<Customer>
        {
            #region constructors
            public LastNameField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private LastNameField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new LastNameField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region birth date field expression
        public partial class BirthDateField : NullableDateTimeFieldExpression<Customer>
        {
            #region constructors
            public BirthDateField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private BirthDateField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDateTimeElement As(string alias)
                => new BirthDateField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value));
            public AssignmentExpression Set(NullableDateTimeElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region gender type field expression
        public partial class GenderTypeField : EnumFieldExpression<Customer, ServerSideBlazorApp.Data.GenderType>
        {
            #region constructors
            public GenderTypeField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private GenderTypeField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override EnumElement<ServerSideBlazorApp.Data.GenderType> As(string alias)
                => new GenderTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(ServerSideBlazorApp.Data.GenderType value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.GenderType>(value));
            public AssignmentExpression Set(EnumElement<ServerSideBlazorApp.Data.GenderType> value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region credit limit field expression
        public partial class CreditLimitField : NullableInt32FieldExpression<Customer>
        {
            #region constructors
            public CreditLimitField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private CreditLimitField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableInt32Element As(string alias)
                => new CreditLimitField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value));
            public AssignmentExpression Set(NullableInt32Element value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region year of last credit limit review field expression
        public partial class YearOfLastCreditLimitReviewField : NullableInt32FieldExpression<Customer>
        {
            #region constructors
            public YearOfLastCreditLimitReviewField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private YearOfLastCreditLimitReviewField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableInt32Element As(string alias)
                => new YearOfLastCreditLimitReviewField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value));
            public AssignmentExpression Set(NullableInt32Element value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Customer>
        {
            #region constructors
            public DateCreatedField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private DateCreatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Customer>
        {
            #region constructors
            public DateUpdatedField(string identifier, CustomerEntity entity) : base(identifier, entity)
            {

            }

            private DateUpdatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateUpdatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #endregion
    }
    #endregion

    #region customer address entity expression

    public partial class CustomerAddressEntity : EntityExpression<CustomerAddress>
    {
        #region interface properties
        public IdField Id { get; private set; }
        public PersonIdField PersonId { get; private set; }
        public AddressIdField AddressId { get; private set; }
        public DateCreatedField DateCreated { get; private set; }
        #endregion

        #region constructors
        private CustomerAddressEntity() : base(null, null, null)
        {
        }

		public CustomerAddressEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private CustomerAddressEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", this));
            Fields.Add($"{identifier}.AddressId", AddressId = new AddressIdField($"{identifier}.AddressId", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
        }
        #endregion

        #region methods
        public CustomerAddressEntity As(string name)
        {
            return new CustomerAddressEntity(this.identifier, this.schema, name);
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
		
        protected override InsertExpressionSet<CustomerAddress> GetInclusiveInsertExpression(CustomerAddress customerAddress)
        {
            return new InsertExpressionSet<CustomerAddress>(customerAddress, 
                new InsertExpression<int>(Id, customerAddress.Id),
                new InsertExpression<int>(PersonId, customerAddress.PersonId),
                new InsertExpression<int>(AddressId, customerAddress.AddressId),
                new InsertExpression<DateTime>(DateCreated, customerAddress.DateCreated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(CustomerAddress target, CustomerAddress source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.AddressId != source.AddressId) { expr &= AddressId.Set(source.AddressId); }
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }

            return expr;
        }

        protected override void HydrateEntity(CustomerAddress customerAddress, ISqlFieldReader reader)
        {
			customerAddress.Id = reader.ReadField().GetValue<int>();
			customerAddress.PersonId = reader.ReadField().GetValue<int>();
			customerAddress.AddressId = reader.ReadField().GetValue<int>();
			customerAddress.DateCreated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<CustomerAddress>
        {
            #region constructors
            public IdField(string identifier, CustomerAddressEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<CustomerAddress>
        {
            #region constructors
            public PersonIdField(string identifier, CustomerAddressEntity entity) : base(identifier, entity)
            {

            }

            private PersonIdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new PersonIdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region address id field expression
        public partial class AddressIdField : Int32FieldExpression<CustomerAddress>
        {
            #region constructors
            public AddressIdField(string identifier, CustomerAddressEntity entity) : base(identifier, entity)
            {

            }

            private AddressIdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new AddressIdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<CustomerAddress>
        {
            #region constructors
            public DateCreatedField(string identifier, CustomerAddressEntity entity) : base(identifier, entity)
            {

            }

            private DateCreatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #endregion
    }
    #endregion

    #region product entity expression

    public partial class ProductEntity : EntityExpression<Product>
    {
        #region interface properties
        public IdField Id { get; private set; }
        public ProductCategoryTypeField ProductCategoryType { get; private set; }
        public NameField Name { get; private set; }
        public DescriptionField Description { get; private set; }
        public ListPriceField ListPrice { get; private set; }
        public PriceField Price { get; private set; }
        public QuantityField Quantity { get; private set; }
        public ImageField Image { get; private set; }
        public HeightField Height { get; private set; }
        public WidthField Width { get; private set; }
        public DepthField Depth { get; private set; }
        public WeightField Weight { get; private set; }
        public ShippingWeightField ShippingWeight { get; private set; }
        public ValidStartTimeOfDayForPurchaseField ValidStartTimeOfDayForPurchase { get; private set; }
        public ValidEndTimeOfDayForPurchaseField ValidEndTimeOfDayForPurchase { get; private set; }
        public DateCreatedField DateCreated { get; private set; }
        public DateUpdatedField DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.ProductCategoryType", ProductCategoryType = new ProductCategoryTypeField($"{identifier}.ProductCategoryType", this));
            Fields.Add($"{identifier}.Name", Name = new NameField($"{identifier}.Name", this));
            Fields.Add($"{identifier}.Description", Description = new DescriptionField($"{identifier}.Description", this));
            Fields.Add($"{identifier}.ListPrice", ListPrice = new ListPriceField($"{identifier}.ListPrice", this));
            Fields.Add($"{identifier}.Price", Price = new PriceField($"{identifier}.Price", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new QuantityField($"{identifier}.Quantity", this));
            Fields.Add($"{identifier}.Image", Image = new ImageField($"{identifier}.Image", this));
            Fields.Add($"{identifier}.Height", Height = new HeightField($"{identifier}.Height", this));
            Fields.Add($"{identifier}.Width", Width = new WidthField($"{identifier}.Width", this));
            Fields.Add($"{identifier}.Depth", Depth = new DepthField($"{identifier}.Depth", this));
            Fields.Add($"{identifier}.Weight", Weight = new WeightField($"{identifier}.Weight", this));
            Fields.Add($"{identifier}.ShippingWeight", ShippingWeight = new ShippingWeightField($"{identifier}.ShippingWeight", this));
            Fields.Add($"{identifier}.ValidStartTimeOfDayForPurchase", ValidStartTimeOfDayForPurchase = new ValidStartTimeOfDayForPurchaseField($"{identifier}.ValidStartTimeOfDayForPurchase", this));
            Fields.Add($"{identifier}.ValidEndTimeOfDayForPurchase", ValidEndTimeOfDayForPurchase = new ValidEndTimeOfDayForPurchaseField($"{identifier}.ValidEndTimeOfDayForPurchase", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", this));
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
            return new InsertExpressionSet<Product>(product, 
                new InsertExpression<int>(Id, product.Id),
                new InsertExpression<ServerSideBlazorApp.Data.ProductCategoryType?>(ProductCategoryType, product.ProductCategoryType),
                new InsertExpression<string>(Name, product.Name),
                new InsertExpression<string>(Description, product.Description),
                new InsertExpression<double>(ListPrice, product.ListPrice),
                new InsertExpression<double>(Price, product.Price),
                new InsertExpression<int>(Quantity, product.Quantity),
                new InsertExpression<byte[]>(Image, product.Image),
                new InsertExpression<decimal?>(Height, product.Height),
                new InsertExpression<decimal?>(Width, product.Width),
                new InsertExpression<decimal?>(Depth, product.Depth),
                new InsertExpression<decimal?>(Weight, product.Weight),
                new InsertExpression<decimal>(ShippingWeight, product.ShippingWeight),
                new InsertExpression<TimeSpan?>(ValidStartTimeOfDayForPurchase, product.ValidStartTimeOfDayForPurchase),
                new InsertExpression<TimeSpan?>(ValidEndTimeOfDayForPurchase, product.ValidEndTimeOfDayForPurchase),
                new InsertExpression<DateTime>(DateCreated, product.DateCreated),
                new InsertExpression<DateTime>(DateUpdated, product.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Product target, Product source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.ProductCategoryType != source.ProductCategoryType) { expr &= ProductCategoryType.Set(source.ProductCategoryType); }
            if (target.Name != source.Name) { expr &= Name.Set(source.Name); }
            if (target.Description != source.Description) { expr &= Description.Set(source.Description); }
            if (target.ListPrice != source.ListPrice) { expr &= ListPrice.Set(source.ListPrice); }
            if (target.Price != source.Price) { expr &= Price.Set(source.Price); }
            if (target.Quantity != source.Quantity) { expr &= Quantity.Set(source.Quantity); }
            if (target.Image != source.Image) { expr &= Image.Set(source.Image); }
            if (target.Height != source.Height) { expr &= Height.Set(source.Height); }
            if (target.Width != source.Width) { expr &= Width.Set(source.Width); }
            if (target.Depth != source.Depth) { expr &= Depth.Set(source.Depth); }
            if (target.Weight != source.Weight) { expr &= Weight.Set(source.Weight); }
            if (target.ShippingWeight != source.ShippingWeight) { expr &= ShippingWeight.Set(source.ShippingWeight); }
            if (target.ValidStartTimeOfDayForPurchase != source.ValidStartTimeOfDayForPurchase) { expr &= ValidStartTimeOfDayForPurchase.Set(source.ValidStartTimeOfDayForPurchase); }
            if (target.ValidEndTimeOfDayForPurchase != source.ValidEndTimeOfDayForPurchase) { expr &= ValidEndTimeOfDayForPurchase.Set(source.ValidEndTimeOfDayForPurchase); }
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }

            return expr;
        }

        protected override void HydrateEntity(Product product, ISqlFieldReader reader)
        {
			product.Id = reader.ReadField().GetValue<int>();
			product.ProductCategoryType = reader.ReadField().GetValue<ServerSideBlazorApp.Data.ProductCategoryType?>();
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

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Product>
        {
            #region constructors
            public IdField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region product category type field expression
        public partial class ProductCategoryTypeField : NullableEnumFieldExpression<Product, ServerSideBlazorApp.Data.ProductCategoryType>
        {
            #region constructors
            public ProductCategoryTypeField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private ProductCategoryTypeField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableEnumElement<ServerSideBlazorApp.Data.ProductCategoryType> As(string alias)
                => new ProductCategoryTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(ServerSideBlazorApp.Data.ProductCategoryType value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.ProductCategoryType>(value));
            public AssignmentExpression Set(EnumElement<ServerSideBlazorApp.Data.ProductCategoryType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(ServerSideBlazorApp.Data.ProductCategoryType? value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.ProductCategoryType?>(value));
            public AssignmentExpression Set(NullableEnumElement<ServerSideBlazorApp.Data.ProductCategoryType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region name field expression
        public partial class NameField : StringFieldExpression<Product>
        {
            #region constructors
            public NameField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private NameField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new NameField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region description field expression
        public partial class DescriptionField : NullableStringFieldExpression<Product>
        {
            #region constructors
            public DescriptionField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private DescriptionField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableStringElement As(string alias)
                => new DescriptionField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(NullableStringElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region list price field expression
        public partial class ListPriceField : DoubleFieldExpression<Product>
        {
            #region constructors
            public ListPriceField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private ListPriceField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DoubleElement As(string alias)
                => new ListPriceField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value));
            public AssignmentExpression Set(DoubleElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region price field expression
        public partial class PriceField : DoubleFieldExpression<Product>
        {
            #region constructors
            public PriceField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private PriceField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DoubleElement As(string alias)
                => new PriceField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value));
            public AssignmentExpression Set(DoubleElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region quantity field expression
        public partial class QuantityField : Int32FieldExpression<Product>
        {
            #region constructors
            public QuantityField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private QuantityField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new QuantityField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region image field expression
        public partial class ImageField : NullableByteArrayFieldExpression<Product>
        {
            #region constructors
            public ImageField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private ImageField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableByteArrayElement As(string alias)
                => new ImageField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new LiteralExpression<byte[]>(value));
            public AssignmentExpression Set(ByteArrayElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(NullableByteArrayElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region height field expression
        public partial class HeightField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public HeightField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private HeightField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDecimalElement As(string alias)
                => new HeightField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value));
            public AssignmentExpression Set(DecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value));
            public AssignmentExpression Set(NullableDecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region width field expression
        public partial class WidthField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public WidthField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private WidthField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDecimalElement As(string alias)
                => new WidthField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value));
            public AssignmentExpression Set(DecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value));
            public AssignmentExpression Set(NullableDecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region depth field expression
        public partial class DepthField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public DepthField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private DepthField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDecimalElement As(string alias)
                => new DepthField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value));
            public AssignmentExpression Set(DecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value));
            public AssignmentExpression Set(NullableDecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region weight field expression
        public partial class WeightField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public WeightField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private WeightField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDecimalElement As(string alias)
                => new WeightField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value));
            public AssignmentExpression Set(DecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value));
            public AssignmentExpression Set(NullableDecimalElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region shipping weight field expression
        public partial class ShippingWeightField : DecimalFieldExpression<Product>
        {
            #region constructors
            public ShippingWeightField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private ShippingWeightField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DecimalElement As(string alias)
                => new ShippingWeightField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value));
            public AssignmentExpression Set(DecimalElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region valid start time of day for purchase field expression
        public partial class ValidStartTimeOfDayForPurchaseField : NullableTimeSpanFieldExpression<Product>
        {
            #region constructors
            public ValidStartTimeOfDayForPurchaseField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private ValidStartTimeOfDayForPurchaseField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableTimeSpanElement As(string alias)
                => new ValidStartTimeOfDayForPurchaseField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value));
            public AssignmentExpression Set(TimeSpanElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(TimeSpan? value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value));
            public AssignmentExpression Set(NullableTimeSpanElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region valid end time of day for purchase field expression
        public partial class ValidEndTimeOfDayForPurchaseField : NullableTimeSpanFieldExpression<Product>
        {
            #region constructors
            public ValidEndTimeOfDayForPurchaseField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private ValidEndTimeOfDayForPurchaseField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableTimeSpanElement As(string alias)
                => new ValidEndTimeOfDayForPurchaseField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value));
            public AssignmentExpression Set(TimeSpanElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(TimeSpan? value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value));
            public AssignmentExpression Set(NullableTimeSpanElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Product>
        {
            #region constructors
            public DateCreatedField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private DateCreatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Product>
        {
            #region constructors
            public DateUpdatedField(string identifier, ProductEntity entity) : base(identifier, entity)
            {

            }

            private DateUpdatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateUpdatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #endregion
    }
    #endregion

    #region purchase entity expression

    public partial class PurchaseEntity : EntityExpression<Purchase>
    {
        #region interface properties
        public IdField Id { get; private set; }
        public PersonIdField PersonId { get; private set; }
        public OrderNumberField OrderNumber { get; private set; }
        public TotalPurchaseQuantityField TotalPurchaseQuantity { get; private set; }
        public TotalPurchaseAmountField TotalPurchaseAmount { get; private set; }
        public PurchaseDateField PurchaseDate { get; private set; }
        public ShipDateField ShipDate { get; private set; }
        public ExpectedDeliveryDateField ExpectedDeliveryDate { get; private set; }
        public TrackingIdentifierField TrackingIdentifier { get; private set; }
        public PaymentMethodTypeField PaymentMethodType { get; private set; }
        public PaymentSourceTypeField PaymentSourceType { get; private set; }
        public DateCreatedField DateCreated { get; private set; }
        public DateUpdatedField DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", this));
            Fields.Add($"{identifier}.OrderNumber", OrderNumber = new OrderNumberField($"{identifier}.OrderNumber", this));
            Fields.Add($"{identifier}.TotalPurchaseQuantity", TotalPurchaseQuantity = new TotalPurchaseQuantityField($"{identifier}.TotalPurchaseQuantity", this));
            Fields.Add($"{identifier}.TotalPurchaseAmount", TotalPurchaseAmount = new TotalPurchaseAmountField($"{identifier}.TotalPurchaseAmount", this));
            Fields.Add($"{identifier}.PurchaseDate", PurchaseDate = new PurchaseDateField($"{identifier}.PurchaseDate", this));
            Fields.Add($"{identifier}.ShipDate", ShipDate = new ShipDateField($"{identifier}.ShipDate", this));
            Fields.Add($"{identifier}.ExpectedDeliveryDate", ExpectedDeliveryDate = new ExpectedDeliveryDateField($"{identifier}.ExpectedDeliveryDate", this));
            Fields.Add($"{identifier}.TrackingIdentifier", TrackingIdentifier = new TrackingIdentifierField($"{identifier}.TrackingIdentifier", this));
            Fields.Add($"{identifier}.PaymentMethodType", PaymentMethodType = new PaymentMethodTypeField($"{identifier}.PaymentMethodType", this));
            Fields.Add($"{identifier}.PaymentSourceType", PaymentSourceType = new PaymentSourceTypeField($"{identifier}.PaymentSourceType", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", this));
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
                OrderNumber,
                TotalPurchaseQuantity,
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
            return new InsertExpressionSet<Purchase>(purchase, 
                new InsertExpression<int>(Id, purchase.Id),
                new InsertExpression<int>(PersonId, purchase.PersonId),
                new InsertExpression<string>(OrderNumber, purchase.OrderNumber),
                new InsertExpression<int>(TotalPurchaseQuantity, purchase.TotalPurchaseQuantity),
                new InsertExpression<double>(TotalPurchaseAmount, purchase.TotalPurchaseAmount),
                new InsertExpression<DateTime>(PurchaseDate, purchase.PurchaseDate),
                new InsertExpression<DateTime?>(ShipDate, purchase.ShipDate),
                new InsertExpression<DateTime?>(ExpectedDeliveryDate, purchase.ExpectedDeliveryDate),
                new InsertExpression<Guid?>(TrackingIdentifier, purchase.TrackingIdentifier),
                new InsertExpression<ServerSideBlazorApp.Data.PaymentMethodType>(PaymentMethodType, purchase.PaymentMethodType),
                new InsertExpression<ServerSideBlazorApp.Data.PaymentSourceType?>(PaymentSourceType, purchase.PaymentSourceType),
                new InsertExpression<DateTime>(DateCreated, purchase.DateCreated),
                new InsertExpression<DateTime>(DateUpdated, purchase.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Purchase target, Purchase source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.OrderNumber != source.OrderNumber) { expr &= OrderNumber.Set(source.OrderNumber); }
            if (target.TotalPurchaseQuantity != source.TotalPurchaseQuantity) { expr &= TotalPurchaseQuantity.Set(source.TotalPurchaseQuantity); }
            if (target.TotalPurchaseAmount != source.TotalPurchaseAmount) { expr &= TotalPurchaseAmount.Set(source.TotalPurchaseAmount); }
            if (target.PurchaseDate != source.PurchaseDate) { expr &= PurchaseDate.Set(source.PurchaseDate); }
            if (target.ShipDate != source.ShipDate) { expr &= ShipDate.Set(source.ShipDate); }
            if (target.ExpectedDeliveryDate != source.ExpectedDeliveryDate) { expr &= ExpectedDeliveryDate.Set(source.ExpectedDeliveryDate); }
            if (target.TrackingIdentifier != source.TrackingIdentifier) { expr &= TrackingIdentifier.Set(source.TrackingIdentifier); }
            if (target.PaymentMethodType != source.PaymentMethodType) { expr &= PaymentMethodType.Set(source.PaymentMethodType); }
            if (target.PaymentSourceType != source.PaymentSourceType) { expr &= PaymentSourceType.Set(source.PaymentSourceType); }
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }

            return expr;
        }

        protected override void HydrateEntity(Purchase purchase, ISqlFieldReader reader)
        {
			purchase.Id = reader.ReadField().GetValue<int>();
			purchase.PersonId = reader.ReadField().GetValue<int>();
			purchase.OrderNumber = reader.ReadField().GetValue<string>();
			purchase.TotalPurchaseQuantity = reader.ReadField().GetValue<int>();
			purchase.TotalPurchaseAmount = reader.ReadField().GetValue<double>();
			purchase.PurchaseDate = reader.ReadField().GetValue<DateTime>();
			purchase.ShipDate = reader.ReadField().GetValue<DateTime?>();
			purchase.ExpectedDeliveryDate = reader.ReadField().GetValue<DateTime?>();
			purchase.TrackingIdentifier = reader.ReadField().GetValue<Guid?>();
			purchase.PaymentMethodType = reader.ReadField().GetValue<ServerSideBlazorApp.Data.PaymentMethodType>();
			purchase.PaymentSourceType = reader.ReadField().GetValue<ServerSideBlazorApp.Data.PaymentSourceType?>();
			purchase.DateCreated = reader.ReadField().GetValue<DateTime>();
			purchase.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public IdField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public PersonIdField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private PersonIdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new PersonIdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region order number field expression
        public partial class OrderNumberField : StringFieldExpression<Purchase>
        {
            #region constructors
            public OrderNumberField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private OrderNumberField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new OrderNumberField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region total purchase quantity field expression
        public partial class TotalPurchaseQuantityField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public TotalPurchaseQuantityField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private TotalPurchaseQuantityField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new TotalPurchaseQuantityField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region total purchase amount field expression
        public partial class TotalPurchaseAmountField : DoubleFieldExpression<Purchase>
        {
            #region constructors
            public TotalPurchaseAmountField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private TotalPurchaseAmountField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DoubleElement As(string alias)
                => new TotalPurchaseAmountField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value));
            public AssignmentExpression Set(DoubleElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region purchase date field expression
        public partial class PurchaseDateField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public PurchaseDateField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private PurchaseDateField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new PurchaseDateField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region ship date field expression
        public partial class ShipDateField : NullableDateTimeFieldExpression<Purchase>
        {
            #region constructors
            public ShipDateField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private ShipDateField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDateTimeElement As(string alias)
                => new ShipDateField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value));
            public AssignmentExpression Set(NullableDateTimeElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region expected delivery date field expression
        public partial class ExpectedDeliveryDateField : NullableDateTimeFieldExpression<Purchase>
        {
            #region constructors
            public ExpectedDeliveryDateField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private ExpectedDeliveryDateField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDateTimeElement As(string alias)
                => new ExpectedDeliveryDateField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value));
            public AssignmentExpression Set(NullableDateTimeElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region tracking identifier field expression
        public partial class TrackingIdentifierField : NullableGuidFieldExpression<Purchase>
        {
            #region constructors
            public TrackingIdentifierField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private TrackingIdentifierField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableGuidElement As(string alias)
                => new TrackingIdentifierField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(Guid value) => new AssignmentExpression(this, new LiteralExpression<Guid>(value));
            public AssignmentExpression Set(GuidElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(Guid? value) => new AssignmentExpression(this, new LiteralExpression<Guid?>(value));
            public AssignmentExpression Set(NullableGuidElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region payment method type field expression
        public partial class PaymentMethodTypeField : EnumFieldExpression<Purchase, ServerSideBlazorApp.Data.PaymentMethodType>
        {
            #region constructors
            public PaymentMethodTypeField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private PaymentMethodTypeField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override EnumElement<ServerSideBlazorApp.Data.PaymentMethodType> As(string alias)
                => new PaymentMethodTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(ServerSideBlazorApp.Data.PaymentMethodType value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.PaymentMethodType>(value));
            public AssignmentExpression Set(EnumElement<ServerSideBlazorApp.Data.PaymentMethodType> value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region payment source type field expression
        public partial class PaymentSourceTypeField : NullableEnumFieldExpression<Purchase, ServerSideBlazorApp.Data.PaymentSourceType>
        {
            #region constructors
            public PaymentSourceTypeField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private PaymentSourceTypeField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableEnumElement<ServerSideBlazorApp.Data.PaymentSourceType> As(string alias)
                => new PaymentSourceTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(ServerSideBlazorApp.Data.PaymentSourceType value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.PaymentSourceType>(value));
            public AssignmentExpression Set(EnumElement<ServerSideBlazorApp.Data.PaymentSourceType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(ServerSideBlazorApp.Data.PaymentSourceType? value) => new AssignmentExpression(this, new LiteralExpression<ServerSideBlazorApp.Data.PaymentSourceType?>(value));
            public AssignmentExpression Set(NullableEnumElement<ServerSideBlazorApp.Data.PaymentSourceType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public DateCreatedField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private DateCreatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public DateUpdatedField(string identifier, PurchaseEntity entity) : base(identifier, entity)
            {

            }

            private DateUpdatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateUpdatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #endregion
    }
    #endregion

    #region purchase line entity expression

    public partial class PurchaseLineEntity : EntityExpression<PurchaseLine>
    {
        #region interface properties
        public IdField Id { get; private set; }
        public PurchaseIdField PurchaseId { get; private set; }
        public ProductIdField ProductId { get; private set; }
        public PurchasePriceField PurchasePrice { get; private set; }
        public QuantityField Quantity { get; private set; }
        public DateCreatedField DateCreated { get; private set; }
        public DateUpdatedField DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PurchaseId", PurchaseId = new PurchaseIdField($"{identifier}.PurchaseId", this));
            Fields.Add($"{identifier}.ProductId", ProductId = new ProductIdField($"{identifier}.ProductId", this));
            Fields.Add($"{identifier}.PurchasePrice", PurchasePrice = new PurchasePriceField($"{identifier}.PurchasePrice", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new QuantityField($"{identifier}.Quantity", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", this));
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
            return new InsertExpressionSet<PurchaseLine>(purchaseLine, 
                new InsertExpression<int>(Id, purchaseLine.Id),
                new InsertExpression<int>(PurchaseId, purchaseLine.PurchaseId),
                new InsertExpression<int>(ProductId, purchaseLine.ProductId),
                new InsertExpression<decimal>(PurchasePrice, purchaseLine.PurchasePrice),
                new InsertExpression<int>(Quantity, purchaseLine.Quantity),
                new InsertExpression<DateTime>(DateCreated, purchaseLine.DateCreated),
                new InsertExpression<DateTime>(DateUpdated, purchaseLine.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PurchaseLine target, PurchaseLine source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PurchaseId != source.PurchaseId) { expr &= PurchaseId.Set(source.PurchaseId); }
            if (target.ProductId != source.ProductId) { expr &= ProductId.Set(source.ProductId); }
            if (target.PurchasePrice != source.PurchasePrice) { expr &= PurchasePrice.Set(source.PurchasePrice); }
            if (target.Quantity != source.Quantity) { expr &= Quantity.Set(source.Quantity); }
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }

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

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public IdField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region purchase id field expression
        public partial class PurchaseIdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public PurchaseIdField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private PurchaseIdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new PurchaseIdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region product id field expression
        public partial class ProductIdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public ProductIdField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private ProductIdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new ProductIdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region purchase price field expression
        public partial class PurchasePriceField : DecimalFieldExpression<PurchaseLine>
        {
            #region constructors
            public PurchasePriceField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private PurchasePriceField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DecimalElement As(string alias)
                => new PurchasePriceField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value));
            public AssignmentExpression Set(DecimalElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region quantity field expression
        public partial class QuantityField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public QuantityField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private QuantityField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new QuantityField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<PurchaseLine>
        {
            #region constructors
            public DateCreatedField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private DateCreatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<PurchaseLine>
        {
            #region constructors
            public DateUpdatedField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private DateUpdatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeElement As(string alias)
                => new DateUpdatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value));
            public AssignmentExpression Set(DateTimeElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #endregion
    }
    #endregion

    #region person total purchases view entity expression

    public partial class PersonTotalPurchasesViewEntity : EntityExpression<PersonTotalPurchasesView>
    {
        #region interface properties
        public IdField Id { get; private set; }
        public TotalAmountField TotalAmount { get; private set; }
        public TotalCountField TotalCount { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.TotalAmount", TotalAmount = new TotalAmountField($"{identifier}.TotalAmount", this));
            Fields.Add($"{identifier}.TotalCount", TotalCount = new TotalCountField($"{identifier}.TotalCount", this));
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
            return new InsertExpressionSet<PersonTotalPurchasesView>(personTotalPurchasesView, 
                new InsertExpression<int>(Id, personTotalPurchasesView.Id),
                new InsertExpression<double?>(TotalAmount, personTotalPurchasesView.TotalAmount),
                new InsertExpression<int?>(TotalCount, personTotalPurchasesView.TotalCount)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView target, PersonTotalPurchasesView source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.Id != source.Id) { expr &= Id.Set(source.Id); }
            if (target.TotalAmount != source.TotalAmount) { expr &= TotalAmount.Set(source.TotalAmount); }
            if (target.TotalCount != source.TotalCount) { expr &= TotalCount.Set(source.TotalCount); }

            return expr;
        }

        protected override void HydrateEntity(PersonTotalPurchasesView personTotalPurchasesView, ISqlFieldReader reader)
        {
			personTotalPurchasesView.Id = reader.ReadField().GetValue<int>();
			personTotalPurchasesView.TotalAmount = reader.ReadField().GetValue<double?>();
			personTotalPurchasesView.TotalCount = reader.ReadField().GetValue<int?>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public IdField(string identifier, PersonTotalPurchasesViewEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region total amount field expression
        public partial class TotalAmountField : NullableDoubleFieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public TotalAmountField(string identifier, PersonTotalPurchasesViewEntity entity) : base(identifier, entity)
            {

            }

            private TotalAmountField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDoubleElement As(string alias)
                => new TotalAmountField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value));
            public AssignmentExpression Set(DoubleElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(double? value) => new AssignmentExpression(this, new LiteralExpression<double?>(value));
            public AssignmentExpression Set(NullableDoubleElement value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

        #region total count field expression
        public partial class TotalCountField : NullableInt32FieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public TotalCountField(string identifier, PersonTotalPurchasesViewEntity entity) : base(identifier, entity)
            {

            }

            private TotalCountField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableInt32Element As(string alias)
                => new TotalCountField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value));
            public AssignmentExpression Set(NullableInt32Element value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<object>(DBNull.Value));
            #endregion

        }
        #endregion

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
        public static CustomerEntity Customer => _schema.Customer;
        public static CustomerAddressEntity CustomerAddress => _schema.CustomerAddress;
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
namespace ServerSideBlazorApp.secDataService
{
	using ServerSideBlazorApp.secData;

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
        public IdField Id { get; private set; }
        public SSNField SSN { get; private set; }
        public DateCreatedField DateCreated { get; private set; }
        public DateUpdatedField DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.SSN", SSN = new SSNField($"{identifier}.SSN", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", this));
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
            return new InsertExpressionSet<Person>(person, 
                new InsertExpression<int>(Id, person.Id),
                new InsertExpression<string>(SSN, person.SSN),
                new InsertExpression<DateTimeOffset>(DateCreated, person.DateCreated),
                new InsertExpression<DateTimeOffset>(DateUpdated, person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person target, Person source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.SSN != source.SSN) { expr &= SSN.Set(source.SSN); }
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }

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

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Person>
        {
            #region constructors
            public IdField(string identifier, PersonEntity entity) : base(identifier, entity)
            {

            }

            private IdField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override Int32Element As(string alias)
                => new IdField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value));
            public AssignmentExpression Set(Int32Element value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region s s n field expression
        public partial class SSNField : StringFieldExpression<Person>
        {
            #region constructors
            public SSNField(string identifier, PersonEntity entity) : base(identifier, entity)
            {

            }

            private SSNField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override StringElement As(string alias)
                => new SSNField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeOffsetFieldExpression<Person>
        {
            #region constructors
            public DateCreatedField(string identifier, PersonEntity entity) : base(identifier, entity)
            {

            }

            private DateCreatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeOffsetElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTimeOffset value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value));
            public AssignmentExpression Set(DateTimeOffsetElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeOffsetFieldExpression<Person>
        {
            #region constructors
            public DateUpdatedField(string identifier, PersonEntity entity) : base(identifier, entity)
            {

            }

            private DateUpdatedField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override DateTimeOffsetElement As(string alias)
                => new DateUpdatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(DateTimeOffset value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value));
            public AssignmentExpression Set(DateTimeOffsetElement value) => new AssignmentExpression(this, value);
            #endregion

        }
        #endregion

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
