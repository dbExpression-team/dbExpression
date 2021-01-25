using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Data;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.secDataService;

namespace ServerSideBlazorApp.DataService
{
    #region db meta
    public class CRMDatabaseSqlDatabaseMetadata : ISqlDatabaseMetadata
    {
        #region interface
        public string Identifier { get; private set; }
        public string Name { get; private set; }
        public IDictionary<string, ISqlSchemaMetadata> Schemas { get; } = new Dictionary<string, ISqlSchemaMetadata>();
        #endregion

        #region constructors
        public CRMDatabaseSqlDatabaseMetadata(string identifier, string name)
        {
            Identifier = identifier;
            Name = name;
            Schemas.Add("dbo", new dboSchemaMetadata(this, "dbo", "dbo"));
            Schemas.Add("sec", new secSchemaMetadata(this, "sec", "sec"));
        }
        #endregion
    }
    #endregion
}

namespace ServerSideBlazorApp.dboDataService
{
    #region dbo
	public class dboSchemaMetadata : ISqlSchemaMetadata
    {
		#region interface
        public ISqlDatabaseMetadata Database { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlEntityMetadata> Entities { get; } = new Dictionary<string, ISqlEntityMetadata>();
		#endregion

        #region constructors
        public dboSchemaMetadata(ISqlDatabaseMetadata database, string identifier, string name)
        {
            Database = database;
            Identifier = identifier;
            Name = name;
            Entities.Add($"{identifier}.Address", new AddressEntityMetadata(this, $"{identifier}.Address", "Address"));
            Entities.Add($"{identifier}.Person", new CustomerEntityMetadata(this, $"{identifier}.Person", "Person"));
            Entities.Add($"{identifier}.Person_Address", new CustomerAddressEntityMetadata(this, $"{identifier}.Person_Address", "Person_Address"));
            Entities.Add($"{identifier}.Product", new ProductEntityMetadata(this, $"{identifier}.Product", "Product"));
            Entities.Add($"{identifier}.Purchase", new PurchaseEntityMetadata(this, $"{identifier}.Purchase", "Purchase"));
            Entities.Add($"{identifier}.PurchaseLine", new PurchaseLineEntityMetadata(this, $"{identifier}.PurchaseLine", "PurchaseLine"));
            Entities.Add($"{identifier}.PersonTotalPurchasesView", new PersonTotalPurchasesViewEntityMetadata(this, $"{identifier}.PersonTotalPurchasesView", "PersonTotalPurchasesView"));
        }
        #endregion
    }
    #endregion

