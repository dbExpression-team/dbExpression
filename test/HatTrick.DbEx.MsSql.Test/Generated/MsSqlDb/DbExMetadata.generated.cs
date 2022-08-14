using HatTrick.DbEx.MsSql;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using DbEx.dboDataService;
using DbEx.unit_testDataService;
using DbEx.secDataService;
#nullable enable
namespace DbEx.DataService
{
    public class MsSqlDbSqlDatabaseMetadata : ISqlDatabaseMetadata
    {
        private static readonly Dictionary<string, ISqlMetadata> _metadata = new Dictionary<string, ISqlMetadata>();

        #region interface
        public string Name { get; private set; } = "MsSqlDbExTest";
        public IDictionary<string, ISqlMetadata> Metadata => _metadata;
        #endregion

        #region constructors
        static MsSqlDbSqlDatabaseMetadata()
        {
            #region dbo schema
            _metadata.Add("dbo", new SqlSchemaMetadata("dbo"));
            
            #region dbo entities
            #region dbo.AccessAuditLog
            _metadata.Add("dbo.AccessAuditLog", new SqlTableMetadata("AccessAuditLog"));
            _metadata.Add("dbo.AccessAuditLog.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.AccessAuditLog.PersonId", new MsSqlColumnMetadata("PersonId", SqlDbType.Int));
            _metadata.Add("dbo.AccessAuditLog.AccessResult", new MsSqlColumnMetadata("AccessResult", SqlDbType.Int));
            _metadata.Add("dbo.AccessAuditLog.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            #endregion

            #region dbo.Address
            _metadata.Add("dbo.Address", new SqlTableMetadata("Address"));
            _metadata.Add("dbo.Address.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.Address.AddressType", new MsSqlColumnMetadata("AddressType", SqlDbType.Int));
            _metadata.Add("dbo.Address.Line1", new MsSqlColumnMetadata("Line1", SqlDbType.VarChar, 50));
            _metadata.Add("dbo.Address.Line2", new MsSqlColumnMetadata("Line2", SqlDbType.VarChar, 50));
            _metadata.Add("dbo.Address.City", new MsSqlColumnMetadata("City", SqlDbType.VarChar, 60));
            _metadata.Add("dbo.Address.State", new MsSqlColumnMetadata("State", SqlDbType.Char, 2));
            _metadata.Add("dbo.Address.Zip", new MsSqlColumnMetadata("Zip", SqlDbType.VarChar, 10));
            _metadata.Add("dbo.Address.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            _metadata.Add("dbo.Address.DateUpdated", new MsSqlColumnMetadata("DateUpdated", SqlDbType.DateTime));
            #endregion

            #region dbo.Person
            _metadata.Add("dbo.Person", new SqlTableMetadata("Person"));
            _metadata.Add("dbo.Person.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.Person.FirstName", new MsSqlColumnMetadata("FirstName", SqlDbType.VarChar, 20));
            _metadata.Add("dbo.Person.LastName", new MsSqlColumnMetadata("LastName", SqlDbType.VarChar, 20));
            _metadata.Add("dbo.Person.BirthDate", new MsSqlColumnMetadata("BirthDate", SqlDbType.Date));
            _metadata.Add("dbo.Person.GenderType", new MsSqlColumnMetadata("GenderType", SqlDbType.Int));
            _metadata.Add("dbo.Person.CreditLimit", new MsSqlColumnMetadata("CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.Person.YearOfLastCreditLimitReview", new MsSqlColumnMetadata("YearOfLastCreditLimitReview", SqlDbType.Int));
            _metadata.Add("dbo.Person.RegistrationDate", new MsSqlColumnMetadata("RegistrationDate", SqlDbType.DateTimeOffset, 10));
            _metadata.Add("dbo.Person.LastLoginDate", new MsSqlColumnMetadata("LastLoginDate", SqlDbType.DateTimeOffset, 10));
            _metadata.Add("dbo.Person.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            _metadata.Add("dbo.Person.DateUpdated", new MsSqlColumnMetadata("DateUpdated", SqlDbType.DateTime));
            #endregion

            #region dbo.PersonAddress
            _metadata.Add("dbo.PersonAddress", new SqlTableMetadata("Person_Address"));
            _metadata.Add("dbo.PersonAddress.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.PersonAddress.PersonId", new MsSqlColumnMetadata("PersonId", SqlDbType.Int));
            _metadata.Add("dbo.PersonAddress.AddressId", new MsSqlColumnMetadata("AddressId", SqlDbType.Int));
            _metadata.Add("dbo.PersonAddress.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            #endregion

            #region dbo.Product
            _metadata.Add("dbo.Product", new SqlTableMetadata("Product"));
            _metadata.Add("dbo.Product.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.Product.ProductCategoryType", new MsSqlColumnMetadata("ProductCategoryType", SqlDbType.Int));
            _metadata.Add("dbo.Product.Name", new MsSqlColumnMetadata("Name", SqlDbType.VarChar, 80));
            _metadata.Add("dbo.Product.Description", new MsSqlColumnMetadata("Description", SqlDbType.NVarChar, 4000));
            _metadata.Add("dbo.Product.ListPrice", new MsSqlColumnMetadata("ListPrice", SqlDbType.Money));
            _metadata.Add("dbo.Product.Price", new MsSqlColumnMetadata("Price", SqlDbType.Money));
            _metadata.Add("dbo.Product.Quantity", new MsSqlColumnMetadata("Quantity", SqlDbType.Int));
            _metadata.Add("dbo.Product.Image", new MsSqlColumnMetadata("Image", SqlDbType.VarBinary, -1));
            _metadata.Add("dbo.Product.Height", new MsSqlColumnMetadata("Height", SqlDbType.Decimal, 4, 1));
            _metadata.Add("dbo.Product.Width", new MsSqlColumnMetadata("Width", SqlDbType.Decimal, 4, 1));
            _metadata.Add("dbo.Product.Depth", new MsSqlColumnMetadata("Depth", SqlDbType.Decimal, 4, 1));
            _metadata.Add("dbo.Product.Weight", new MsSqlColumnMetadata("Weight", SqlDbType.Decimal, 4, 1));
            _metadata.Add("dbo.Product.ShippingWeight", new MsSqlColumnMetadata("ShippingWeight", SqlDbType.Decimal, 4, 1));
            _metadata.Add("dbo.Product.ValidStartTimeOfDayForPurchase", new MsSqlColumnMetadata("ValidStartTimeOfDayForPurchase", SqlDbType.Time, 5));
            _metadata.Add("dbo.Product.ValidEndTimeOfDayForPurchase", new MsSqlColumnMetadata("ValidEndTimeOfDayForPurchase", SqlDbType.Time, 5));
            _metadata.Add("dbo.Product.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            _metadata.Add("dbo.Product.DateUpdated", new MsSqlColumnMetadata("DateUpdated", SqlDbType.DateTime));
            #endregion

            #region dbo.Purchase
            _metadata.Add("dbo.Purchase", new SqlTableMetadata("Purchase"));
            _metadata.Add("dbo.Purchase.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.Purchase.PersonId", new MsSqlColumnMetadata("PersonId", SqlDbType.Int));
            _metadata.Add("dbo.Purchase.OrderNumber", new MsSqlColumnMetadata("OrderNumber", SqlDbType.VarChar, 20));
            _metadata.Add("dbo.Purchase.TotalPurchaseQuantity", new MsSqlColumnMetadata("TotalPurchaseQuantity", SqlDbType.Int));
            _metadata.Add("dbo.Purchase.TotalPurchaseAmount", new MsSqlColumnMetadata("TotalPurchaseAmount", SqlDbType.Money));
            _metadata.Add("dbo.Purchase.PurchaseDate", new MsSqlColumnMetadata("PurchaseDate", SqlDbType.DateTime));
            _metadata.Add("dbo.Purchase.ShipDate", new MsSqlColumnMetadata("ShipDate", SqlDbType.DateTime));
            _metadata.Add("dbo.Purchase.ExpectedDeliveryDate", new MsSqlColumnMetadata("ExpectedDeliveryDate", SqlDbType.DateTime));
            _metadata.Add("dbo.Purchase.TrackingIdentifier", new MsSqlColumnMetadata("TrackingIdentifier", SqlDbType.UniqueIdentifier));
            _metadata.Add("dbo.Purchase.PaymentMethodType", new MsSqlColumnMetadata("PaymentMethodType", SqlDbType.VarChar, 20));
            _metadata.Add("dbo.Purchase.PaymentSourceType", new MsSqlColumnMetadata("PaymentSourceType", SqlDbType.VarChar, 20));
            _metadata.Add("dbo.Purchase.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            _metadata.Add("dbo.Purchase.DateUpdated", new MsSqlColumnMetadata("DateUpdated", SqlDbType.DateTime));
            #endregion

            #region dbo.PurchaseLine
            _metadata.Add("dbo.PurchaseLine", new SqlTableMetadata("PurchaseLine"));
            _metadata.Add("dbo.PurchaseLine.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.PurchaseLine.PurchaseId", new MsSqlColumnMetadata("PurchaseId", SqlDbType.Int));
            _metadata.Add("dbo.PurchaseLine.ProductId", new MsSqlColumnMetadata("ProductId", SqlDbType.Int));
            _metadata.Add("dbo.PurchaseLine.PurchasePrice", new MsSqlColumnMetadata("PurchasePrice", SqlDbType.Decimal, 12, 2));
            _metadata.Add("dbo.PurchaseLine.Quantity", new MsSqlColumnMetadata("Quantity", SqlDbType.Int));
            _metadata.Add("dbo.PurchaseLine.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            _metadata.Add("dbo.PurchaseLine.DateUpdated", new MsSqlColumnMetadata("DateUpdated", SqlDbType.DateTime));
            #endregion

            #region dbo.PersonTotalPurchasesView
            _metadata.Add("dbo.PersonTotalPurchasesView", new SqlTableMetadata("PersonTotalPurchasesView"));
            _metadata.Add("dbo.PersonTotalPurchasesView.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int));
            _metadata.Add("dbo.PersonTotalPurchasesView.TotalAmount", new MsSqlColumnMetadata("TotalAmount", SqlDbType.Money));
            _metadata.Add("dbo.PersonTotalPurchasesView.TotalCount", new MsSqlColumnMetadata("TotalCount", SqlDbType.Int));
            #endregion

            #endregion

            #region dbo stored procedures
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input", new StoredProcedureMetadata("SelectPerson_As_Dynamic_With_Input"));
            _metadata.Add($"dbo.SelectPerson_As_Dynamic_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPerson_As_Dynamic_With_Input_And_InputOutput"));
            _metadata.Add($"dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_Output", new StoredProcedureMetadata("SelectPerson_As_Dynamic_With_Input_And_Output"));
            _metadata.Add($"dbo.SelectPerson_As_Dynamic_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPerson_As_Dynamic_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input", new StoredProcedureMetadata("SelectPerson_As_DynamicList_With_Input"));
            _metadata.Add($"dbo.SelectPerson_As_DynamicList_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPerson_As_DynamicList_With_Input_And_InputOutput"));
            _metadata.Add($"dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_Output", new StoredProcedureMetadata("SelectPerson_As_DynamicList_With_Input_And_Output"));
            _metadata.Add($"dbo.SelectPerson_As_DynamicList_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPerson_As_DynamicList_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input"));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValue_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input_And_Default_Value"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input_And_InputOutput"));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input_And_Output"));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input", new StoredProcedureMetadata("SelectPersonId_As_ScalarValueList_With_Input"));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValueList_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput"));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output", new StoredProcedureMetadata("SelectPersonId_As_ScalarValueList_With_Input_And_Output"));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.UpdatePersonCreditLimit_With_Inputs", new StoredProcedureMetadata("UpdatePersonCreditLimit_With_Inputs"));
            _metadata.Add($"dbo.UpdatePersonCreditLimit_With_Inputs.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add($"dbo.UpdatePersonCreditLimit_With_Inputs.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            #endregion
            #endregion

            #region unit_test schema
            _metadata.Add("unit_test", new SqlSchemaMetadata("unit_test"));
            
            #region unit_test entities
            #region unit_test.alias
            _metadata.Add("unit_test.alias", new SqlTableMetadata("alias"));
            _metadata.Add("unit_test.alias.identifier", new MsSqlColumnMetadata("identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias._identifier", new MsSqlColumnMetadata("_identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.__identifier", new MsSqlColumnMetadata("__identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.name", new MsSqlColumnMetadata("name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias._name", new MsSqlColumnMetadata("_name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.__name", new MsSqlColumnMetadata("__name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.schema", new MsSqlColumnMetadata("schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias._schema", new MsSqlColumnMetadata("_schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.__schema", new MsSqlColumnMetadata("__schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias._alias", new MsSqlColumnMetadata("_alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.__alias", new MsSqlColumnMetadata("__alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.entity", new MsSqlColumnMetadata("entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias._entity", new MsSqlColumnMetadata("_entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.alias.__entity", new MsSqlColumnMetadata("__entity", SqlDbType.VarChar, 20));
            #endregion

            #region unit_test.entity
            _metadata.Add("unit_test.entity", new SqlTableMetadata("entity"));
            _metadata.Add("unit_test.entity.identifier", new MsSqlColumnMetadata("identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity._identifier", new MsSqlColumnMetadata("_identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.__identifier", new MsSqlColumnMetadata("__identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.name", new MsSqlColumnMetadata("name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity._name", new MsSqlColumnMetadata("_name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.__name", new MsSqlColumnMetadata("__name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.schema", new MsSqlColumnMetadata("schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity._schema", new MsSqlColumnMetadata("_schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.__schema", new MsSqlColumnMetadata("__schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.alias", new MsSqlColumnMetadata("alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity._alias", new MsSqlColumnMetadata("_alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.__alias", new MsSqlColumnMetadata("__alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity._entity", new MsSqlColumnMetadata("_entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.entity.__entity", new MsSqlColumnMetadata("__entity", SqlDbType.VarChar, 20));
            #endregion

            #region unit_test.ExpressionElementType
            _metadata.Add("unit_test.ExpressionElementType", new SqlTableMetadata("ExpressionElementType"));
            _metadata.Add("unit_test.ExpressionElementType.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int));
            _metadata.Add("unit_test.ExpressionElementType.Boolean", new MsSqlColumnMetadata("Boolean", SqlDbType.Bit));
            _metadata.Add("unit_test.ExpressionElementType.NullableBoolean", new MsSqlColumnMetadata("NullableBoolean", SqlDbType.Bit));
            _metadata.Add("unit_test.ExpressionElementType.Byte", new MsSqlColumnMetadata("Byte", SqlDbType.TinyInt));
            _metadata.Add("unit_test.ExpressionElementType.NullableByte", new MsSqlColumnMetadata("NullableByte", SqlDbType.TinyInt));
            _metadata.Add("unit_test.ExpressionElementType.ByteArray", new MsSqlColumnMetadata("ByteArray", SqlDbType.VarBinary, -1));
            _metadata.Add("unit_test.ExpressionElementType.NullableByteArray", new MsSqlColumnMetadata("NullableByteArray", SqlDbType.VarBinary, -1));
            _metadata.Add("unit_test.ExpressionElementType.DateTime", new MsSqlColumnMetadata("DateTime", SqlDbType.DateTime2, 8));
            _metadata.Add("unit_test.ExpressionElementType.NullableDateTime", new MsSqlColumnMetadata("NullableDateTime", SqlDbType.DateTime2, 8));
            _metadata.Add("unit_test.ExpressionElementType.DateTimeOffset", new MsSqlColumnMetadata("DateTimeOffset", SqlDbType.DateTimeOffset, 10));
            _metadata.Add("unit_test.ExpressionElementType.NullableDateTimeOffset", new MsSqlColumnMetadata("NullableDateTimeOffset", SqlDbType.DateTimeOffset, 10));
            _metadata.Add("unit_test.ExpressionElementType.Decimal", new MsSqlColumnMetadata("Decimal", SqlDbType.Decimal, 5, 4));
            _metadata.Add("unit_test.ExpressionElementType.NullableDecimal", new MsSqlColumnMetadata("NullableDecimal", SqlDbType.Decimal, 5, 4));
            _metadata.Add("unit_test.ExpressionElementType.Double", new MsSqlColumnMetadata("Double", SqlDbType.Money));
            _metadata.Add("unit_test.ExpressionElementType.NullableDouble", new MsSqlColumnMetadata("NullableDouble", SqlDbType.Money));
            _metadata.Add("unit_test.ExpressionElementType.Guid", new MsSqlColumnMetadata("Guid", SqlDbType.UniqueIdentifier));
            _metadata.Add("unit_test.ExpressionElementType.NullableGuid", new MsSqlColumnMetadata("NullableGuid", SqlDbType.UniqueIdentifier));
            _metadata.Add("unit_test.ExpressionElementType.Int16", new MsSqlColumnMetadata("Int16", SqlDbType.SmallInt));
            _metadata.Add("unit_test.ExpressionElementType.NullableInt16", new MsSqlColumnMetadata("NullableInt16", SqlDbType.SmallInt));
            _metadata.Add("unit_test.ExpressionElementType.Int32", new MsSqlColumnMetadata("Int32", SqlDbType.Int));
            _metadata.Add("unit_test.ExpressionElementType.NullableInt32", new MsSqlColumnMetadata("NullableInt32", SqlDbType.Int));
            _metadata.Add("unit_test.ExpressionElementType.Int64", new MsSqlColumnMetadata("Int64", SqlDbType.BigInt));
            _metadata.Add("unit_test.ExpressionElementType.NullableInt64", new MsSqlColumnMetadata("NullableInt64", SqlDbType.BigInt));
            _metadata.Add("unit_test.ExpressionElementType.Single", new MsSqlColumnMetadata("Single", SqlDbType.Real));
            _metadata.Add("unit_test.ExpressionElementType.NullableSingle", new MsSqlColumnMetadata("NullableSingle", SqlDbType.Real));
            _metadata.Add("unit_test.ExpressionElementType.String", new MsSqlColumnMetadata("String", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.ExpressionElementType.NullableString", new MsSqlColumnMetadata("NullableString", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.ExpressionElementType.TimeSpan", new MsSqlColumnMetadata("TimeSpan", SqlDbType.Time, 5));
            _metadata.Add("unit_test.ExpressionElementType.NullableTimeSpan", new MsSqlColumnMetadata("NullableTimeSpan", SqlDbType.Time, 5));
            #endregion

            #region unit_test.identifier
            _metadata.Add("unit_test.identifier", new SqlTableMetadata("identifier"));
            _metadata.Add("unit_test.identifier._identifier", new MsSqlColumnMetadata("_identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.__identifier", new MsSqlColumnMetadata("__identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.name", new MsSqlColumnMetadata("name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier._name", new MsSqlColumnMetadata("_name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.__name", new MsSqlColumnMetadata("__name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.schema", new MsSqlColumnMetadata("schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier._schema", new MsSqlColumnMetadata("_schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.__schema", new MsSqlColumnMetadata("__schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.alias", new MsSqlColumnMetadata("alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier._alias", new MsSqlColumnMetadata("_alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.__alias", new MsSqlColumnMetadata("__alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.entity", new MsSqlColumnMetadata("entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier._entity", new MsSqlColumnMetadata("_entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.identifier.__entity", new MsSqlColumnMetadata("__entity", SqlDbType.VarChar, 20));
            #endregion

            #region unit_test.name
            _metadata.Add("unit_test.name", new SqlTableMetadata("name"));
            _metadata.Add("unit_test.name.identifier", new MsSqlColumnMetadata("identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name._identifier", new MsSqlColumnMetadata("_identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.__identifier", new MsSqlColumnMetadata("__identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name._name", new MsSqlColumnMetadata("_name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.__name", new MsSqlColumnMetadata("__name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.schema", new MsSqlColumnMetadata("schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name._schema", new MsSqlColumnMetadata("_schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.__schema", new MsSqlColumnMetadata("__schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.alias", new MsSqlColumnMetadata("alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name._alias", new MsSqlColumnMetadata("_alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.__alias", new MsSqlColumnMetadata("__alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.entity", new MsSqlColumnMetadata("entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name._entity", new MsSqlColumnMetadata("_entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.name.__entity", new MsSqlColumnMetadata("__entity", SqlDbType.VarChar, 20));
            #endregion

            #region unit_test.schema
            _metadata.Add("unit_test.schema", new SqlTableMetadata("schema"));
            _metadata.Add("unit_test.schema.identifier", new MsSqlColumnMetadata("identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema._identifier", new MsSqlColumnMetadata("_identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.__identifier", new MsSqlColumnMetadata("__identifier", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.name", new MsSqlColumnMetadata("name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema._name", new MsSqlColumnMetadata("_name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.__name", new MsSqlColumnMetadata("__name", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema._schema", new MsSqlColumnMetadata("_schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.__schema", new MsSqlColumnMetadata("__schema", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.alias", new MsSqlColumnMetadata("alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema._alias", new MsSqlColumnMetadata("_alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.__alias", new MsSqlColumnMetadata("__alias", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.entity", new MsSqlColumnMetadata("entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema._entity", new MsSqlColumnMetadata("_entity", SqlDbType.VarChar, 20));
            _metadata.Add("unit_test.schema.__entity", new MsSqlColumnMetadata("__entity", SqlDbType.VarChar, 20));
            #endregion

            #endregion

            #region unit_test stored procedures
            #endregion
            #endregion

            #region sec schema
            _metadata.Add("sec", new SqlSchemaMetadata("sec"));
            
            #region sec entities
            #region sec.Person
            _metadata.Add("sec.Person", new SqlTableMetadata("Person"));
            _metadata.Add("sec.Person.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int));
            _metadata.Add("sec.Person.SocialSecurityNumber", new MsSqlColumnMetadata("SSN", SqlDbType.Char, 11));
            _metadata.Add("sec.Person.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            _metadata.Add("sec.Person.DateUpdated", new MsSqlColumnMetadata("DateUpdated", SqlDbType.DateTime));
            #endregion

            #endregion

            #region sec stored procedures
            #endregion
            #endregion

        }

        public MsSqlDbSqlDatabaseMetadata(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        #endregion
    }
}