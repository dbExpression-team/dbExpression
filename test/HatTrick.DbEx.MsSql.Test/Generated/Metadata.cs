namespace DataService.Metadata
{
    using HatTrick.DbEx.MsSql;
    using HatTrick.DbEx.Sql;

    public class MsSqlDbExTestDatabaseMetadataProvider : IDatabaseMetadataProvider
    {
        #region interface
        public ISqlDatabaseMetadata Database { get; private set; }
        #endregion

        #region constructors
        public MsSqlDbExTestDatabaseMetadataProvider()
        {
			Database = new MsSqlDatabaseMetadata();   

            Database.Schemas.Add("dbo", new dbo.SchemaMetadata(Database));
            Database.Schemas.Add("sec", new sec.SchemaMetadata(Database));
        }
        #endregion
    }
}

namespace DataService.Metadata.dbo
{
	using HatTrick.DbEx.MsSql.Expression;
    using HatTrick.DbEx.Sql;
    using System.Collections.Generic;
    using System.Data;

	public class SchemaMetadata : ISqlSchemaMetadata
    {
		#region interface
        public string Name => "dbo";
        public ISqlDatabaseMetadata Database { get; }
        public IDictionary<string, ISqlEntityMetadata> Entities { get; } = new Dictionary<string, ISqlEntityMetadata>();
		#endregion

        #region constructors
        public SchemaMetadata(ISqlDatabaseMetadata database)
        {
            Database = database;
            Entities.Add("Address", new AddressEntityMetadata(this));
            Entities.Add("Person", new PersonEntityMetadata(this));
            Entities.Add("Person_Address", new PersonAddressEntityMetadata(this));
            Entities.Add("Product", new ProductEntityMetadata(this));
            Entities.Add("Purchase", new PurchaseEntityMetadata(this));
            Entities.Add("PurchaseLine", new PurchaseLineEntityMetadata(this));

            Entities.Add("PersonTotalPurchasesView", new PersonTotalPurchasesViewEntityMetadata(this));
        }
        #endregion
    }

