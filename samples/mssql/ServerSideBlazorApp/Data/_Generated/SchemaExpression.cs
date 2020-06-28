using System;

namespace ServerSideBlazorApp.DataService
{
    using HatTrick.DbEx.MsSql.Builder;
    using HatTrick.DbEx.Sql.Configuration;
    using HatTrick.DbEx.Sql;

    #region db
    public class db : MsSqlExpressionBuilder
    {
		public static SqlConnection GetConnection()
        {
            if (!DbExpression.Configuration.Databases.TryGetValue("ServerSideBlazorApp", out var config))
                throw new DbExpressionConfigurationException($"Metadata for database named 'ServerSideBlazorApp' has not been provided.");
            return config.ConnectionFactory.CreateSqlConnection();
        }
    }
    #endregion
}

namespace ServerSideBlazorApp.dboDataService
{
    using HatTrick.DbEx.Sql.Expression;
    using System;
    using HatTrick.DbEx.Sql;

    #region dbo
    [Serializable]
    public class dboSchemaExpression : SchemaExpression
    {
        #region internals
        private const string _addressEntityName = "Address";
        private const string _personEntityName = "Person";
        private const string _personAddressEntityName = "Person_Address";
        private const string _productEntityName = "Product";
        private const string _purchaseEntityName = "Purchase";
        private const string _purchaseLineEntityName = "PurchaseLine";
        private const string _personTotalPurchasesViewEntityName = "PersonTotalPurchasesView";
        #endregion

        #region interface
        public AddressEntity Address { get { return Entities[_addressEntityName] as AddressEntity; } }
        public PersonEntity Person { get { return Entities[_personEntityName] as PersonEntity; } }
        public PersonAddressEntity PersonAddress { get { return Entities[_personAddressEntityName] as PersonAddressEntity; } }
        public ProductEntity Product { get { return Entities[_productEntityName] as ProductEntity; } }
        public PurchaseEntity Purchase { get { return Entities[_purchaseEntityName] as PurchaseEntity; } }
        public PurchaseLineEntity PurchaseLine { get { return Entities[_purchaseLineEntityName] as PurchaseLineEntity; } }
        public PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get { return Entities[_personTotalPurchasesViewEntityName] as PersonTotalPurchasesViewEntity; } }
        #endregion

        #region constructors
        public dboSchemaExpression(Lazy<ISqlSchemaMetadata> metadata) : base("dbo", metadata, null)
        {
            Entities.Add(_addressEntityName, new AddressEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_addressEntityName])));
            Entities.Add(_personEntityName, new PersonEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_personEntityName])));
            Entities.Add(_personAddressEntityName, new PersonAddressEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_personAddressEntityName])));
            Entities.Add(_productEntityName, new ProductEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_productEntityName])));
            Entities.Add(_purchaseEntityName, new PurchaseEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_purchaseEntityName])));
            Entities.Add(_purchaseLineEntityName, new PurchaseLineEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_purchaseLineEntityName])));
            Entities.Add(_personTotalPurchasesViewEntityName, new PersonTotalPurchasesViewEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_personTotalPurchasesViewEntityName])));
        }
        #endregion
    }
    #endregion
}
namespace ServerSideBlazorApp.secDataService
{
    using HatTrick.DbEx.Sql.Expression;
    using System;
    using HatTrick.DbEx.Sql;

    #region sec
    [Serializable]
    public class secSchemaExpression : SchemaExpression
    {
        #region internals
        private const string _personEntityName = "Person";
        #endregion

        #region interface
        public PersonEntity Person { get { return Entities[_personEntityName] as PersonEntity; } }
        #endregion

        #region constructors
        public secSchemaExpression(Lazy<ISqlSchemaMetadata> metadata) : base("sec", metadata, null)
        {
            Entities.Add(_personEntityName, new PersonEntity(this, new Lazy<ISqlEntityMetadata>(() => metadata.Value.Entities[_personEntityName])));
        }
        #endregion
    }
    #endregion
}