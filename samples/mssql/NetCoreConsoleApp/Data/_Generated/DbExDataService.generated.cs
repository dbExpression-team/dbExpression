using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace SimpleConsole.DataService
{
    #region runtime db
    public abstract class SimpleConsoleDbRuntimeSqlDatabase : IRuntimeSqlDatabase
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
    public class SimpleConsoleDb : RuntimeEnvironmentSqlDatabase
    {
        public SimpleConsoleDb() : base(new db(), new SqlDatabaseMetadataProvider(new SimpleConsoleDbSqlDatabaseMetadata("SimpleConsoleDb", "MsSqlDbExTest")))
        { }
    }
    #endregion

    #region db
#pragma warning disable IDE1006 // Naming Styles
    public partial class db : SimpleConsoleDbRuntimeSqlDatabase
#pragma warning restore IDE1006 // Naming Styles
    {
    	
    }
    #endregion
}

namespace SimpleConsole.dboDataService
{
	using SimpleConsole.dboData;

    #region dbo schema expression
#pragma warning disable IDE1006 // Naming Styles
    public class dboSchemaExpression : SchemaExpression
#pragma warning restore IDE1006 // Naming Styles
    {
        #region interface
        public readonly AddressEntity Address;
        public readonly PersonEntity Person;
        public readonly PersonAddressEntity PersonAddress;
        public readonly ProductEntity Product;
        public readonly PurchaseEntity Purchase;
        public readonly PurchaseLineEntity PurchaseLine;
        public readonly PersonTotalPurchasesViewEntity PersonTotalPurchasesView;
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
        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.IdField"/> representing the "dbo.Address.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.AddressTypeField"/> representing the "dbo.Address.AddressType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.AddressType"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>AddressType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly AddressTypeField AddressType;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.Line1Field"/> representing the "dbo.Address.Line1" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Line1</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(50)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly Line1Field Line1;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.Line2Field"/> representing the "dbo.Address.Line2" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Line2</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(50)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly Line2Field Line2;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.CityField"/> representing the "dbo.Address.City" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>City</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(60)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly CityField City;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.StateField"/> representing the "dbo.Address.State" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>State</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>char(2)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly StateField State;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.ZipField"/> representing the "dbo.Address.Zip" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Zip</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(10)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ZipField Zip;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.DateCreatedField"/> representing the "dbo.Address.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.DateUpdatedField"/> representing the "dbo.Address.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

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
            => new AddressEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,AddressType
                ,Line1
                ,Line2
                ,City
                ,State
                ,Zip
                ,DateCreated
                ,DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Address> GetInclusiveInsertExpression(Address address)
        {
            return new InsertExpressionSet<Address>(address 
                ,new InsertExpression<SimpleConsole.Data.AddressType?>(AddressType, address.AddressType)
                ,new InsertExpression<string>(Line1, address.Line1)
                ,new InsertExpression<string>(Line2, address.Line2)
                ,new InsertExpression<string>(City, address.City)
                ,new InsertExpression<string>(State, address.State)
                ,new InsertExpression<string>(Zip, address.Zip)
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
            return expr;
        }

        protected override void HydrateEntity(Address address, ISqlFieldReader reader)
        {
			address.Id = reader.ReadField().GetValue<int>();
			address.AddressType = reader.ReadField().GetValue<SimpleConsole.Data.AddressType?>();
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
            #endregion
        }
        #endregion

        #region address type field expression
        public partial class AddressTypeField : NullableEnumFieldExpression<Address, SimpleConsole.Data.AddressType>
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
            public override NullableEnumElement<SimpleConsole.Data.AddressType> As(string alias)
                => new AddressTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.AddressType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType>(value));
            public AssignmentExpression Set(EnumElement<SimpleConsole.Data.AddressType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.AddressType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType?>(value));
            public AssignmentExpression Set(NullableEnumElement<SimpleConsole.Data.AddressType> value) => new AssignmentExpression(this, value);
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
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region person entity expression
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region interface properties
        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.IdField"/> representing the "dbo.Person.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.FirstNameField"/> representing the "dbo.Person.FirstName" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>FirstName</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly FirstNameField FirstName;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.LastNameField"/> representing the "dbo.Person.LastName" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>LastName</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly LastNameField LastName;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.BirthDateField"/> representing the "dbo.Person.BirthDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>BirthDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>date</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly BirthDateField BirthDate;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.GenderTypeField"/> representing the "dbo.Person.GenderType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.GenderType"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>GenderType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly GenderTypeField GenderType;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.CreditLimitField"/> representing the "dbo.Person.CreditLimit" column in the database, 
        /// with a .NET type of <see cref="int"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>CreditLimit</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly CreditLimitField CreditLimit;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.YearOfLastCreditLimitReviewField"/> representing the "dbo.Person.YearOfLastCreditLimitReview" column in the database, 
        /// with a .NET type of <see cref="int"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>YearOfLastCreditLimitReview</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly YearOfLastCreditLimitReviewField YearOfLastCreditLimitReview;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.DateCreatedField"/> representing the "dbo.Person.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.DateUpdatedField"/> representing the "dbo.Person.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

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
        public PersonEntity As(string name)
            => new PersonEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,FirstName
                ,LastName
                ,BirthDate
                ,GenderType
                ,CreditLimit
                ,YearOfLastCreditLimitReview
                ,DateCreated
                ,DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(person 
                ,new InsertExpression<string>(FirstName, person.FirstName)
                ,new InsertExpression<string>(LastName, person.LastName)
                ,new InsertExpression<DateTime?>(BirthDate, person.BirthDate)
                ,new InsertExpression<SimpleConsole.Data.GenderType>(GenderType, person.GenderType)
                ,new InsertExpression<int?>(CreditLimit, person.CreditLimit)
                ,new InsertExpression<int?>(YearOfLastCreditLimitReview, person.YearOfLastCreditLimitReview)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person target, Person source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.FirstName != source.FirstName) { expr &= FirstName.Set(source.FirstName); }
            if (target.LastName != source.LastName) { expr &= LastName.Set(source.LastName); }
            if (target.BirthDate != source.BirthDate) { expr &= BirthDate.Set(source.BirthDate); }
            if (target.GenderType != source.GenderType) { expr &= GenderType.Set(source.GenderType); }
            if (target.CreditLimit != source.CreditLimit) { expr &= CreditLimit.Set(source.CreditLimit); }
            if (target.YearOfLastCreditLimitReview != source.YearOfLastCreditLimitReview) { expr &= YearOfLastCreditLimitReview.Set(source.YearOfLastCreditLimitReview); }
            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader)
        {
			person.Id = reader.ReadField().GetValue<int>();
			person.FirstName = reader.ReadField().GetValue<string>();
			person.LastName = reader.ReadField().GetValue<string>();
			person.BirthDate = reader.ReadField().GetValue<DateTime?>();
			person.GenderType = reader.ReadField().GetValue<SimpleConsole.Data.GenderType>();
			person.CreditLimit = reader.ReadField().GetValue<int?>();
			person.YearOfLastCreditLimitReview = reader.ReadField().GetValue<int?>();
			person.DateCreated = reader.ReadField().GetValue<DateTime>();
			person.DateUpdated = reader.ReadField().GetValue<DateTime>();
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
            #endregion
        }
        #endregion

