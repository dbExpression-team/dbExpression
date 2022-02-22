using HatTrick.DbEx.MsSql;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Data;
using DbEx.dboDataService;
using DbEx.secDataService;

namespace DbEx.DataService
{
    #region db meta
    public class MsSqlDbSqlDatabaseMetadata : ISqlDatabaseMetadata
    {
        #region interface
        public string Identifier { get; private set; }
        public string Name { get; private set; }
        public IDictionary<string, ISqlSchemaMetadata> Schemas { get; } = new Dictionary<string, ISqlSchemaMetadata>();
        #endregion

        #region constructors
        public MsSqlDbSqlDatabaseMetadata(string identifier, string name)
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

namespace DbEx.dboDataService
{
    #region dbo
	public class dboSchemaMetadata : ISqlSchemaMetadata
    {
		#region interface
        public ISqlDatabaseMetadata Database { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlEntityMetadata> Entities { get; } = new Dictionary<string, ISqlEntityMetadata>();
        public IDictionary<string, ISqlStoredProcedureMetadata> StoredProcedures { get; } = new Dictionary<string, ISqlStoredProcedureMetadata>();
        #endregion

        #region constructors
        public dboSchemaMetadata(ISqlDatabaseMetadata database, string identifier, string name)
        {
            Database = database;
            Identifier = identifier;
            Name = name;
            Entities.Add($"{identifier}.AccessAuditLog", new AccessAuditLogEntityMetadata(this, $"{identifier}.AccessAuditLog", "AccessAuditLog"));
            Entities.Add($"{identifier}.Address", new AddressEntityMetadata(this, $"{identifier}.Address", "Address"));
            Entities.Add($"{identifier}.Person", new PersonEntityMetadata(this, $"{identifier}.Person", "Person"));
            Entities.Add($"{identifier}.Person_Address", new PersonAddressEntityMetadata(this, $"{identifier}.Person_Address", "Person_Address"));
            Entities.Add($"{identifier}.Product", new ProductEntityMetadata(this, $"{identifier}.Product", "Product"));
            Entities.Add($"{identifier}.Purchase", new PurchaseEntityMetadata(this, $"{identifier}.Purchase", "Purchase"));
            Entities.Add($"{identifier}.PurchaseLine", new PurchaseLineEntityMetadata(this, $"{identifier}.PurchaseLine", "PurchaseLine"));
            Entities.Add($"{identifier}.UnitTest", new UnitTestEntityMetadata(this, $"{identifier}.UnitTest", "UnitTest"));
            Entities.Add($"{identifier}.PersonTotalPurchasesView", new PersonTotalPurchasesViewEntityMetadata(this, $"{identifier}.PersonTotalPurchasesView", "PersonTotalPurchasesView"));
            StoredProcedures.Add($"{identifier}.SelectPerson_As_Dynamic_With_Input", new SelectPerson_As_Dynamic_With_InputStoredProcedureMetadata(this, $"{identifier}.SelectPerson_As_Dynamic_With_Input", "SelectPerson_As_Dynamic_With_Input"));
            StoredProcedures.Add($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput", new SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedureMetadata(this, $"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput", "SelectPerson_As_Dynamic_With_Input_And_InputOutput"));
            StoredProcedures.Add($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output", new SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedureMetadata(this, $"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output", "SelectPerson_As_Dynamic_With_Input_And_Output"));
            StoredProcedures.Add($"{identifier}.SelectPerson_As_DynamicList_With_Input", new SelectPerson_As_DynamicList_With_InputStoredProcedureMetadata(this, $"{identifier}.SelectPerson_As_DynamicList_With_Input", "SelectPerson_As_DynamicList_With_Input"));
            StoredProcedures.Add($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput", new SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedureMetadata(this, $"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput", "SelectPerson_As_DynamicList_With_Input_And_InputOutput"));
            StoredProcedures.Add($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output", new SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedureMetadata(this, $"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output", "SelectPerson_As_DynamicList_With_Input_And_Output"));
            StoredProcedures.Add($"{identifier}.SelectPersonId_As_ScalarValue_With_Input", new SelectPersonId_As_ScalarValue_With_InputStoredProcedureMetadata(this, $"{identifier}.SelectPersonId_As_ScalarValue_With_Input", "SelectPersonId_As_ScalarValue_With_Input"));
            StoredProcedures.Add($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", new SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedureMetadata(this, $"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", "SelectPersonId_As_ScalarValue_With_Input_And_Default_Value"));
            StoredProcedures.Add($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", new SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedureMetadata(this, $"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", "SelectPersonId_As_ScalarValue_With_Input_And_InputOutput"));
            StoredProcedures.Add($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output", new SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedureMetadata(this, $"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output", "SelectPersonId_As_ScalarValue_With_Input_And_Output"));
            StoredProcedures.Add($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input", new SelectPersonId_As_ScalarValueList_With_InputStoredProcedureMetadata(this, $"{identifier}.SelectPersonId_As_ScalarValueList_With_Input", "SelectPersonId_As_ScalarValueList_With_Input"));
            StoredProcedures.Add($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", new SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedureMetadata(this, $"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", "SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput"));
            StoredProcedures.Add($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output", new SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedureMetadata(this, $"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output", "SelectPersonId_As_ScalarValueList_With_Input_And_Output"));
            StoredProcedures.Add($"{identifier}.UpdatePersonCreditLimit_With_Inputs", new UpdatePersonCreditLimit_With_InputsStoredProcedureMetadata(this, $"{identifier}.UpdatePersonCreditLimit_With_Inputs", "UpdatePersonCreditLimit_With_Inputs"));
        }
        #endregion
    }
    #endregion

    #region access audit log
	public class AccessAuditLogEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public AccessAuditLogEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int) { IsIdentity = true });
            Fields.Add($"{identifier}.PersonId", new MsSqlFieldMetadata(this, $"{identifier}.PersonId", "PersonId", SqlDbType.Int));
            Fields.Add($"{identifier}.AccessResult", new MsSqlFieldMetadata(this, $"{identifier}.AccessResult", "AccessResult", SqlDbType.Int));
            Fields.Add($"{identifier}.DateCreated", new MsSqlFieldMetadata(this, $"{identifier}.DateCreated", "DateCreated", SqlDbType.DateTime));
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

    #region person address
	public class PersonAddressEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public PersonAddressEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
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

    #region unit test
	public class UnitTestEntityMetadata : ISqlEntityMetadata
	{
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        #endregion
		
        #region constructors
        public UnitTestEntityMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Fields.Add($"{identifier}.Id", new MsSqlFieldMetadata(this, $"{identifier}.Id", "Id", SqlDbType.Int));
            Fields.Add($"{identifier}.Boolean", new MsSqlFieldMetadata(this, $"{identifier}.Boolean", "Boolean", SqlDbType.Bit));
            Fields.Add($"{identifier}.NullableBoolean", new MsSqlFieldMetadata(this, $"{identifier}.NullableBoolean", "NullableBoolean", SqlDbType.Bit));
            Fields.Add($"{identifier}.Byte", new MsSqlFieldMetadata(this, $"{identifier}.Byte", "Byte", SqlDbType.TinyInt));
            Fields.Add($"{identifier}.NullableByte", new MsSqlFieldMetadata(this, $"{identifier}.NullableByte", "NullableByte", SqlDbType.TinyInt));
            Fields.Add($"{identifier}.ByteArray", new MsSqlFieldMetadata(this, $"{identifier}.ByteArray", "ByteArray", SqlDbType.VarBinary, -1));
            Fields.Add($"{identifier}.NullableByteArray", new MsSqlFieldMetadata(this, $"{identifier}.NullableByteArray", "NullableByteArray", SqlDbType.VarBinary, -1));
            Fields.Add($"{identifier}.DateTime", new MsSqlFieldMetadata(this, $"{identifier}.DateTime", "DateTime", SqlDbType.DateTime2, 8));
            Fields.Add($"{identifier}.NullableDateTime", new MsSqlFieldMetadata(this, $"{identifier}.NullableDateTime", "NullableDateTime", SqlDbType.DateTime2, 8));
            Fields.Add($"{identifier}.DateTimeOffset", new MsSqlFieldMetadata(this, $"{identifier}.DateTimeOffset", "DateTimeOffset", SqlDbType.DateTimeOffset, 10));
            Fields.Add($"{identifier}.NullableDateTimeOffset", new MsSqlFieldMetadata(this, $"{identifier}.NullableDateTimeOffset", "NullableDateTimeOffset", SqlDbType.DateTimeOffset, 10));
            Fields.Add($"{identifier}.Decimal", new MsSqlFieldMetadata(this, $"{identifier}.Decimal", "Decimal", SqlDbType.Decimal, 4, 1));
            Fields.Add($"{identifier}.NullableDecimal", new MsSqlFieldMetadata(this, $"{identifier}.NullableDecimal", "NullableDecimal", SqlDbType.Decimal, 4, 1));
            Fields.Add($"{identifier}.Double", new MsSqlFieldMetadata(this, $"{identifier}.Double", "Double", SqlDbType.Money));
            Fields.Add($"{identifier}.NullableDouble", new MsSqlFieldMetadata(this, $"{identifier}.NullableDouble", "NullableDouble", SqlDbType.Money));
            Fields.Add($"{identifier}.Guid", new MsSqlFieldMetadata(this, $"{identifier}.Guid", "Guid", SqlDbType.UniqueIdentifier));
            Fields.Add($"{identifier}.NullableGuid", new MsSqlFieldMetadata(this, $"{identifier}.NullableGuid", "NullableGuid", SqlDbType.UniqueIdentifier));
            Fields.Add($"{identifier}.Int16", new MsSqlFieldMetadata(this, $"{identifier}.Int16", "Int16", SqlDbType.SmallInt));
            Fields.Add($"{identifier}.NullableInt16", new MsSqlFieldMetadata(this, $"{identifier}.NullableInt16", "NullableInt16", SqlDbType.SmallInt));
            Fields.Add($"{identifier}.Int32", new MsSqlFieldMetadata(this, $"{identifier}.Int32", "Int32", SqlDbType.Int));
            Fields.Add($"{identifier}.NullableInt32", new MsSqlFieldMetadata(this, $"{identifier}.NullableInt32", "NullableInt32", SqlDbType.Int));
            Fields.Add($"{identifier}.Int64", new MsSqlFieldMetadata(this, $"{identifier}.Int64", "Int64", SqlDbType.BigInt));
            Fields.Add($"{identifier}.NullableInt64", new MsSqlFieldMetadata(this, $"{identifier}.NullableInt64", "NullableInt64", SqlDbType.BigInt));
            Fields.Add($"{identifier}.Single", new MsSqlFieldMetadata(this, $"{identifier}.Single", "Single", SqlDbType.Real));
            Fields.Add($"{identifier}.NullableSingle", new MsSqlFieldMetadata(this, $"{identifier}.NullableSingle", "NullableSingle", SqlDbType.Real));
            Fields.Add($"{identifier}.String", new MsSqlFieldMetadata(this, $"{identifier}.String", "String", SqlDbType.VarChar, 20));
            Fields.Add($"{identifier}.NullableString", new MsSqlFieldMetadata(this, $"{identifier}.NullableString", "NullableString", SqlDbType.VarChar, 20));
            Fields.Add($"{identifier}.TimeSpan", new MsSqlFieldMetadata(this, $"{identifier}.TimeSpan", "TimeSpan", SqlDbType.Time, 5));
            Fields.Add($"{identifier}.NullableTimeSpan", new MsSqlFieldMetadata(this, $"{identifier}.NullableTimeSpan", "NullableTimeSpan", SqlDbType.Time, 5));
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

    public class SelectPerson_As_Dynamic_With_InputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPerson_As_Dynamic_With_InputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@CreditLimit", new MsSqlParameterMetadata(this, $"{identifier}.@CreditLimit", "@CreditLimit", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@Count", new MsSqlParameterMetadata(this, $"{identifier}.@Count", "@Count", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPerson_As_DynamicList_With_InputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPerson_As_DynamicList_With_InputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@CreditLimit", new MsSqlParameterMetadata(this, $"{identifier}.@CreditLimit", "@CreditLimit", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@Count", new MsSqlParameterMetadata(this, $"{identifier}.@Count", "@Count", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPersonId_As_ScalarValue_With_InputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPersonId_As_ScalarValue_With_InputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
        }
        #endregion
    }

    public class SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@CreditLimit", new MsSqlParameterMetadata(this, $"{identifier}.@CreditLimit", "@CreditLimit", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@Count", new MsSqlParameterMetadata(this, $"{identifier}.@Count", "@Count", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPersonId_As_ScalarValueList_With_InputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPersonId_As_ScalarValueList_With_InputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@CreditLimit", new MsSqlParameterMetadata(this, $"{identifier}.@CreditLimit", "@CreditLimit", SqlDbType.Int));
        }
        #endregion
    }

    public class SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@Count", new MsSqlParameterMetadata(this, $"{identifier}.@Count", "@Count", SqlDbType.Int));
        }
        #endregion
    }

    public class UpdatePersonCreditLimit_With_InputsStoredProcedureMetadata : ISqlStoredProcedureMetadata
    {
        #region interface
        public ISqlSchemaMetadata Schema { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlParameterMetadata> Parameters { get; } = new Dictionary<string, ISqlParameterMetadata>();
        #endregion

        #region constructors
        public UpdatePersonCreditLimit_With_InputsStoredProcedureMetadata(ISqlSchemaMetadata schema, string identifier, string name)
        {
            Schema = schema;
            Identifier = identifier;
            Name = name;
            Parameters.Add($"{identifier}.@P1", new MsSqlParameterMetadata(this, $"{identifier}.@P1", "@P1", SqlDbType.Int));
            Parameters.Add($"{identifier}.@CreditLimit", new MsSqlParameterMetadata(this, $"{identifier}.@CreditLimit", "@CreditLimit", SqlDbType.Int));
        }
        #endregion
    }

}
namespace DbEx.secDataService
{
    #region sec
	public class secSchemaMetadata : ISqlSchemaMetadata
    {
		#region interface
        public ISqlDatabaseMetadata Database { get; }
        public string Identifier { get; }
        public string Name { get; }
        public IDictionary<string, ISqlEntityMetadata> Entities { get; } = new Dictionary<string, ISqlEntityMetadata>();
        public IDictionary<string, ISqlStoredProcedureMetadata> StoredProcedures { get; } = new Dictionary<string, ISqlStoredProcedureMetadata>();
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
