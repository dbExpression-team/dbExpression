using System;
using HatTrick.DbEx.Sql;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace SimpleConsole.dboData
{
    #region address
    public partial class Address : IDbEntity, NetCoreConsoleApp.Data.IUpdateableEntity
    {
        #region interface
        public int Id { get; set; }
        public SimpleConsole.Data.AddressType? AddressType { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Address()
        {
        }
        #endregion
    }
    #endregion

    #region person
    public partial class Person : IDbEntity, NetCoreConsoleApp.Data.IUpdateableEntity
    {
        #region interface
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public SimpleConsole.Data.GenderType GenderType { get; set; }
        public int? CreditLimit { get; set; }
        public int? YearOfLastCreditLimitReview { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Person()
        {
        }
        #endregion
    }
    #endregion

    #region person address
    public partial class PersonAddress : IDbEntity
    {
        #region interface
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public DateTime DateCreated { get; set; }
        #endregion

        #region constructor
        public PersonAddress()
        {
        }
        #endregion
    }
    #endregion

    #region product
    public partial class Product : IDbEntity, NetCoreConsoleApp.Data.IUpdateableEntity
    {
        #region interface
        public int Id { get; set; }
        public SimpleConsole.Data.ProductCategoryType? ProductCategoryType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
        public decimal? Weight { get; set; }
        public decimal ShippingWeight { get; set; }
        public TimeSpan? ValidStartTimeOfDayForPurchase { get; set; }
        public TimeSpan? ValidEndTimeOfDayForPurchase { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Product()
        {
        }
        #endregion
    }
    #endregion

    #region purchase
    public partial class Purchase : IDbEntity, NetCoreConsoleApp.Data.IUpdateableEntity
    {
        #region interface
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string OrderNumber { get; set; }
        public int TotalPurchaseQuantity { get; set; }
        public double TotalPurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public Guid? TrackingIdentifier { get; set; }
        public SimpleConsole.Data.PaymentMethodType PaymentMethodType { get; set; }
        public SimpleConsole.Data.PaymentSourceType? PaymentSourceType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Purchase()
        {
        }
        #endregion
    }
    #endregion

    #region purchase line
    public partial class PurchaseLine : IDbEntity, NetCoreConsoleApp.Data.IUpdateableEntity
    {
        #region interface
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public decimal? PurchaseTotal { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public PurchaseLine()
        {
        }
        #endregion
    }
    #endregion

    #region person total purchases view
    public partial class PersonTotalPurchasesView : IDbEntity
    {
        #region interface
        public int Id { get; set; }
        public double? TotalAmount { get; set; }
        public int? TotalCount { get; set; }
        #endregion

        #region constructor
        public PersonTotalPurchasesView()
        {
        }
        #endregion
    }
    #endregion

}
namespace SimpleConsole.secData
{
    #region person
    public partial class Person : IDbEntity, NetCoreConsoleApp.Data.IUpdateableEntity
    {
        #region interface
        public int Id { get; set; }
        public string SSN { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        #endregion

        #region constructor
        public Person()
        {
        }
        #endregion
    }
    #endregion

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