    #region address
	public class AddressEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public AddressEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int) { IsIdentity = true });
            Fields.Add($"{identifier}.AddressType", new MsSqlFieldMetadata(this, $"{identifier}.AddressType", "AddressType", SqlDbType.Int));
            Fields.Add($"{identifier}.Line1", new MsSqlFieldMetadata(this, $"{identifier}.Line1", "Line1", SqlDbType.VarChar, 50));
            Fields.Add($"{identifier}.Line2", new MsSqlFieldMetadata(this, $"{identifier}.Line2", "Line2", SqlDbType.VarChar, 50));
            Fields.Add($"{identifier}.City", new MsSqlFieldMetadata(this, $"{identifier}.City", "City", SqlDbType.VarChar, 60));
            Fields.Add($"{identifier}.State", new MsSqlFieldMetadata(this, $"{identifier}.State", "State", SqlDbType.Char, 2));
            Fields.Add($"{identifier}.Zip", new MsSqlFieldMetadata(this, $"{identifier}.Zip", "Zip", SqlDbType.VarChar, 10));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
            Fields.Add($"{identifier}.DateUpdated", new MsSqlFieldMetadata(this, $"{identifier}.DateUpdated", "DateUpdated", SqlDbType.DateTime));
        }
        #endregion
    }
    #endregion

    #region customer
	public class CustomerEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public CustomerEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int) { IsIdentity = true });
            Fields.Add($"{identifier}.FirstName", new MsSqlFieldMetadata(this, $"{identifier}.FirstName", "FirstName", SqlDbType.VarChar, 20));
            Fields.Add($"{identifier}.LastName", new MsSqlFieldMetadata(this, $"{identifier}.LastName", "LastName", SqlDbType.VarChar, 20));
            Fields.Add($"{identifier}.BirthDate", new MsSqlFieldMetadata(this, $"{identifier}.BirthDate", "BirthDate", SqlDbType.Date));
            Fields.Add($"{identifier}.GenderType", new MsSqlFieldMetadata(this, $"{identifier}.GenderType", "GenderType", SqlDbType.Int));
            Fields.Add($"{identifier}.CreditLimit", new MsSqlFieldMetadata(this, $"{identifier}.CreditLimit", "CreditLimit", SqlDbType.Int));
            Fields.Add($"{identifier}.YearOfLastCreditLimitReview", new MsSqlFieldMetadata(this, $"{identifier}.YearOfLastCreditLimitReview", "YearOfLastCreditLimitReview", SqlDbType.Int));
            Fields.Add($"{identifier}.RegistrationDate", new MsSqlFieldMetadata(this, $"{identifier}.RegistrationDate", "RegistrationDate", SqlDbType.DateTimeOffset, 10));
            Fields.Add($"{identifier}.LastLoginDate", new MsSqlFieldMetadata(this, $"{identifier}.LastLoginDate", "LastLoginDate", SqlDbType.DateTimeOffset, 10));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
            Fields.Add($"{identifier}.DateUpdated", new MsSqlFieldMetadata(this, $"{identifier}.DateUpdated", "DateUpdated", SqlDbType.DateTime));
        }
        #endregion
    }
    #endregion

    #region customer address
	public class CustomerAddressEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public CustomerAddressEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int) { IsIdentity = true });
            Fields.Add($"{identifier}.PersonId", new MsSqlFieldMetadata(this, $"{identifier}.PersonId", "PersonId", SqlDbType.Int));
            Fields.Add($"{identifier}.AddressId", new MsSqlFieldMetadata(this, $"{identifier}.AddressId", "AddressId", SqlDbType.Int));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
        }
        #endregion
    }
    #endregion

    #region product
	public class ProductEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public ProductEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int) { IsIdentity = true });
            Fields.Add($"{identifier}.ProductCategoryType", new MsSqlFieldMetadata(this, $"{identifier}.ProductCategoryType", "ProductCategoryType", SqlDbType.Int));
            Fields.Add($"{identifier}.Name", new MsSqlFieldMetadata(this, $"{identifier}.Name", "Name", SqlDbType.VarChar, 80));
            Fields.Add($"{identifier}.Description", new MsSqlFieldMetadata(this, $"{identifier}.Description", "Description", SqlDbType.NVarChar, 4000));
            Fields.Add($"{identifier}.ListPrice", new MsSqlFieldMetadata(this, $"{identifier}.ListPrice", "ListPrice", SqlDbType.Money));
            Fields.Add($"{identifier}.Price", new MsSqlFieldMetadata(this, $"{identifier}.Price", "Price", SqlDbType.Money));
            Fields.Add($"{identifier}.Quantity", new MsSqlFieldMetadata(this, $"{identifier}.Quantity", "Quantity", SqlDbType.Int));
            Fields.Add($"{identifier}.Image", new MsSqlFieldMetadata(this, $"{identifier}.Image", "Image", SqlDbType.VarBinary, -1));
            Fields.Add($"{identifier}.Height", new MsSqlFieldMetadata(this, $"{identifier}.Height", "Height", SqlDbType.Decimal, 4, 1));
            Fields.Add($"{identifier}.Width", new MsSqlFieldMetadata(this, $"{identifier}.Width", "Width", SqlDbType.Decimal, 4, 1));
            Fields.Add($"{identifier}.Depth", new MsSqlFieldMetadata(this, $"{identifier}.Depth", "Depth", SqlDbType.Decimal, 4, 1));
            Fields.Add($"{identifier}.Weight", new MsSqlFieldMetadata(this, $"{identifier}.Weight", "Weight", SqlDbType.Decimal, 4, 1));
            Fields.Add($"{identifier}.ShippingWeight", new MsSqlFieldMetadata(this, $"{identifier}.ShippingWeight", "ShippingWeight", SqlDbType.Decimal, 4, 1));
            Fields.Add($"{identifier}.ValidStartTimeOfDayForPurchase", new MsSqlFieldMetadata(this, $"{identifier}.ValidStartTimeOfDayForPurchase", "ValidStartTimeOfDayForPurchase", SqlDbType.Time, 5));
            Fields.Add($"{identifier}.ValidEndTimeOfDayForPurchase", new MsSqlFieldMetadata(this, $"{identifier}.ValidEndTimeOfDayForPurchase", "ValidEndTimeOfDayForPurchase", SqlDbType.Time, 5));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
            Fields.Add($"{identifier}.DateUpdated", new MsSqlFieldMetadata(this, $"{identifier}.DateUpdated", "DateUpdated", SqlDbType.DateTime));
        }
        #endregion
    }
    #endregion

    #region purchase
	public class PurchaseEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PurchaseEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int) { IsIdentity = true });
            Fields.Add($"{identifier}.PersonId", new MsSqlFieldMetadata(this, $"{identifier}.PersonId", "PersonId", SqlDbType.Int));
            Fields.Add($"{identifier}.OrderNumber", new MsSqlFieldMetadata(this, $"{identifier}.OrderNumber", "OrderNumber", SqlDbType.VarChar, 20));
            Fields.Add($"{identifier}.TotalPurchaseQuantity", new MsSqlFieldMetadata(this, $"{identifier}.TotalPurchaseQuantity", "TotalPurchaseQuantity", SqlDbType.Int));
            Fields.Add($"{identifier}.TotalPurchaseAmount", new MsSqlFieldMetadata(this, $"{identifier}.TotalPurchaseAmount", "TotalPurchaseAmount", SqlDbType.Money));
            Fields.Add($"{identifier}.PurchaseDate", new MsSqlFieldMetadata(this, $"{identifier}.PurchaseDate", "PurchaseDate", SqlDbType.DateTime));
            Fields.Add($"{identifier}.ShipDate", new MsSqlFieldMetadata(this, $"{identifier}.ShipDate", "ShipDate", SqlDbType.DateTime));
            Fields.Add($"{identifier}.ExpectedDeliveryDate", new MsSqlFieldMetadata(this, $"{identifier}.ExpectedDeliveryDate", "ExpectedDeliveryDate", SqlDbType.DateTime));
            Fields.Add($"{identifier}.TrackingIdentifier", new MsSqlFieldMetadata(this, $"{identifier}.TrackingIdentifier", "TrackingIdentifier", SqlDbType.UniqueIdentifier));
            Fields.Add($"{identifier}.PaymentMethodType", new MsSqlFieldMetadata(this, $"{identifier}.PaymentMethodType", "PaymentMethodType", SqlDbType.VarChar, 20));
            Fields.Add($"{identifier}.PaymentSourceType", new MsSqlFieldMetadata(this, $"{identifier}.PaymentSourceType", "PaymentSourceType", SqlDbType.VarChar, 20));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
            Fields.Add($"{identifier}.DateUpdated", new MsSqlFieldMetadata(this, $"{identifier}.DateUpdated", "DateUpdated", SqlDbType.DateTime));
        }
        #endregion
    }
    #endregion

    #region purchase line
	public class PurchaseLineEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PurchaseLineEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int) { IsIdentity = true });
            Fields.Add($"{identifier}.PurchaseId", new MsSqlFieldMetadata(this, $"{identifier}.PurchaseId", "PurchaseId", SqlDbType.Int));
            Fields.Add($"{identifier}.ProductId", new MsSqlFieldMetadata(this, $"{identifier}.ProductId", "ProductId", SqlDbType.Int));
            Fields.Add($"{identifier}.PurchasePrice", new MsSqlFieldMetadata(this, $"{identifier}.PurchasePrice", "PurchasePrice", SqlDbType.Decimal, 12, 2));
            Fields.Add($"{identifier}.Quantity", new MsSqlFieldMetadata(this, $"{identifier}.Quantity", "Quantity", SqlDbType.Int));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
            Fields.Add($"{identifier}.DateUpdated", new MsSqlFieldMetadata(this, $"{identifier}.DateUpdated", "DateUpdated", SqlDbType.DateTime));
        }
        #endregion
    }
    #endregion

    #region person total purchases view
	public class PersonTotalPurchasesViewEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PersonTotalPurchasesViewEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int));
            Fields.Add($"{identifier}.TotalAmount", new MsSqlFieldMetadata(this, $"{identifier}.TotalAmount", "TotalAmount", SqlDbType.Money));
            Fields.Add($"{identifier}.TotalCount", new MsSqlFieldMetadata(this, $"{identifier}.TotalCount", "TotalCount", SqlDbType.Int));
        }
        #endregion
    }
    #endregion

}
namespace ServerSideBlazorApp.secDataService
{
    #region sec
	public class secSchemaMetadata : ISqlSchemaMetadata
    {
		#region interface
        public ISqlDatabaseMetadata Database { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlEntityMetadata> Entities { get; } = new Dictionary<string, ISqlEntityMetadata>();
		#endregion

        #region constructors
        public secSchemaMetadata(ISqlDatabaseMetadata database, string identifier, string name)
        {
            Database = database;
            Identifier = identifier;
            Name = name;
            Entities.Add($"{identifier}.Person", new PersonEntityMetadata(this, $"{identifier}.Person", "Person"));
        }
        #endregion
    }
    #endregion

    #region person
	public class PersonEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PersonEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int));
            Fields.Add($"{identifier}.SSN", new MsSqlFieldMetadata(this, $"{identifier}.SSN", "SSN", SqlDbType.Char, 11));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
            Fields.Add($"{identifier}.DateUpdated", new MsSqlFieldMetadata(this, $"{identifier}.DateUpdated", "DateUpdated", SqlDbType.DateTime));
        }
        #endregion
    }
    #endregion

}