        #region first name field expression
        public partial class FirstNameField : StringFieldExpression<Person>
        {
            #region constructors
            public FirstNameField(string identifier, PersonEntity entity) : base(identifier, entity)
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
        public partial class LastNameField : StringFieldExpression<Person>
        {
            #region constructors
            public LastNameField(string identifier, PersonEntity entity) : base(identifier, entity)
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
        public partial class BirthDateField : NullableDateTimeFieldExpression<Person>
        {
            #region constructors
            public BirthDateField(string identifier, PersonEntity entity) : base(identifier, entity)
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
        public partial class GenderTypeField : EnumFieldExpression<Person, SimpleConsole.Data.GenderType>
        {
            #region constructors
            public GenderTypeField(string identifier, PersonEntity entity) : base(identifier, entity)
            {

            }

            private GenderTypeField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override EnumElement<SimpleConsole.Data.GenderType> As(string alias)
                => new GenderTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.GenderType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.GenderType>(value));
            public AssignmentExpression Set(EnumElement<SimpleConsole.Data.GenderType> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region credit limit field expression
        public partial class CreditLimitField : NullableInt32FieldExpression<Person>
        {
            #region constructors
            public CreditLimitField(string identifier, PersonEntity entity) : base(identifier, entity)
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
        public partial class YearOfLastCreditLimitReviewField : NullableInt32FieldExpression<Person>
        {
            #region constructors
            public YearOfLastCreditLimitReviewField(string identifier, PersonEntity entity) : base(identifier, entity)
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
        public partial class DateCreatedField : DateTimeFieldExpression<Person>
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
            public override DateTimeElement As(string alias)
                => new DateCreatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Person>
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
            public override DateTimeElement As(string alias)
                => new DateUpdatedField(base.identifier, base.entity, alias);
            #endregion

            #region set
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region person address entity expression
    public partial class PersonAddressEntity : EntityExpression<PersonAddress>
    {
        #region interface properties
        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.IdField"/> representing the "dbo.Person_Address.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.PersonIdField"/> representing the "dbo.Person_Address.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PersonIdField PersonId;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.AddressIdField"/> representing the "dbo.Person_Address.AddressId" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>AddressId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly AddressIdField AddressId;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.DateCreatedField"/> representing the "dbo.Person_Address.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

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
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", this));
            Fields.Add($"{identifier}.AddressId", AddressId = new AddressIdField($"{identifier}.AddressId", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
        }
        #endregion

        #region methods
        public PersonAddressEntity As(string name)
            => new PersonAddressEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,PersonId
                ,AddressId
                ,DateCreated
            );
        }
		
        protected override InsertExpressionSet<PersonAddress> GetInclusiveInsertExpression(PersonAddress personAddress)
        {
            return new InsertExpressionSet<PersonAddress>(personAddress 
                ,new InsertExpression<int>(PersonId, personAddress.PersonId)
                ,new InsertExpression<int>(AddressId, personAddress.AddressId)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonAddress target, PersonAddress source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.AddressId != source.AddressId) { expr &= AddressId.Set(source.AddressId); }
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

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public IdField(string identifier, PersonAddressEntity entity) : base(identifier, entity)
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
            #endregion
        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public PersonIdField(string identifier, PersonAddressEntity entity) : base(identifier, entity)
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
        public partial class AddressIdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public AddressIdField(string identifier, PersonAddressEntity entity) : base(identifier, entity)
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
        public partial class DateCreatedField : DateTimeFieldExpression<PersonAddress>
        {
            #region constructors
            public DateCreatedField(string identifier, PersonAddressEntity entity) : base(identifier, entity)
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
        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.IdField"/> representing the "dbo.Product.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ProductCategoryTypeField"/> representing the "dbo.Product.ProductCategoryType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.ProductCategoryType"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ProductCategoryType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ProductCategoryTypeField ProductCategoryType;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.NameField"/> representing the "dbo.Product.Name" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Name</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(80)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NameField Name;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DescriptionField"/> representing the "dbo.Product.Description" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Description</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>nvarchar(2000)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DescriptionField Description;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ListPriceField"/> representing the "dbo.Product.ListPrice" column in the database, 
        /// with a .NET type of <see cref="double"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ListPrice</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ListPriceField ListPrice;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.PriceField"/> representing the "dbo.Product.Price" column in the database, 
        /// with a .NET type of <see cref="double"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Price</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PriceField Price;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.QuantityField"/> representing the "dbo.Product.Quantity" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Quantity</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly QuantityField Quantity;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ImageField"/> representing the "dbo.Product.Image" column in the database, 
        /// with a .NET type of <see cref="byte"/>[]
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Image</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varbinary(MAX)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ImageField Image;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.HeightField"/> representing the "dbo.Product.Height" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Height</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly HeightField Height;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.WidthField"/> representing the "dbo.Product.Width" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Width</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly WidthField Width;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DepthField"/> representing the "dbo.Product.Depth" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Depth</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DepthField Depth;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.WeightField"/> representing the "dbo.Product.Weight" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Weight</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly WeightField Weight;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ShippingWeightField"/> representing the "dbo.Product.ShippingWeight" column in the database, 
        /// with a .NET type of <see cref="decimal"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ShippingWeight</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ShippingWeightField ShippingWeight;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ValidStartTimeOfDayForPurchaseField"/> representing the "dbo.Product.ValidStartTimeOfDayForPurchase" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ValidStartTimeOfDayForPurchase</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>time</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ValidStartTimeOfDayForPurchaseField ValidStartTimeOfDayForPurchase;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ValidEndTimeOfDayForPurchaseField"/> representing the "dbo.Product.ValidEndTimeOfDayForPurchase" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ValidEndTimeOfDayForPurchase</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>time</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ValidEndTimeOfDayForPurchaseField ValidEndTimeOfDayForPurchase;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DateCreatedField"/> representing the "dbo.Product.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DateUpdatedField"/> representing the "dbo.Product.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

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
            => new ProductEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,ProductCategoryType
                ,Name
                ,Description
                ,ListPrice
                ,Price
                ,Quantity
                ,Image
                ,Height
                ,Width
                ,Depth
                ,Weight
                ,ShippingWeight
                ,ValidStartTimeOfDayForPurchase
                ,ValidEndTimeOfDayForPurchase
                ,DateCreated
                ,DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Product> GetInclusiveInsertExpression(Product product)
        {
            return new InsertExpressionSet<Product>(product 
                ,new InsertExpression<SimpleConsole.Data.ProductCategoryType?>(ProductCategoryType, product.ProductCategoryType)
                ,new InsertExpression<string>(Name, product.Name)
                ,new InsertExpression<string>(Description, product.Description)
                ,new InsertExpression<double>(ListPrice, product.ListPrice)
                ,new InsertExpression<double>(Price, product.Price)
                ,new InsertExpression<int>(Quantity, product.Quantity)
                ,new InsertExpression<byte[]>(Image, product.Image)
                ,new InsertExpression<decimal?>(Height, product.Height)
                ,new InsertExpression<decimal?>(Width, product.Width)
                ,new InsertExpression<decimal?>(Depth, product.Depth)
                ,new InsertExpression<decimal?>(Weight, product.Weight)
                ,new InsertExpression<decimal>(ShippingWeight, product.ShippingWeight)
                ,new InsertExpression<TimeSpan?>(ValidStartTimeOfDayForPurchase, product.ValidStartTimeOfDayForPurchase)
                ,new InsertExpression<TimeSpan?>(ValidEndTimeOfDayForPurchase, product.ValidEndTimeOfDayForPurchase)
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
            return expr;
        }

        protected override void HydrateEntity(Product product, ISqlFieldReader reader)
        {
			product.Id = reader.ReadField().GetValue<int>();
			product.ProductCategoryType = reader.ReadField().GetValue<SimpleConsole.Data.ProductCategoryType?>();
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
            #endregion
        }
        #endregion

        #region product category type field expression
        public partial class ProductCategoryTypeField : NullableEnumFieldExpression<Product, SimpleConsole.Data.ProductCategoryType>
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
            public override NullableEnumElement<SimpleConsole.Data.ProductCategoryType> As(string alias)
                => new ProductCategoryTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.ProductCategoryType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType>(value));
            public AssignmentExpression Set(EnumElement<SimpleConsole.Data.ProductCategoryType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.ProductCategoryType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType?>(value));
            public AssignmentExpression Set(NullableEnumElement<SimpleConsole.Data.ProductCategoryType> value) => new AssignmentExpression(this, value);
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
        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.IdField"/> representing the "dbo.Purchase.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PersonIdField"/> representing the "dbo.Purchase.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PersonIdField PersonId;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.OrderNumberField"/> representing the "dbo.Purchase.OrderNumber" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>OrderNumber</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly OrderNumberField OrderNumber;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.TotalPurchaseQuantityField"/> representing the "dbo.Purchase.TotalPurchaseQuantity" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalPurchaseQuantity</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalPurchaseQuantityField TotalPurchaseQuantity;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.TotalPurchaseAmountField"/> representing the "dbo.Purchase.TotalPurchaseAmount" column in the database, 
        /// with a .NET type of <see cref="double"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalPurchaseAmount</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalPurchaseAmountField TotalPurchaseAmount;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PurchaseDateField"/> representing the "dbo.Purchase.PurchaseDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchaseDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PurchaseDateField PurchaseDate;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.ShipDateField"/> representing the "dbo.Purchase.ShipDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ShipDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ShipDateField ShipDate;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.ExpectedDeliveryDateField"/> representing the "dbo.Purchase.ExpectedDeliveryDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ExpectedDeliveryDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ExpectedDeliveryDateField ExpectedDeliveryDate;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.TrackingIdentifierField"/> representing the "dbo.Purchase.TrackingIdentifier" column in the database, 
        /// with a .NET type of <see cref="Guid"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TrackingIdentifier</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>uniqueidentifier</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TrackingIdentifierField TrackingIdentifier;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PaymentMethodTypeField"/> representing the "dbo.Purchase.PaymentMethodType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.PaymentMethodType"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PaymentMethodType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PaymentMethodTypeField PaymentMethodType;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PaymentSourceTypeField"/> representing the "dbo.Purchase.PaymentSourceType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.PaymentSourceType"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PaymentSourceType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PaymentSourceTypeField PaymentSourceType;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.DateCreatedField"/> representing the "dbo.Purchase.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.DateUpdatedField"/> representing the "dbo.Purchase.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

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
            => new PurchaseEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,PersonId
                ,OrderNumber
                ,TotalPurchaseQuantity
                ,TotalPurchaseAmount
                ,PurchaseDate
                ,ShipDate
                ,ExpectedDeliveryDate
                ,TrackingIdentifier
                ,PaymentMethodType
                ,PaymentSourceType
                ,DateCreated
                ,DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Purchase> GetInclusiveInsertExpression(Purchase purchase)
        {
            return new InsertExpressionSet<Purchase>(purchase 
                ,new InsertExpression<int>(PersonId, purchase.PersonId)
                ,new InsertExpression<string>(OrderNumber, purchase.OrderNumber)
                ,new InsertExpression<int>(TotalPurchaseQuantity, purchase.TotalPurchaseQuantity)
                ,new InsertExpression<double>(TotalPurchaseAmount, purchase.TotalPurchaseAmount)
                ,new InsertExpression<DateTime>(PurchaseDate, purchase.PurchaseDate)
                ,new InsertExpression<DateTime?>(ShipDate, purchase.ShipDate)
                ,new InsertExpression<DateTime?>(ExpectedDeliveryDate, purchase.ExpectedDeliveryDate)
                ,new InsertExpression<Guid?>(TrackingIdentifier, purchase.TrackingIdentifier)
                ,new InsertExpression<SimpleConsole.Data.PaymentMethodType>(PaymentMethodType, purchase.PaymentMethodType)
                ,new InsertExpression<SimpleConsole.Data.PaymentSourceType?>(PaymentSourceType, purchase.PaymentSourceType)
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
			purchase.PaymentMethodType = reader.ReadField().GetValue<SimpleConsole.Data.PaymentMethodType>();
			purchase.PaymentSourceType = reader.ReadField().GetValue<SimpleConsole.Data.PaymentSourceType?>();
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
        public partial class PaymentMethodTypeField : EnumFieldExpression<Purchase, SimpleConsole.Data.PaymentMethodType>
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
            public override EnumElement<SimpleConsole.Data.PaymentMethodType> As(string alias)
                => new PaymentMethodTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.PaymentMethodType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentMethodType>(value));
            public AssignmentExpression Set(EnumElement<SimpleConsole.Data.PaymentMethodType> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region payment source type field expression
        public partial class PaymentSourceTypeField : NullableEnumFieldExpression<Purchase, SimpleConsole.Data.PaymentSourceType>
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
            public override NullableEnumElement<SimpleConsole.Data.PaymentSourceType> As(string alias)
                => new PaymentSourceTypeField(base.identifier, base.entity, alias);
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.PaymentSourceType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType>(value));
            public AssignmentExpression Set(EnumElement<SimpleConsole.Data.PaymentSourceType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.PaymentSourceType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType?>(value));
            public AssignmentExpression Set(NullableEnumElement<SimpleConsole.Data.PaymentSourceType> value) => new AssignmentExpression(this, value);
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
        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.IdField"/> representing the "dbo.PurchaseLine.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.PurchaseIdField"/> representing the "dbo.PurchaseLine.PurchaseId" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchaseId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PurchaseIdField PurchaseId;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.ProductIdField"/> representing the "dbo.PurchaseLine.ProductId" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ProductId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ProductIdField ProductId;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.PurchasePriceField"/> representing the "dbo.PurchaseLine.PurchasePrice" column in the database, 
        /// with a .NET type of <see cref="decimal"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchasePrice</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(12,2)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PurchasePriceField PurchasePrice;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.QuantityField"/> representing the "dbo.PurchaseLine.Quantity" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Quantity</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly QuantityField Quantity;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.PurchaseTotalField"/> representing the "dbo.PurchaseLine.PurchaseTotal" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchaseTotal</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(23,2)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>computed</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PurchaseTotalField PurchaseTotal;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.DateCreatedField"/> representing the "dbo.PurchaseLine.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.DateUpdatedField"/> representing the "dbo.PurchaseLine.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

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
            Fields.Add($"{identifier}.PurchaseTotal", PurchaseTotal = new PurchaseTotalField($"{identifier}.PurchaseTotal", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", this));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
            => new PurchaseLineEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,PurchaseId
                ,ProductId
                ,PurchasePrice
                ,Quantity
                ,PurchaseTotal
                ,DateCreated
                ,DateUpdated
            );
        }
		
        protected override InsertExpressionSet<PurchaseLine> GetInclusiveInsertExpression(PurchaseLine purchaseLine)
        {
            return new InsertExpressionSet<PurchaseLine>(purchaseLine 
                ,new InsertExpression<int>(PurchaseId, purchaseLine.PurchaseId)
                ,new InsertExpression<int>(ProductId, purchaseLine.ProductId)
                ,new InsertExpression<decimal>(PurchasePrice, purchaseLine.PurchasePrice)
                ,new InsertExpression<int>(Quantity, purchaseLine.Quantity)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PurchaseLine target, PurchaseLine source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PurchaseId != source.PurchaseId) { expr &= PurchaseId.Set(source.PurchaseId); }
            if (target.ProductId != source.ProductId) { expr &= ProductId.Set(source.ProductId); }
            if (target.PurchasePrice != source.PurchasePrice) { expr &= PurchasePrice.Set(source.PurchasePrice); }
            if (target.Quantity != source.Quantity) { expr &= Quantity.Set(source.Quantity); }
            return expr;
        }

        protected override void HydrateEntity(PurchaseLine purchaseLine, ISqlFieldReader reader)
        {
			purchaseLine.Id = reader.ReadField().GetValue<int>();
			purchaseLine.PurchaseId = reader.ReadField().GetValue<int>();
			purchaseLine.ProductId = reader.ReadField().GetValue<int>();
			purchaseLine.PurchasePrice = reader.ReadField().GetValue<decimal>();
			purchaseLine.Quantity = reader.ReadField().GetValue<int>();
			purchaseLine.PurchaseTotal = reader.ReadField().GetValue<decimal?>();
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

        #region purchase total field expression
        public partial class PurchaseTotalField : NullableDecimalFieldExpression<PurchaseLine>
        {
            #region constructors
            public PurchaseTotalField(string identifier, PurchaseLineEntity entity) : base(identifier, entity)
            {

            }

            private PurchaseTotalField(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
            {

            }
            #endregion

            #region as
            public override NullableDecimalElement As(string alias)
                => new PurchaseTotalField(base.identifier, base.entity, alias);
            #endregion

            #region set
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
        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.IdField"/> representing the "dbo.PersonTotalPurchasesView.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.TotalAmountField"/> representing the "dbo.PersonTotalPurchasesView.TotalAmount" column in the database, 
        /// with a .NET type of <see cref="double"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalAmount</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalAmountField TotalAmount;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.TotalCountField"/> representing the "dbo.PersonTotalPurchasesView.TotalCount" column in the database, 
        /// with a .NET type of <see cref="int"/>?
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalCount</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalCountField TotalCount;

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
            => new PersonTotalPurchasesViewEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,TotalAmount
                ,TotalCount
            );
        }
		
        protected override InsertExpressionSet<PersonTotalPurchasesView> GetInclusiveInsertExpression(PersonTotalPurchasesView personTotalPurchasesView)
        {
            return new InsertExpressionSet<PersonTotalPurchasesView>(personTotalPurchasesView 
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView target, PersonTotalPurchasesView source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

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
        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity"/> representing the "dbo.Address" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Address</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Address
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly AddressEntity Address;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity"/> representing the "dbo.Person" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Person</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Person
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly PersonEntity Person;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity"/> representing the "dbo.Person_Address" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Person_Address</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Person_Address
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly PersonAddressEntity PersonAddress;

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity"/> representing the "dbo.Product" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Product</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Product
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly ProductEntity Product;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity"/> representing the "dbo.Purchase" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Purchase</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Purchase
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly PurchaseEntity Purchase;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity"/> representing the "dbo.PurchaseLine" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchaseLine</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_PurchaseLine
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly PurchaseLineEntity PurchaseLine;

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity"/> representing the "dbo.PersonTotalPurchasesView" view in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonTotalPurchasesView</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly PersonTotalPurchasesViewEntity PersonTotalPurchasesView;

        #endregion

        #region constructors
        static dbo()
        { 
            Address = _schema.Address;
            Person = _schema.Person;
            PersonAddress = _schema.PersonAddress;
            Product = _schema.Product;
            Purchase = _schema.Purchase;
            PurchaseLine = _schema.PurchaseLine;
            PersonTotalPurchasesView = _schema.PersonTotalPurchasesView;
        }
        #endregion
    }
    #endregion
}
namespace SimpleConsole.secDataService
{
	using SimpleConsole.secData;

    #region sec schema expression
#pragma warning disable IDE1006 // Naming Styles
    public class secSchemaExpression : SchemaExpression
#pragma warning restore IDE1006 // Naming Styles
    {
        #region interface
        public readonly PersonEntity Person;
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
        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.IdField"/> representing the "sec.Person.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;

        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.SSNField"/> representing the "sec.Person.SSN" column in the database, 
        /// with a .NET type of <see cref="string"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>SSN</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>char(9)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly SSNField SSN;

        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.DateCreatedField"/> representing the "sec.Person.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetimeoffset</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.DateUpdatedField"/> representing the "sec.Person.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetimeoffset</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

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
            => new PersonEntity(this.identifier, this.schema, name);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id
                ,SSN
                ,DateCreated
                ,DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(person 
                ,new InsertExpression<string>(SSN, person.SSN)
                ,new InsertExpression<DateTimeOffset>(DateCreated, person.DateCreated)
                ,new InsertExpression<DateTimeOffset>(DateUpdated, person.DateUpdated)
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
        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity"/> representing the "sec.Person" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Person</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_secPerson
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static readonly PersonEntity Person;

        #endregion

        #region constructors
        static sec()
        { 
            Person = _schema.Person;
        }
        #endregion
    }
    #endregion
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
