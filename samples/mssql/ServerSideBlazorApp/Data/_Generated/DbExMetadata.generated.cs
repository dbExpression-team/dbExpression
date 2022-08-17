using HatTrick.DbEx.MsSql;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.secDataService;
#nullable enable
namespace ServerSideBlazorApp.DataService
{
    public class CRMDatabaseSqlDatabaseMetadata : ISqlDatabaseMetadata
    {
        private static readonly Dictionary<string, ISqlMetadata> _metadata = new Dictionary<string, ISqlMetadata>();

        #region interface
        public string Name { get; private set; } = "MsSqlDbExTest";
        public IDictionary<string, ISqlMetadata> Metadata => _metadata;
        #endregion

        #region constructors
        static CRMDatabaseSqlDatabaseMetadata()
        {
            #region dbo schema
            _metadata.Add("dbo", new SqlSchemaMetadata("dbo"));
            
            #region dbo entities
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

            #region dbo.Person_Address
            _metadata.Add("dbo.Person_Address", new SqlTableMetadata("Person_Address"));
            _metadata.Add("dbo.Person_Address.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int) { IsIdentity = true });
            _metadata.Add("dbo.Person_Address.PersonId", new MsSqlColumnMetadata("PersonId", SqlDbType.Int));
            _metadata.Add("dbo.Person_Address.AddressId", new MsSqlColumnMetadata("AddressId", SqlDbType.Int));
            _metadata.Add("dbo.Person_Address.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
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
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPerson_As_Dynamic_With_Input_And_InputOutput"));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_Output", new StoredProcedureMetadata("SelectPerson_As_Dynamic_With_Input_And_Output"));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_Dynamic_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input", new StoredProcedureMetadata("SelectPerson_As_DynamicList_With_Input"));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPerson_As_DynamicList_With_Input_And_InputOutput"));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_Output", new StoredProcedureMetadata("SelectPerson_As_DynamicList_With_Input_And_Output"));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPerson_As_DynamicList_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input_And_Default_Value"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input_And_InputOutput"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output", new StoredProcedureMetadata("SelectPersonId_As_ScalarValue_With_Input_And_Output"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input", new StoredProcedureMetadata("SelectPersonId_As_ScalarValueList_With_Input"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", new StoredProcedureMetadata("SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output", new StoredProcedureMetadata("SelectPersonId_As_ScalarValueList_With_Input_And_Output"));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@Count", new MsSqlParameterMetadata("@Count", SqlDbType.Int));
            _metadata.Add("dbo.UpdatePersonCreditLimit_With_Inputs", new StoredProcedureMetadata("UpdatePersonCreditLimit_With_Inputs"));
            _metadata.Add("dbo.UpdatePersonCreditLimit_With_Inputs.@P1", new MsSqlParameterMetadata("@P1", SqlDbType.Int));
            _metadata.Add("dbo.UpdatePersonCreditLimit_With_Inputs.@CreditLimit", new MsSqlParameterMetadata("@CreditLimit", SqlDbType.Int));
            #endregion
            #endregion

            #region sec schema
            _metadata.Add("sec", new SqlSchemaMetadata("sec"));
            
            #region sec entities
            #region sec.Person
            _metadata.Add("sec.Person", new SqlTableMetadata("Person"));
            _metadata.Add("sec.Person.Id", new MsSqlColumnMetadata("Id", SqlDbType.Int));
            _metadata.Add("sec.Person.SSN", new MsSqlColumnMetadata("SSN", SqlDbType.Char, 11));
            _metadata.Add("sec.Person.DateCreated", new MsSqlColumnMetadata("DateCreated", SqlDbType.DateTime));
            _metadata.Add("sec.Person.DateUpdated", new MsSqlColumnMetadata("DateUpdated", SqlDbType.DateTime));
            #endregion

            #endregion

            #region sec stored procedures
            #endregion
            #endregion

        }

        public CRMDatabaseSqlDatabaseMetadata(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        #endregion
    }
}