using System;
using HatTrick.DbEx.Sql;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ServerSideBlazorApp.dboData
{
    #region address
    public partial class Address : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual ServerSideBlazorApp.Data.AddressType? AddressType { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Address()
        {
        }
        #endregion
    }
    #endregion

    #region customer
    public partial class Customer : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual ServerSideBlazorApp.Data.GenderType GenderType { get; set; }
        public virtual int? CreditLimit { get; set; }
        public virtual int? YearOfLastCreditLimitReview { get; set; }
        public virtual DateTimeOffset RegistrationDate { get; set; }
        public virtual DateTimeOffset? LastLoginDate { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Customer()
        {
        }
        #endregion
    }
    #endregion

    #region customer address
    public partial class CustomerAddress : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int AddressId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        #endregion

        #region constructor
        public CustomerAddress()
        {
        }
        #endregion
    }
    #endregion

    #region product
    public partial class Product : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual ServerSideBlazorApp.Data.ProductCategoryType? ProductCategoryType { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double ListPrice { get; set; }
        public virtual double Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual decimal? Height { get; set; }
        public virtual decimal? Width { get; set; }
        public virtual decimal? Depth { get; set; }
        public virtual decimal? Weight { get; set; }
        public virtual decimal ShippingWeight { get; set; }
        public virtual TimeSpan? ValidStartTimeOfDayForPurchase { get; set; }
        public virtual TimeSpan? ValidEndTimeOfDayForPurchase { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Product()
        {
        }
        #endregion
    }
    #endregion

    #region purchase
    public partial class Purchase : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual int TotalPurchaseQuantity { get; set; }
        public virtual double TotalPurchaseAmount { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual DateTime? ShipDate { get; set; }
        public virtual DateTime? ExpectedDeliveryDate { get; set; }
        public virtual Guid? TrackingIdentifier { get; set; }
        public virtual ServerSideBlazorApp.Data.PaymentMethodType PaymentMethodType { get; set; }
        public virtual ServerSideBlazorApp.Data.PaymentSourceType? PaymentSourceType { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Purchase()
        {
        }
        #endregion
    }
    #endregion

    #region purchase line
    public partial class PurchaseLine : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual int PurchaseId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual decimal PurchasePrice { get; set; }
        public virtual int Quantity { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
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
        public virtual int Id { get; set; }
        public virtual double? TotalAmount { get; set; }
        public virtual int? TotalCount { get; set; }
        #endregion

        #region constructor
        public PersonTotalPurchasesView()
        {
        }
        #endregion
    }
    #endregion

}
namespace ServerSideBlazorApp.secData
{
    #region person
    public partial class Person : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual string SSN { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
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
