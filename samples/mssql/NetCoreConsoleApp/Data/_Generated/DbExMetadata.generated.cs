//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using HatTrick.DbEx.MsSql;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using SimpleConsole.dboDataService;
using SimpleConsole.secDataService;

namespace SimpleConsole.DataService
{
    public class SimpleConsoleDbSqlDatabaseMetadata : ISqlDatabaseMetadata
    {
        private static readonly Dictionary<int, ISqlMetadata> _metadata = new Dictionary<int, ISqlMetadata>();

        #region interface
        public string Name { get; private set; } = "MsSqlDbExTest";
        public IDictionary<int, ISqlMetadata> Metadata => _metadata;
        #endregion

        #region constructors
        static SimpleConsoleDbSqlDatabaseMetadata()
        {
            _metadata.Add(0, new SqlDatabaseMetadata(name:"SimpleConsoleDb"));

            #region dbo schema
            _metadata.Add(1, new SqlSchemaMetadata(name:"dbo"));
            
            #region dbo entities
            #region dbo.AccessAuditLog
            // dbo.AccessAuditLog
            _metadata.Add(2, new SqlTableMetadata(name:"AccessAuditLog"));

            // dbo.AccessAuditLog.Id
            _metadata.Add(3, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    ) 
                    { 
                        IsIdentity = true 
                    }
                );