	public class AddressEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "Address";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public AddressEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4){ IsIdentity = true });
            Fields.Add("AddressType", new MsSqlFieldMetadata(this, "AddressType", SqlDbType.Int, 4));
            Fields.Add("Line1", new MsSqlFieldMetadata(this, "Line1", SqlDbType.VarChar, 50));
            Fields.Add("Line2", new MsSqlFieldMetadata(this, "Line2", SqlDbType.VarChar, 50));
            Fields.Add("City", new MsSqlFieldMetadata(this, "City", SqlDbType.VarChar, 60));
            Fields.Add("State", new MsSqlFieldMetadata(this, "State", SqlDbType.Char, 2));
            Fields.Add("Zip", new MsSqlFieldMetadata(this, "Zip", SqlDbType.VarChar, 10));
            Fields.Add("DateCreated", new MsSqlFieldMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            Fields.Add("DateUpdated", new MsSqlFieldMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }
        #endregion
    }
	public class PersonEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "Person";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PersonEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4){ IsIdentity = true });
            Fields.Add("FirstName", new MsSqlFieldMetadata(this, "FirstName", SqlDbType.VarChar, 20));
            Fields.Add("LastName", new MsSqlFieldMetadata(this, "LastName", SqlDbType.VarChar, 20));
            Fields.Add("BirthDate", new MsSqlFieldMetadata(this, "BirthDate", SqlDbType.DateTime, 8));
            Fields.Add("GenderType", new MsSqlFieldMetadata(this, "GenderType", SqlDbType.Int, 4));
            Fields.Add("CreditLimit", new MsSqlFieldMetadata(this, "CreditLimit", SqlDbType.Int, 4));
            Fields.Add("YearOfLastCreditLimitReview", new MsSqlFieldMetadata(this, "YearOfLastCreditLimitReview", SqlDbType.Int, 4));
            Fields.Add("DateCreated", new MsSqlFieldMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            Fields.Add("DateUpdated", new MsSqlFieldMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }
        #endregion
    }
	public class PersonAddressEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "Person_Address";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PersonAddressEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4){ IsIdentity = true });
            Fields.Add("PersonId", new MsSqlFieldMetadata(this, "PersonId", SqlDbType.Int, 4));
            Fields.Add("AddressId", new MsSqlFieldMetadata(this, "AddressId", SqlDbType.Int, 4));
            Fields.Add("DateCreated", new MsSqlFieldMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
        }
        #endregion
    }
	public class ProductEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "Product";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public ProductEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4){ IsIdentity = true });
            Fields.Add("ProductCategoryType", new MsSqlFieldMetadata(this, "ProductCategoryType", SqlDbType.Int, 4));
            Fields.Add("Name", new MsSqlFieldMetadata(this, "Name", SqlDbType.VarChar, 80));
            Fields.Add("Description", new MsSqlFieldMetadata(this, "Description", SqlDbType.VarChar, 2000));
            Fields.Add("ListPrice", new MsSqlFieldMetadata(this, "ListPrice", SqlDbType.Decimal, 9));
            Fields.Add("Price", new MsSqlFieldMetadata(this, "Price", SqlDbType.Decimal, 9));
            Fields.Add("Quantity", new MsSqlFieldMetadata(this, "Quantity", SqlDbType.Int, 4));
            Fields.Add("DateCreated", new MsSqlFieldMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            Fields.Add("DateUpdated", new MsSqlFieldMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }
        #endregion
    }
	public class PurchaseEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "Purchase";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PurchaseEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4){ IsIdentity = true });
            Fields.Add("PersonId", new MsSqlFieldMetadata(this, "PersonId", SqlDbType.Int, 4));
            Fields.Add("TotalPurchaseAmount", new MsSqlFieldMetadata(this, "TotalPurchaseAmount", SqlDbType.Decimal, 9));
            Fields.Add("PurchaseDate", new MsSqlFieldMetadata(this, "PurchaseDate", SqlDbType.DateTime, 8));
            Fields.Add("ShipDate", new MsSqlFieldMetadata(this, "ShipDate", SqlDbType.DateTime, 8));
            Fields.Add("ExpectedDeliveryDate", new MsSqlFieldMetadata(this, "ExpectedDeliveryDate", SqlDbType.DateTime, 8));
            Fields.Add("TrackingIdentifier", new MsSqlFieldMetadata(this, "TrackingIdentifier", SqlDbType.UniqueIdentifier, 16));
            Fields.Add("DateCreated", new MsSqlFieldMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            Fields.Add("DateUpdated", new MsSqlFieldMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }
        #endregion
    }
	public class PurchaseLineEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "PurchaseLine";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PurchaseLineEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4){ IsIdentity = true });
            Fields.Add("PurchaseId", new MsSqlFieldMetadata(this, "PurchaseId", SqlDbType.Int, 4));
            Fields.Add("ProductId", new MsSqlFieldMetadata(this, "ProductId", SqlDbType.Int, 4));
            Fields.Add("PurchasePrice", new MsSqlFieldMetadata(this, "PurchasePrice", SqlDbType.Decimal, 9));
            Fields.Add("Quantity", new MsSqlFieldMetadata(this, "Quantity", SqlDbType.Int, 4));
            Fields.Add("DateCreated", new MsSqlFieldMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            Fields.Add("DateUpdated", new MsSqlFieldMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }
        #endregion
    }

	public class PersonTotalPurchasesViewEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "PersonTotalPurchasesView";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PersonTotalPurchasesViewEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4));
            Fields.Add("TotalPurchases", new MsSqlFieldMetadata(this, "TotalPurchases", SqlDbType.Decimal, 17));
        }
        #endregion
    }
}
namespace DataService.Metadata.sec
{
	using HatTrick.DbEx.MsSql.Expression;
    using HatTrick.DbEx.Sql;
    using System.Collections.Generic;
    using System.Data;

	public class SchemaMetadata : ISqlSchemaMetadata
    {
		#region interface
        public string Name => "sec";
        public ISqlDatabaseMetadata Database { get; }
        public IDictionary<string, ISqlEntityMetadata> Entities { get; } = new Dictionary<string, ISqlEntityMetadata>();
		#endregion

        #region constructors
        public SchemaMetadata(ISqlDatabaseMetadata database)
        {
            Database = database;
            Entities.Add("Person", new PersonEntityMetadata(this));

        }
        #endregion
    }

	public class PersonEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public string Name => "Person";
        public ISqlSchemaMetadata Schema { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PersonEntityMetadata(ISqlSchemaMetadata schema)
        {
            Schema = schema;
			//TODO: JRod, add overload to MsSqlFieldMetadata that accepts name, type, size, precision, and scale...
            Fields.Add("Id", new MsSqlFieldMetadata(this, "Id", SqlDbType.Int, 4){ IsIdentity = true });
            Fields.Add("SSN", new MsSqlFieldMetadata(this, "SSN", SqlDbType.Char, 9));
            Fields.Add("DateCreated", new MsSqlFieldMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            Fields.Add("DateUpdated", new MsSqlFieldMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }
        #endregion
    }

}