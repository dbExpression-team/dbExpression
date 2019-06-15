namespace DataService
{
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.MsSql.Builder;
    using HatTrick.DbEx.Sql.Configuration;
    using HatTrick.DbEx.Sql;

    #region db
    public class db : MsSqlExpressionBuilder
    {
		public static SqlConnection GetConnection()
        {
            if (!DbExpression.Configuration.Databases.TryGetValue("MsSqlDbExTest-design", out var config))
                throw new DbExpressionConfigurationException($"Metadata for database named 'MsSqlDbExTest-design' has not been provided.");
            return config.DatabaseConfiguration.ConnectionFactory.CreateSqlConnection();
        }
    }
    #endregion
}

namespace DataService
{
    using HatTrick.DbEx.Sql.Expression;
    using DataService.EntityExpression.dbo;
    using System;
    using HatTrick.DbEx.Sql;

    #region dbo
    [Serializable]
    public class dboSchema : SchemaExpression
    {
        #region internals
        private const string _addressEntityName = "Address";
        private const string _personEntityName = "Person";
        private const string _person_AddressEntityName = "Person_Address";
        private const string _productEntityName = "Product";
        private const string _purchaseEntityName = "Purchase";
        private const string _purchaseLineEntityName = "PurchaseLine";

		private const string _personTotalPurchasesViewEntityName = "PersonTotalPurchasesView";
        #endregion

        #region interface
        public AddressEntity Address { get { return Entities[_addressEntityName].Value as AddressEntity; } }
        public PersonEntity Person { get { return Entities[_personEntityName].Value as PersonEntity; } }
        public Person_AddressEntity Person_Address { get { return Entities[_person_AddressEntityName].Value as Person_AddressEntity; } }
        public ProductEntity Product { get { return Entities[_productEntityName].Value as ProductEntity; } }
        public PurchaseEntity Purchase { get { return Entities[_purchaseEntityName].Value as PurchaseEntity; } }
        public PurchaseLineEntity PurchaseLine { get { return Entities[_purchaseLineEntityName].Value as PurchaseLineEntity; } }

        public PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get { return Entities[_personTotalPurchasesViewEntityName].Value as PersonTotalPurchasesViewEntity; } }
        #endregion

        #region constructors
        public dboSchema(ISqlSchemaMetadata metadata) : base(metadata, null)
        {
            Entities.Add(_addressEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new AddressEntity(this, metadata.Entities[_addressEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_addressEntityName}'"))));
            Entities.Add(_personEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new PersonEntity(this, metadata.Entities[_personEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_personEntityName}'"))));
            Entities.Add(_person_AddressEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new Person_AddressEntity(this, metadata.Entities[_person_AddressEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_person_AddressEntityName}'"))));
            Entities.Add(_productEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new ProductEntity(this, metadata.Entities[_productEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_productEntityName}'"))));
            Entities.Add(_purchaseEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new PurchaseEntity(this, metadata.Entities[_purchaseEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_purchaseEntityName}'"))));
            Entities.Add(_purchaseLineEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new PurchaseLineEntity(this, metadata.Entities[_purchaseLineEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_purchaseLineEntityName}'"))));

			Entities.Add(_personTotalPurchasesViewEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new PersonTotalPurchasesViewEntity(this, metadata.Entities[_personTotalPurchasesViewEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_personTotalPurchasesViewEntityName}'"))));
        }
        #endregion
    }
    #endregion
}
namespace DataService
{
    using HatTrick.DbEx.Sql.Expression;
    using DataService.EntityExpression.sec;
    using System;
    using HatTrick.DbEx.Sql;

    #region sec
    [Serializable]
    public class secSchema : SchemaExpression
    {
        #region internals
        private const string _personEntityName = "Person";

        #endregion

        #region interface
        public PersonEntity Person { get { return Entities[_personEntityName].Value as PersonEntity; } }

        #endregion

        #region constructors
        public secSchema(ISqlSchemaMetadata metadata) : base(metadata, null)
        {
            Entities.Add(_personEntityName, new Lazy<HatTrick.DbEx.Sql.Expression.EntityExpression>(() => new PersonEntity(this, metadata.Entities[_personEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema '{metadata.Name}' does not contain entity metadata for '{_personEntityName}'"))));

        }
        #endregion
    }
    #endregion
}