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
        public static Alias alias(string tableName, string fieldName)
            => new AliasExpressionBuilder(new AliasExpression(tableName, fieldName));
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
        public NullableEnumFieldExpression<Address, DbEx.Data.AddressType> AddressType { get; private set; }
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
            Fields.Add($"{identifier}.AddressType", AddressType = new NullableEnumFieldExpression<Address, DbEx.Data.AddressType>($"{identifier}.AddressType", this));
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
            return new InsertExpressionSet<Address>(address, 
                new InsertExpression<int>(Id, address.Id),
                new InsertExpression<DbEx.Data.AddressType?>(AddressType, address.AddressType),
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

            if (target.AddressType != source.AddressType) { expr &= AddressType.Set(source.AddressType); }; 
            if (target.Line1 != source.Line1) { expr &= Line1.Set(source.Line1); }; 
            if (target.Line2 != source.Line2) { expr &= Line2.Set(source.Line2); }; 
            if (target.City != source.City) { expr &= City.Set(source.City); }; 
            if (target.State != source.State) { expr &= State.Set(source.State); }; 
            if (target.Zip != source.Zip) { expr &= Zip.Set(source.Zip); }; 
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }; 
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }; 

            return expr;
        }

        protected override void HydrateEntity(Address address, ISqlFieldReader reader)
        {
			address.Id = reader.ReadField().GetValue<int>();
			address.AddressType = reader.ReadField().GetValue<DbEx.Data.AddressType?>();
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
        public EnumFieldExpression<Person, DbEx.Data.GenderType> GenderType { get; private set; }
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
            Fields.Add($"{identifier}.GenderType", GenderType = new EnumFieldExpression<Person, DbEx.Data.GenderType>($"{identifier}.GenderType", this));
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
            return new InsertExpressionSet<Person>(person, 
                new InsertExpression<int>(Id, person.Id),
                new InsertExpression<string>(FirstName, person.FirstName),
                new InsertExpression<string>(LastName, person.LastName),
                new InsertExpression<DateTime?>(BirthDate, person.BirthDate),
                new InsertExpression<DbEx.Data.GenderType>(GenderType, person.GenderType),
                new InsertExpression<int?>(CreditLimit, person.CreditLimit),
                new InsertExpression<int?>(YearOfLastCreditLimitReview, person.YearOfLastCreditLimitReview),
                new InsertExpression<DateTime>(DateCreated, person.DateCreated),
                new InsertExpression<DateTime>(DateUpdated, person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person target, Person source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.FirstName != source.FirstName) { expr &= FirstName.Set(source.FirstName); }; 
            if (target.LastName != source.LastName) { expr &= LastName.Set(source.LastName); }; 
            if (target.BirthDate != source.BirthDate) { expr &= BirthDate.Set(source.BirthDate); }; 
            if (target.GenderType != source.GenderType) { expr &= GenderType.Set(source.GenderType); }; 
            if (target.CreditLimit != source.CreditLimit) { expr &= CreditLimit.Set(source.CreditLimit); }; 
            if (target.YearOfLastCreditLimitReview != source.YearOfLastCreditLimitReview) { expr &= YearOfLastCreditLimitReview.Set(source.YearOfLastCreditLimitReview); }; 
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }; 
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }; 

            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader)
        {
			person.Id = reader.ReadField().GetValue<int>();
			person.FirstName = reader.ReadField().GetValue<string>();
			person.LastName = reader.ReadField().GetValue<string>();
			person.BirthDate = reader.ReadField().GetValue<DateTime?>();
			person.GenderType = reader.ReadField().GetValue<DbEx.Data.GenderType>();
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
            return new InsertExpressionSet<PersonAddress>(personAddress, 
                new InsertExpression<int>(Id, personAddress.Id),
                new InsertExpression<int>(PersonId, personAddress.PersonId),
                new InsertExpression<int>(AddressId, personAddress.AddressId),
                new InsertExpression<DateTime>(DateCreated, personAddress.DateCreated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonAddress target, PersonAddress source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }; 
            if (target.AddressId != source.AddressId) { expr &= AddressId.Set(source.AddressId); }; 
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }; 

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
        public NullableEnumFieldExpression<Product, DbEx.Data.ProductCategoryType> ProductCategoryType { get; private set; }
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
            Fields.Add($"{identifier}.ProductCategoryType", ProductCategoryType = new NullableEnumFieldExpression<Product, DbEx.Data.ProductCategoryType>($"{identifier}.ProductCategoryType", this));
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
            return new InsertExpressionSet<Product>(product, 
                new InsertExpression<int>(Id, product.Id),
                new InsertExpression<DbEx.Data.ProductCategoryType?>(ProductCategoryType, product.ProductCategoryType),
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

            if (target.ProductCategoryType != source.ProductCategoryType) { expr &= ProductCategoryType.Set(source.ProductCategoryType); }; 
            if (target.Name != source.Name) { expr &= Name.Set(source.Name); }; 
            if (target.Description != source.Description) { expr &= Description.Set(source.Description); }; 
            if (target.ListPrice != source.ListPrice) { expr &= ListPrice.Set(source.ListPrice); }; 
            if (target.Price != source.Price) { expr &= Price.Set(source.Price); }; 
            if (target.Quantity != source.Quantity) { expr &= Quantity.Set(source.Quantity); }; 
            if (target.Image != source.Image) { expr &= Image.Set(source.Image); }; 
            if (target.Height != source.Height) { expr &= Height.Set(source.Height); }; 
            if (target.Width != source.Width) { expr &= Width.Set(source.Width); }; 
            if (target.Depth != source.Depth) { expr &= Depth.Set(source.Depth); }; 
            if (target.Weight != source.Weight) { expr &= Weight.Set(source.Weight); }; 
            if (target.ShippingWeight != source.ShippingWeight) { expr &= ShippingWeight.Set(source.ShippingWeight); }; 
            if (target.ValidStartTimeOfDayForPurchase != source.ValidStartTimeOfDayForPurchase) { expr &= ValidStartTimeOfDayForPurchase.Set(source.ValidStartTimeOfDayForPurchase); }; 
            if (target.ValidEndTimeOfDayForPurchase != source.ValidEndTimeOfDayForPurchase) { expr &= ValidEndTimeOfDayForPurchase.Set(source.ValidEndTimeOfDayForPurchase); }; 
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }; 
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }; 

            return expr;
        }

        protected override void HydrateEntity(Product product, ISqlFieldReader reader)
        {
			product.Id = reader.ReadField().GetValue<int>();
			product.ProductCategoryType = reader.ReadField().GetValue<DbEx.Data.ProductCategoryType?>();
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
        public StringFieldExpression<Purchase> OrderNumber { get; private set; }
        public StringFieldExpression<Purchase> TotalPurchaseQuantity { get; private set; }
        public DoubleFieldExpression<Purchase> TotalPurchaseAmount { get; private set; }
        public DateTimeFieldExpression<Purchase> PurchaseDate { get; private set; }
        public NullableDateTimeFieldExpression<Purchase> ShipDate { get; private set; }
        public NullableDateTimeFieldExpression<Purchase> ExpectedDeliveryDate { get; private set; }
        public NullableGuidFieldExpression<Purchase> TrackingIdentifier { get; private set; }
        public EnumFieldExpression<Purchase, DbEx.Data.PaymentMethodType> PaymentMethodType { get; private set; }
        public NullableEnumFieldExpression<Purchase, DbEx.Data.PaymentSourceType> PaymentSourceType { get; private set; }
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
            Fields.Add($"{identifier}.OrderNumber", OrderNumber = new StringFieldExpression<Purchase>($"{identifier}.OrderNumber", this));
            Fields.Add($"{identifier}.TotalPurchaseQuantity", TotalPurchaseQuantity = new StringFieldExpression<Purchase>($"{identifier}.TotalPurchaseQuantity", this));
            Fields.Add($"{identifier}.TotalPurchaseAmount", TotalPurchaseAmount = new DoubleFieldExpression<Purchase>($"{identifier}.TotalPurchaseAmount", this));
            Fields.Add($"{identifier}.PurchaseDate", PurchaseDate = new DateTimeFieldExpression<Purchase>($"{identifier}.PurchaseDate", this));
            Fields.Add($"{identifier}.ShipDate", ShipDate = new NullableDateTimeFieldExpression<Purchase>($"{identifier}.ShipDate", this));
            Fields.Add($"{identifier}.ExpectedDeliveryDate", ExpectedDeliveryDate = new NullableDateTimeFieldExpression<Purchase>($"{identifier}.ExpectedDeliveryDate", this));
            Fields.Add($"{identifier}.TrackingIdentifier", TrackingIdentifier = new NullableGuidFieldExpression<Purchase>($"{identifier}.TrackingIdentifier", this));
            Fields.Add($"{identifier}.PaymentMethodType", PaymentMethodType = new EnumFieldExpression<Purchase, DbEx.Data.PaymentMethodType>($"{identifier}.PaymentMethodType", this));
            Fields.Add($"{identifier}.PaymentSourceType", PaymentSourceType = new NullableEnumFieldExpression<Purchase, DbEx.Data.PaymentSourceType>($"{identifier}.PaymentSourceType", this));
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
                new InsertExpression<string>(TotalPurchaseQuantity, purchase.TotalPurchaseQuantity),
                new InsertExpression<double>(TotalPurchaseAmount, purchase.TotalPurchaseAmount),
                new InsertExpression<DateTime>(PurchaseDate, purchase.PurchaseDate),
                new InsertExpression<DateTime?>(ShipDate, purchase.ShipDate),
                new InsertExpression<DateTime?>(ExpectedDeliveryDate, purchase.ExpectedDeliveryDate),
                new InsertExpression<Guid?>(TrackingIdentifier, purchase.TrackingIdentifier),
                new InsertExpression<DbEx.Data.PaymentMethodType>(PaymentMethodType, purchase.PaymentMethodType),
                new InsertExpression<DbEx.Data.PaymentSourceType?>(PaymentSourceType, purchase.PaymentSourceType),
                new InsertExpression<DateTime>(DateCreated, purchase.DateCreated),
                new InsertExpression<DateTime>(DateUpdated, purchase.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Purchase target, Purchase source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }; 
            if (target.OrderNumber != source.OrderNumber) { expr &= OrderNumber.Set(source.OrderNumber); }; 
            if (target.TotalPurchaseQuantity != source.TotalPurchaseQuantity) { expr &= TotalPurchaseQuantity.Set(source.TotalPurchaseQuantity); }; 
            if (target.TotalPurchaseAmount != source.TotalPurchaseAmount) { expr &= TotalPurchaseAmount.Set(source.TotalPurchaseAmount); }; 
            if (target.PurchaseDate != source.PurchaseDate) { expr &= PurchaseDate.Set(source.PurchaseDate); }; 
            if (target.ShipDate != source.ShipDate) { expr &= ShipDate.Set(source.ShipDate); }; 
            if (target.ExpectedDeliveryDate != source.ExpectedDeliveryDate) { expr &= ExpectedDeliveryDate.Set(source.ExpectedDeliveryDate); }; 
            if (target.TrackingIdentifier != source.TrackingIdentifier) { expr &= TrackingIdentifier.Set(source.TrackingIdentifier); }; 
            if (target.PaymentMethodType != source.PaymentMethodType) { expr &= PaymentMethodType.Set(source.PaymentMethodType); }; 
            if (target.PaymentSourceType != source.PaymentSourceType) { expr &= PaymentSourceType.Set(source.PaymentSourceType); }; 
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }; 
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }; 

            return expr;
        }

        protected override void HydrateEntity(Purchase purchase, ISqlFieldReader reader)
        {
			purchase.Id = reader.ReadField().GetValue<int>();
			purchase.PersonId = reader.ReadField().GetValue<int>();
			purchase.OrderNumber = reader.ReadField().GetValue<string>();
			purchase.TotalPurchaseQuantity = reader.ReadField().GetValue<string>();
			purchase.TotalPurchaseAmount = reader.ReadField().GetValue<double>();
			purchase.PurchaseDate = reader.ReadField().GetValue<DateTime>();
			purchase.ShipDate = reader.ReadField().GetValue<DateTime?>();
			purchase.ExpectedDeliveryDate = reader.ReadField().GetValue<DateTime?>();
			purchase.TrackingIdentifier = reader.ReadField().GetValue<Guid?>();
			purchase.PaymentMethodType = reader.ReadField().GetValue<DbEx.Data.PaymentMethodType>();
			purchase.PaymentSourceType = reader.ReadField().GetValue<DbEx.Data.PaymentSourceType?>();
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

            if (target.PurchaseId != source.PurchaseId) { expr &= PurchaseId.Set(source.PurchaseId); }; 
            if (target.ProductId != source.ProductId) { expr &= ProductId.Set(source.ProductId); }; 
            if (target.PurchasePrice != source.PurchasePrice) { expr &= PurchasePrice.Set(source.PurchasePrice); }; 
            if (target.Quantity != source.Quantity) { expr &= Quantity.Set(source.Quantity); }; 
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }; 
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }; 

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
            return new InsertExpressionSet<PersonTotalPurchasesView>(personTotalPurchasesView, 
                new InsertExpression<int>(Id, personTotalPurchasesView.Id),
                new InsertExpression<double?>(TotalAmount, personTotalPurchasesView.TotalAmount),
                new InsertExpression<int?>(TotalCount, personTotalPurchasesView.TotalCount)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView target, PersonTotalPurchasesView source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.Id != source.Id) { expr &= Id.Set(source.Id); }; 
            if (target.TotalAmount != source.TotalAmount) { expr &= TotalAmount.Set(source.TotalAmount); }; 
            if (target.TotalCount != source.TotalCount) { expr &= TotalCount.Set(source.TotalCount); }; 

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

            if (target.SSN != source.SSN) { expr &= SSN.Set(source.SSN); }; 
            if (target.DateCreated != source.DateCreated) { expr &= DateCreated.Set(source.DateCreated); }; 
            if (target.DateUpdated != source.DateUpdated) { expr &= DateUpdated.Set(source.DateUpdated); }; 

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
