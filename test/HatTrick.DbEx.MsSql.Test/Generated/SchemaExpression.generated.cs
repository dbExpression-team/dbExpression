namespace DataService
{
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.MsSql.Builder;

    #region db
    public class db : MsSqlExpressionBuilder
    {
        public db(ExpressionSet expression) : base(expression)
        { }
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
        public AddressEntity Address { get; }
        public PersonEntity Person { get; }
        public Person_AddressEntity Person_Address { get; }
        public ProductEntity Product { get; }
        public PurchaseEntity Purchase { get; }
        public PurchaseLineEntity PurchaseLine { get; }
        public PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get; }
        #endregion

        #region constructors
        public dboSchema(ISqlSchemaMetadata schema)
            : base(schema, null)
        {
            if (schema.Entities == null)
                throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entities");
            Address = new AddressEntity(this, schema.Entities[_addressEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_addressEntityName}'"), null);
            Person = new PersonEntity(this, schema.Entities[_personEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_personEntityName}'"), null);
            Person_Address = new Person_AddressEntity(this, schema.Entities[_person_AddressEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_person_AddressEntityName}'"), null);
            Product = new ProductEntity(this, schema.Entities[_productEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_productEntityName}'"), null);
            Purchase = new PurchaseEntity(this, schema.Entities[_purchaseEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_purchaseEntityName}'"), null);
            PurchaseLine = new PurchaseLineEntity(this, schema.Entities[_purchaseLineEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_purchaseLineEntityName}'"), null);
            PersonTotalPurchasesView = new PersonTotalPurchasesViewEntity(this, schema.Entities[_personTotalPurchasesViewEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_personTotalPurchasesViewEntityName}'"), null);
        }
        #endregion
    }
    #endregion
}

namespace DataService
{
    using System;
    using HatTrick.DbEx.Sql.Expression;
    using DataService.EntityExpression.sec;
    using HatTrick.DbEx.Sql;

    #region sec
    [Serializable]
    public class secSchema : SchemaExpression
    {
        #region internals
        private const string _personEntityName = "Person";
        #endregion

        #region interface
        public PersonEntity Person { get; }
        #endregion

        #region constructors
        public secSchema(ISqlSchemaMetadata schema)
            : base(schema, null)
        {
            if (schema.Entities == null)
                throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entities");
            Person = new PersonEntity(this, schema.Entities[_personEntityName] ?? throw new DbExpressionConfigurationException($"Configuration for schema {schema.Name} does not contain metadata for entity '{_personEntityName}'"), null);
        }
        #endregion
    }
    #endregion
}