            // dbo.AccessAuditLog.PersonId
            _metadata.Add(4, new MsSqlColumnMetadata(
                        name:"PersonId", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.AccessAuditLog.AccessResult
            _metadata.Add(5, new MsSqlColumnMetadata(
                        name:"AccessResult", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.AccessAuditLog.DateCreated
            _metadata.Add(6, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #region dbo.Address
            // dbo.Address
            _metadata.Add(7, new SqlTableMetadata(name:"Address"));

            // dbo.Address.Id
            _metadata.Add(8, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    ) 
                    { 
                        IsIdentity = true 
                    }
                );

            // dbo.Address.AddressType
            _metadata.Add(9, new MsSqlColumnMetadata(
                        name:"AddressType", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Address.Line1
            _metadata.Add(10, new MsSqlColumnMetadata(
                        name:"Line1", 
                        dbType:SqlDbType.VarChar, 
                        size:50
                    )
                );

            // dbo.Address.Line2
            _metadata.Add(11, new MsSqlColumnMetadata(
                        name:"Line2", 
                        dbType:SqlDbType.VarChar, 
                        size:50
                    )
                );

            // dbo.Address.City
            _metadata.Add(12, new MsSqlColumnMetadata(
                        name:"City", 
                        dbType:SqlDbType.VarChar, 
                        size:60
                    )
                );

            // dbo.Address.State
            _metadata.Add(13, new MsSqlColumnMetadata(
                        name:"State", 
                        dbType:SqlDbType.Char, 
                        size:2
                    )
                );

            // dbo.Address.Zip
            _metadata.Add(14, new MsSqlColumnMetadata(
                        name:"Zip", 
                        dbType:SqlDbType.VarChar, 
                        size:10
                    )
                );

            // dbo.Address.DateCreated
            _metadata.Add(15, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.Address.DateUpdated
            _metadata.Add(16, new MsSqlColumnMetadata(
                        name:"DateUpdated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #region dbo.Person
            // dbo.Person
            _metadata.Add(17, new SqlTableMetadata(name:"Person"));

            // dbo.Person.Id
            _metadata.Add(18, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    ) 
                    { 
                        IsIdentity = true 
                    }
                );

            // dbo.Person.FirstName
            _metadata.Add(19, new MsSqlColumnMetadata(
                        name:"FirstName", 
                        dbType:SqlDbType.VarChar, 
                        size:20
                    )
                );

            // dbo.Person.LastName
            _metadata.Add(20, new MsSqlColumnMetadata(
                        name:"LastName", 
                        dbType:SqlDbType.VarChar, 
                        size:20
                    )
                );

            // dbo.Person.BirthDate
            _metadata.Add(21, new MsSqlColumnMetadata(
                        name:"BirthDate", 
                        dbType:SqlDbType.Date
                    )
                );

            // dbo.Person.GenderType
            _metadata.Add(22, new MsSqlColumnMetadata(
                        name:"GenderType", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Person.CreditLimit
            _metadata.Add(23, new MsSqlColumnMetadata(
                        name:"CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Person.YearOfLastCreditLimitReview
            _metadata.Add(24, new MsSqlColumnMetadata(
                        name:"YearOfLastCreditLimitReview", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Person.RegistrationDate
            _metadata.Add(25, new MsSqlColumnMetadata(
                        name:"RegistrationDate", 
                        dbType:SqlDbType.DateTimeOffset, 
                        size:10
                    )
                );

            // dbo.Person.LastLoginDate
            _metadata.Add(26, new MsSqlColumnMetadata(
                        name:"LastLoginDate", 
                        dbType:SqlDbType.DateTimeOffset, 
                        size:10
                    )
                );

            // dbo.Person.DateCreated
            _metadata.Add(27, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.Person.DateUpdated
            _metadata.Add(28, new MsSqlColumnMetadata(
                        name:"DateUpdated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #region dbo.Person_Address
            // dbo.Person_Address
            _metadata.Add(29, new SqlTableMetadata(name:"Person_Address"));

            // dbo.Person_Address.Id
            _metadata.Add(30, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    ) 
                    { 
                        IsIdentity = true 
                    }
                );

            // dbo.Person_Address.PersonId
            _metadata.Add(31, new MsSqlColumnMetadata(
                        name:"PersonId", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Person_Address.AddressId
            _metadata.Add(32, new MsSqlColumnMetadata(
                        name:"AddressId", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Person_Address.DateCreated
            _metadata.Add(33, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #region dbo.Product
            // dbo.Product
            _metadata.Add(34, new SqlTableMetadata(name:"Product"));

            // dbo.Product.Id
            _metadata.Add(35, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    ) 
                    { 
                        IsIdentity = true 
                    }
                );

            // dbo.Product.ProductCategoryType
            _metadata.Add(36, new MsSqlColumnMetadata(
                        name:"ProductCategoryType", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Product.Name
            _metadata.Add(37, new MsSqlColumnMetadata(
                        name:"Name", 
                        dbType:SqlDbType.VarChar, 
                        size:80
                    )
                );

            // dbo.Product.Description
            _metadata.Add(38, new MsSqlColumnMetadata(
                        name:"Description", 
                        dbType:SqlDbType.NVarChar, 
                        size:4000
                    )
                );

            // dbo.Product.ListPrice
            _metadata.Add(39, new MsSqlColumnMetadata(
                        name:"ListPrice", 
                        dbType:SqlDbType.Money
                    )
                );

            // dbo.Product.Price
            _metadata.Add(40, new MsSqlColumnMetadata(
                        name:"Price", 
                        dbType:SqlDbType.Money
                    )
                );

            // dbo.Product.Quantity
            _metadata.Add(41, new MsSqlColumnMetadata(
                        name:"Quantity", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Product.Image
            _metadata.Add(42, new MsSqlColumnMetadata(
                        name:"Image", 
                        dbType:SqlDbType.VarBinary, 
                        size:-1
                    )
                );

            // dbo.Product.Height
            _metadata.Add(43, new MsSqlColumnMetadata(
                        name:"Height", 
                        dbType:SqlDbType.Decimal, 
                        precision:4, 
                        scale:1
                    )
                );

            // dbo.Product.Width
            _metadata.Add(44, new MsSqlColumnMetadata(
                        name:"Width", 
                        dbType:SqlDbType.Decimal, 
                        precision:4, 
                        scale:1
                    )
                );

            // dbo.Product.Depth
            _metadata.Add(45, new MsSqlColumnMetadata(
                        name:"Depth", 
                        dbType:SqlDbType.Decimal, 
                        precision:4, 
                        scale:1
                    )
                );

            // dbo.Product.Weight
            _metadata.Add(46, new MsSqlColumnMetadata(
                        name:"Weight", 
                        dbType:SqlDbType.Decimal, 
                        precision:4, 
                        scale:1
                    )
                );

            // dbo.Product.ShippingWeight
            _metadata.Add(47, new MsSqlColumnMetadata(
                        name:"ShippingWeight", 
                        dbType:SqlDbType.Decimal, 
                        precision:4, 
                        scale:1
                    )
                );

            // dbo.Product.ValidStartTimeOfDayForPurchase
            _metadata.Add(48, new MsSqlColumnMetadata(
                        name:"ValidStartTimeOfDayForPurchase", 
                        dbType:SqlDbType.Time, 
                        size:5
                    )
                );

            // dbo.Product.ValidEndTimeOfDayForPurchase
            _metadata.Add(49, new MsSqlColumnMetadata(
                        name:"ValidEndTimeOfDayForPurchase", 
                        dbType:SqlDbType.Time, 
                        size:5
                    )
                );

            // dbo.Product.DateCreated
            _metadata.Add(50, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.Product.DateUpdated
            _metadata.Add(51, new MsSqlColumnMetadata(
                        name:"DateUpdated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #region dbo.Purchase
            // dbo.Purchase
            _metadata.Add(52, new SqlTableMetadata(name:"Purchase"));

            // dbo.Purchase.Id
            _metadata.Add(53, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    ) 
                    { 
                        IsIdentity = true 
                    }
                );

            // dbo.Purchase.PersonId
            _metadata.Add(54, new MsSqlColumnMetadata(
                        name:"PersonId", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Purchase.OrderNumber
            _metadata.Add(55, new MsSqlColumnMetadata(
                        name:"OrderNumber", 
                        dbType:SqlDbType.VarChar, 
                        size:20
                    )
                );

            // dbo.Purchase.TotalPurchaseQuantity
            _metadata.Add(56, new MsSqlColumnMetadata(
                        name:"TotalPurchaseQuantity", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.Purchase.TotalPurchaseAmount
            _metadata.Add(57, new MsSqlColumnMetadata(
                        name:"TotalPurchaseAmount", 
                        dbType:SqlDbType.Money
                    )
                );

            // dbo.Purchase.PurchaseDate
            _metadata.Add(58, new MsSqlColumnMetadata(
                        name:"PurchaseDate", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.Purchase.ShipDate
            _metadata.Add(59, new MsSqlColumnMetadata(
                        name:"ShipDate", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.Purchase.ExpectedDeliveryDate
            _metadata.Add(60, new MsSqlColumnMetadata(
                        name:"ExpectedDeliveryDate", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.Purchase.TrackingIdentifier
            _metadata.Add(61, new MsSqlColumnMetadata(
                        name:"TrackingIdentifier", 
                        dbType:SqlDbType.UniqueIdentifier
                    )
                );

            // dbo.Purchase.PaymentMethodType
            _metadata.Add(62, new MsSqlColumnMetadata(
                        name:"PaymentMethodType", 
                        dbType:SqlDbType.VarChar, 
                        size:20
                    )
                );

            // dbo.Purchase.PaymentSourceType
            _metadata.Add(63, new MsSqlColumnMetadata(
                        name:"PaymentSourceType", 
                        dbType:SqlDbType.VarChar, 
                        size:20
                    )
                );

            // dbo.Purchase.DateCreated
            _metadata.Add(64, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.Purchase.DateUpdated
            _metadata.Add(65, new MsSqlColumnMetadata(
                        name:"DateUpdated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #region dbo.PurchaseLine
            // dbo.PurchaseLine
            _metadata.Add(66, new SqlTableMetadata(name:"PurchaseLine"));

            // dbo.PurchaseLine.Id
            _metadata.Add(67, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    ) 
                    { 
                        IsIdentity = true 
                    }
                );

            // dbo.PurchaseLine.PurchaseId
            _metadata.Add(68, new MsSqlColumnMetadata(
                        name:"PurchaseId", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.PurchaseLine.ProductId
            _metadata.Add(69, new MsSqlColumnMetadata(
                        name:"ProductId", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.PurchaseLine.PurchasePrice
            _metadata.Add(70, new MsSqlColumnMetadata(
                        name:"PurchasePrice", 
                        dbType:SqlDbType.Decimal, 
                        precision:12, 
                        scale:2
                    )
                );

            // dbo.PurchaseLine.Quantity
            _metadata.Add(71, new MsSqlColumnMetadata(
                        name:"Quantity", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.PurchaseLine.DateCreated
            _metadata.Add(72, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // dbo.PurchaseLine.DateUpdated
            _metadata.Add(73, new MsSqlColumnMetadata(
                        name:"DateUpdated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #region dbo.PersonTotalPurchasesView
            // dbo.PersonTotalPurchasesView
            _metadata.Add(74, new SqlTableMetadata(name:"PersonTotalPurchasesView"));

            // dbo.PersonTotalPurchasesView.Id
            _metadata.Add(75, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.PersonTotalPurchasesView.TotalAmount
            _metadata.Add(76, new MsSqlColumnMetadata(
                        name:"TotalAmount", 
                        dbType:SqlDbType.Money
                    )
                );

            // dbo.PersonTotalPurchasesView.TotalCount
            _metadata.Add(77, new MsSqlColumnMetadata(
                        name:"TotalCount", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #endregion

            #region dbo stored procedures
            #region dbo.GetMaxCreditLimitLessThan
            // dbo.GetMaxCreditLimitLessThan
            _metadata.Add(78, new StoredProcedureMetadata(name:"GetMaxCreditLimitLessThan"));

            // dbo.GetMaxCreditLimitLessThan.@CreditLimit
            _metadata.Add(79, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.GetPersonById
            // dbo.GetPersonById
            _metadata.Add(80, new StoredProcedureMetadata(name:"GetPersonById"));

            // dbo.GetPersonById.@Id
            _metadata.Add(81, new MsSqlParameterMetadata(
                        name:"@Id", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.GetPersonsWithCreditLimitLessThan
            // dbo.GetPersonsWithCreditLimitLessThan
            _metadata.Add(82, new StoredProcedureMetadata(name:"GetPersonsWithCreditLimitLessThan"));

            // dbo.GetPersonsWithCreditLimitLessThan.@CreditLimit
            _metadata.Add(83, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPerson_As_Dynamic_With_Input
            // dbo.SelectPerson_As_Dynamic_With_Input
            _metadata.Add(84, new StoredProcedureMetadata(name:"SelectPerson_As_Dynamic_With_Input"));

            // dbo.SelectPerson_As_Dynamic_With_Input.@P1
            _metadata.Add(85, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput
            // dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput
            _metadata.Add(86, new StoredProcedureMetadata(name:"SelectPerson_As_Dynamic_With_Input_And_InputOutput"));

            // dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@P1
            _metadata.Add(87, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@CreditLimit
            _metadata.Add(88, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPerson_As_Dynamic_With_Input_And_Output
            // dbo.SelectPerson_As_Dynamic_With_Input_And_Output
            _metadata.Add(89, new StoredProcedureMetadata(name:"SelectPerson_As_Dynamic_With_Input_And_Output"));

            // dbo.SelectPerson_As_Dynamic_With_Input_And_Output.@P1
            _metadata.Add(90, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPerson_As_Dynamic_With_Input_And_Output.@Count
            _metadata.Add(91, new MsSqlParameterMetadata(
                        name:"@Count", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPerson_As_DynamicList_With_Input
            // dbo.SelectPerson_As_DynamicList_With_Input
            _metadata.Add(92, new StoredProcedureMetadata(name:"SelectPerson_As_DynamicList_With_Input"));

            // dbo.SelectPerson_As_DynamicList_With_Input.@P1
            _metadata.Add(93, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput
            // dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput
            _metadata.Add(94, new StoredProcedureMetadata(name:"SelectPerson_As_DynamicList_With_Input_And_InputOutput"));

            // dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@P1
            _metadata.Add(95, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@CreditLimit
            _metadata.Add(96, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPerson_As_DynamicList_With_Input_And_Output
            // dbo.SelectPerson_As_DynamicList_With_Input_And_Output
            _metadata.Add(97, new StoredProcedureMetadata(name:"SelectPerson_As_DynamicList_With_Input_And_Output"));

            // dbo.SelectPerson_As_DynamicList_With_Input_And_Output.@P1
            _metadata.Add(98, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPerson_As_DynamicList_With_Input_And_Output.@Count
            _metadata.Add(99, new MsSqlParameterMetadata(
                        name:"@Count", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPersonId_As_ScalarValue_With_Input
            // dbo.SelectPersonId_As_ScalarValue_With_Input
            _metadata.Add(100, new StoredProcedureMetadata(name:"SelectPersonId_As_ScalarValue_With_Input"));

            // dbo.SelectPersonId_As_ScalarValue_With_Input.@P1
            _metadata.Add(101, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value
            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value
            _metadata.Add(102, new StoredProcedureMetadata(name:"SelectPersonId_As_ScalarValue_With_Input_And_Default_Value"));

            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value.@P1
            _metadata.Add(103, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput
            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput
            _metadata.Add(104, new StoredProcedureMetadata(name:"SelectPersonId_As_ScalarValue_With_Input_And_InputOutput"));

            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@P1
            _metadata.Add(105, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@CreditLimit
            _metadata.Add(106, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output
            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output
            _metadata.Add(107, new StoredProcedureMetadata(name:"SelectPersonId_As_ScalarValue_With_Input_And_Output"));

            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output.@P1
            _metadata.Add(108, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPersonId_As_ScalarValue_With_Input_And_Output.@Count
            _metadata.Add(109, new MsSqlParameterMetadata(
                        name:"@Count", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPersonId_As_ScalarValueList_With_Input
            // dbo.SelectPersonId_As_ScalarValueList_With_Input
            _metadata.Add(110, new StoredProcedureMetadata(name:"SelectPersonId_As_ScalarValueList_With_Input"));

            // dbo.SelectPersonId_As_ScalarValueList_With_Input.@P1
            _metadata.Add(111, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput
            // dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput
            _metadata.Add(112, new StoredProcedureMetadata(name:"SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput"));

            // dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@P1
            _metadata.Add(113, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@CreditLimit
            _metadata.Add(114, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output
            // dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output
            _metadata.Add(115, new StoredProcedureMetadata(name:"SelectPersonId_As_ScalarValueList_With_Input_And_Output"));

            // dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@P1
            _metadata.Add(116, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@Count
            _metadata.Add(117, new MsSqlParameterMetadata(
                        name:"@Count", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.SetCreditLimitForPerson
            // dbo.SetCreditLimitForPerson
            _metadata.Add(118, new StoredProcedureMetadata(name:"SetCreditLimitForPerson"));

            // dbo.SetCreditLimitForPerson.@Id
            _metadata.Add(119, new MsSqlParameterMetadata(
                        name:"@Id", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.SetCreditLimitForPerson.@CreditLimit
            _metadata.Add(120, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #region dbo.UpdatePersonCreditLimit_With_Inputs
            // dbo.UpdatePersonCreditLimit_With_Inputs
            _metadata.Add(121, new StoredProcedureMetadata(name:"UpdatePersonCreditLimit_With_Inputs"));

            // dbo.UpdatePersonCreditLimit_With_Inputs.@P1
            _metadata.Add(122, new MsSqlParameterMetadata(
                        name:"@P1", 
                        dbType:SqlDbType.Int
                    )
                );

            // dbo.UpdatePersonCreditLimit_With_Inputs.@CreditLimit
            _metadata.Add(123, new MsSqlParameterMetadata(
                        name:"@CreditLimit", 
                        dbType:SqlDbType.Int
                    )
                );

            #endregion

            #endregion
            #endregion

            #region sec schema
            _metadata.Add(124, new SqlSchemaMetadata(name:"sec"));
            
            #region sec entities
            #region sec.Person
            // sec.Person
            _metadata.Add(125, new SqlTableMetadata(name:"Person"));

            // sec.Person.Id
            _metadata.Add(126, new MsSqlColumnMetadata(
                        name:"Id", 
                        dbType:SqlDbType.Int
                    )
                );

            // sec.Person.SSN
            _metadata.Add(127, new MsSqlColumnMetadata(
                        name:"SSN", 
                        dbType:SqlDbType.Char, 
                        size:11
                    )
                );

            // sec.Person.DateCreated
            _metadata.Add(128, new MsSqlColumnMetadata(
                        name:"DateCreated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            // sec.Person.DateUpdated
            _metadata.Add(129, new MsSqlColumnMetadata(
                        name:"DateUpdated", 
                        dbType:SqlDbType.DateTime
                    )
                );

            #endregion

            #endregion

            #region sec stored procedures
            #endregion
            #endregion

        }

        public SimpleConsoleDbSqlDatabaseMetadata(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        #endregion
    }
}